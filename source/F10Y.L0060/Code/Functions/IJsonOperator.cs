using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

using F10Y.T0002;


namespace F10Y.L0060
{
    /// <summary>
    /// .NET 6.0 foundation library JSON operator.
    /// </summary>
    [FunctionsMarker]
    public partial interface IJsonOperator
    {
        public Task<T> Deserialize_FromFile<T>(string jsonFilePath)
            => this.Load_FromFile<T>(jsonFilePath);

        public T Deserialize_FromText<T>(string jsonText)
        {
            var output = JsonSerializer.Deserialize<T>(jsonText);
            return output;
        }

        public JsonSerializerOptions Get_Options_Standard()
        {
            var output = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            return output;
        }

        public async Task<T> Load_FromFile<T>(string jsonFilePath)
        {
            using var fileStream = Instances.FileStreamOperator.Open_Read(jsonFilePath);

            var output = await JsonSerializer.DeserializeAsync<T>(fileStream);
            return output;
        }

        public Task Serialize<T>(
            string jsonFilePath,
            T value)
            => this.Serialize_ToFile<T>(
                jsonFilePath,
                value);

        public Task Serialize_ToFile<T>(
            string jsonFilePath,
            T value,
            JsonSerializerOptions options)
            => Instances.JsonDocumentOperator.Serialize_ToFile(
                jsonFilePath,
                value,
                options);

        public Task Serialize_ToFile_Indented<T>(
            string jsonFilePath,
            T value)
            => this.Serialize_ToFile(
                jsonFilePath,
                value,
                Instances.JsonSerializerOptionsSet.Indented);

        public Task Serialize_ToFile<T>(
            string jsonFilePath,
            T value)
            => this.Serialize_ToFile_Indented(
                jsonFilePath,
                value);

        public string Serialize_ToText(
            JsonObject jsonObject,
            JsonSerializerOptions options)
            // Just reuse the generic logic.
            => this.Serialize_ToText<JsonObject>(
                jsonObject,
                options);

        public string Serialize_ToText(JsonObject jsonObject)
        {
            var options = this.Get_Options_Standard();

            var output = this.Serialize_ToText(
                jsonObject,
                options);

            return output;
        }

        public string Serialize_ToText<T>(T value)
        {
            var options = this.Get_Options_Standard();

            var output = this.Serialize_ToText(
                value,
                options);

            return output;
        }

        public string Serialize_ToText<T>(
            T value,
            JsonSerializerOptions options)
        {
            var jsonText = Instances.StringOperator.Serialize_UsingMemoryStream(
                memoryStream =>
                {
                    JsonSerializer.Serialize(
                        memoryStream,
                        value,
                        options);
                });

            return jsonText;
        }
    }
}
