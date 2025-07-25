using System;
using System.Text.Json;
using System.Threading.Tasks;

using F10Y.T0002;


namespace F10Y.L0060
{
    [FunctionsMarker]
    public partial interface IJsonDocumentOperator
    {
        /// <summary>
        /// Chooses <see cref="Deserialize_File_AsJsonDocument(string)"/> as the default.
        /// </summary>
        public Task<JsonDocument> Deserialize_File(string jsonFilePath)
            => this.Deserialize_File_AsJsonDocument(jsonFilePath);

        public async Task<JsonDocument> Deserialize_File_AsJsonDocument(string jsonFilePath)
        {
            await using var fileStream = Instances.FileStreamOperator.Open_Read(
                jsonFilePath);

            var output = await JsonDocument.ParseAsync(fileStream);
            return output;
        }

        public async Task<JsonElement> Deserialize_File_AsJsonElement(string jsonFilePath)
        {
            using var document = await this.Deserialize_File_AsJsonDocument(jsonFilePath);

            var root = this.Get_Root(document);

            // Always return a clone of the element you want, since the JsonDocument is disposable.
            var output = Instances.JsonElementOperator.Clone(root);
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Deserialize_Text_AsJsonDocument(string)"/> as the default.
        /// </summary>
        public JsonDocument Deserialize_Text(string jsonText)
            => this.Deserialize_Text_AsJsonDocument(jsonText);

        public JsonDocument Deserialize_Text_AsJsonDocument(string jsonText)
        {
            var output = JsonDocument.Parse(jsonText);
            return output;
        }

        public JsonElement Deserialize_Text_AsJsonElement(string jsonText)
        {
            using var document = this.Deserialize_Text_AsJsonDocument(jsonText);

            var root = this.Get_Root(document);

            // Always return a clone of the element you want, since the JsonDocument is disposable.
            var output = Instances.JsonElementOperator.Clone(root);
            return output;
        }

        public JsonElement Get_Root(JsonDocument jDocument)
        {
            var output = jDocument.RootElement;
            return output;
        }

        //public async Task Seerialize_ToFile(
        //    string jsonFilePath,
        //    JsonDocument document,
        //    bool overwrite = IValues.Overwrite_Default_Constant)
        //{
        //    using var fileStream = Instances.FileStreamOperator.Open_Write(
        //        jsonFilePath,
        //        overwrite);

        //    document.WriteTo()
        //}

        //public async Task Seerialize_ToFile(
        //    string jsonFilePath,
        //    JsonDocument document,
        //    bool overwrite = IValues.Overwrite_Default_Constant)
        //{
        //    using var fileStream = Instances.FileStreamOperator.Open_Write(
        //        jsonFilePath,
        //        overwrite);

        //    document.WriteTo()
        //}

        public async Task Serialize_ToFile<T>(
            string jsonFilePath,
            T value,
            JsonSerializerOptions options)
        {
            // "await using" because file steam is IAsyncDisposable.
            await using var fileStream = Instances.FileStreamOperator.Open_Write(
                jsonFilePath);

            await JsonSerializer.SerializeAsync(
                fileStream,
                value,
                options);
        }
    }
}
