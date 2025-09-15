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
        public JsonArray As_Array(JsonNode node)
            => node.AsArray();

        public JsonObject As_Object(JsonNode node)
            => node.AsObject();

        public JsonValue As_Value(JsonNode node)
            => node.AsValue();

        public Task<T> Deserialize_FromFile<T>(string jsonFilePath)
            => this.Load_FromFile<T>(jsonFilePath);

        public T Deserialize_FromText<T>(string jsonText)
        {
            var output = JsonSerializer.Deserialize<T>(jsonText);
            return output;
        }

        public JsonNode Get_Child(
            JsonNode node,
            string childName)
        {
            var output = node[childName];
            return output;
        }

        public JsonArray Get_Child_AsArray(
           JsonNode node,
           string childName)
        {
            var child = this.Get_Child(
                node,
                childName);

            var output = child.AsArray();
            return output;
        }

        public JsonObject Get_Child_AsObject(
           JsonNode node,
           string childName)
        {
            var child = this.Get_Child(
                node,
                childName);

            var output = child.AsObject();
            return output;
        }

        public JsonValue Get_Child_AsValue(
           JsonNode node,
           string childName)
        {
            var child = this.Get_Child(
                node,
                childName);

            var output = child.AsValue();
            return output;
        }

        public T Get_Child_Value<T>(
            JsonNode node,
            string childName)
        {
            var value = this.Get_Child_AsValue(
                node,
                childName);

            var output = this.Get_Value<T>(value);
            return output;
        }

        public string Get_Child_Value(
            JsonNode node,
            string childName)
            => this.Get_Child_Value<string>(
                node,
                childName);

        public JsonSerializerOptions Get_Options_Standard()
        {
            var output = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            return output;
        }

        public T Get_Value<T>(JsonValue value)
            => value.GetValue<T>();

        public string Get_Value(JsonValue value)
            => this.Get_Value<string>(value);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Quality-of-life overload for <see cref="Has_Property(JsonObject, string, out JsonNode)"/>.
        /// </remarks>
        public bool Has_Child(
            JsonObject value,
            string childName,
            out JsonNode child_OrDefault)
            => this.Has_Property(
                value,
                childName,
                out child_OrDefault);

        public bool Has_Property(
            JsonObject value,
            string propertyName,
            out JsonNode property_OrDefault)
        {
            var output = value.TryGetPropertyValue(
                propertyName,
                out property_OrDefault);

            return output;
        }

        public bool Has_Property_AsArray(
            JsonObject value,
            string propertyName,
            out JsonArray property_OrDefault)
        {
            var output = this.Has_Property(
                value,
                propertyName,
                out var property_OrDefault_AsNode);

            property_OrDefault = Instances.DefaultOperator.Convert(
                property_OrDefault_AsNode,
                this.As_Array);

            return output;
        }

        public bool Has_Property_AsObject(
            JsonObject value,
            string propertyName,
            out JsonObject property_OrDefault)
        {
            var output = this.Has_Property(
                value,
                propertyName,
                out var property_OrDefault_AsNode);

            property_OrDefault = Instances.DefaultOperator.Convert(
                property_OrDefault_AsNode,
                this.As_Object);

            return output;
        }

        public bool Has_Property_AsValue(
            JsonObject value,
            string propertyName,
            out JsonValue property_OrDefault)
        {
            var output = this.Has_Property(
                value,
                propertyName,
                out var property_OrDefault_AsNode);

            property_OrDefault = Instances.DefaultOperator.Convert(
                property_OrDefault_AsNode,
                this.As_Value);

            return output;
        }

        public async Task<T> Load_FromFile<T>(string jsonFilePath)
        {
            using var fileStream = Instances.FileStreamOperator.Open_Read(jsonFilePath);

            var output = await JsonSerializer.DeserializeAsync<T>(fileStream);
            return output;
        }

        public Task<JsonObject> Load_FromFile_AsObject(string jsonFilePath)
            => this.Load_FromFile<JsonObject>(jsonFilePath);

        public async Task<T> Load_FromFile<T>(
            string jsonFilePath,
            string objectKey)
        {
            var jsonText = await Instances.FileOperator.Read_Text(jsonFilePath);

            var rootElement = JsonSerializer.Deserialize<JsonElement>(jsonText);

            var keyedElement = rootElement.GetProperty(objectKey);

            var output = keyedElement.Deserialize<T>();
            return output;
        }

        public JsonNode Parse_AsNode(string jsonText)
        {
            var output = JsonObject.Parse(jsonText);
            return output;
        }

        public JsonArray Parse_AsArray(string jsonText)
        {
            var node = this.Parse_AsNode(jsonText);

            var output = node.AsArray();
            return output;
        }
        
        public JsonDocument Parse_AsDocument(string jsonText)
        {
            var output = JsonDocument.Parse(jsonText);
            return output;
        }

        public JsonElement Parse_AsElement(string jsonText)
        {
            var document = this.Parse_AsDocument(jsonText);

            var output = document.RootElement;
            return output;
        }

        public JsonObject Parse_AsObject(string jsonText)
        {
            var node = this.Parse_AsNode(jsonText);

            var output = node.AsObject();
            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Chooses <see cref="Parse_AsObject(string)"/> as the default.
        /// </remarks>
        public JsonObject Parse(string jsonText)
            => this.Parse_AsObject(jsonText);

        public JsonValue Parse_AsValue(string jsonText)
        {
            var node = this.Parse_AsNode(jsonText);

            var output = node.AsValue();
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
