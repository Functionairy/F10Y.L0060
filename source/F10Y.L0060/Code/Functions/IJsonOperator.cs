using System;
using System.Collections.Generic;
using System.Linq;
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
        JsonArray As_Array(JsonNode node)
            => node.AsArray();

        JsonObject As_Object(JsonNode node)
            => node.AsObject();

        JsonValue As_Value(JsonNode node)
            => node.AsValue();

        Task<T> Deserialize_FromFile<T>(string jsonFilePath)
            => this.Load_FromFile<T>(jsonFilePath);

        T Deserialize_FromText<T>(string jsonText)
        {
            var output = JsonSerializer.Deserialize<T>(jsonText);
            return output;
        }

        JsonNode Get_Child(
            JsonNode node,
            string childName)
        {
            var output = node[childName];
            return output;
        }

        JsonArray Get_Child_AsArray(
           JsonNode node,
           string childName)
        {
            var child = this.Get_Child(
                node,
                childName);

            var output = child.AsArray();
            return output;
        }

        JsonObject Get_Child_AsObject(
           JsonNode node,
           string childName)
        {
            var child = this.Get_Child(
                node,
                childName);

            var output = child.AsObject();
            return output;
        }

        JsonValue Get_Child_AsValue(
           JsonNode node,
           string childName)
        {
            var child = this.Get_Child(
                node,
                childName);

            var output = child.AsValue();
            return output;
        }

        T Get_Child_Value<T>(
            JsonNode node,
            string childName)
        {
            var value = this.Get_Child_AsValue(
                node,
                childName);

            var output = this.Get_Value<T>(value);
            return output;
        }

        string Get_Child_Value(
            JsonNode node,
            string childName)
            => this.Get_Child_Value<string>(
                node,
                childName);

        JsonSerializerOptions Get_Options_Standard()
        {
            var output = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            return output;
        }

        T Get_Value<T>(JsonValue value)
            => value.GetValue<T>();

        string Get_Value(JsonValue value)
            => this.Get_Value<string>(value);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Quality-of-life overload for <see cref="Has_Property(JsonObject, string, out JsonNode)"/>.
        /// </remarks>
        bool Has_Child(
            JsonObject value,
            string childName,
            out JsonNode child_OrDefault)
            => this.Has_Property(
                value,
                childName,
                out child_OrDefault);

        bool Has_Property(
            JsonObject value,
            string propertyName,
            out JsonNode property_OrDefault)
        {
            var output = value.TryGetPropertyValue(
                propertyName,
                out property_OrDefault);

            return output;
        }

        bool Has_Property_AsArray(
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

        bool Has_Property_AsObject(
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

        bool Has_Property_AsValue(
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

        async Task<T> Load_FromFile<T>(string jsonFilePath)
        {
            using var fileStream = Instances.FileStreamOperator.Open_Read(jsonFilePath);

            var output = await JsonSerializer.DeserializeAsync<T>(fileStream);
            return output;
        }

        Task<JsonObject> Load_FromFile_AsObject(string jsonFilePath)
            => this.Load_FromFile<JsonObject>(jsonFilePath);

        async Task<T> Load_FromFile<T>(
            string jsonFilePath,
            string objectKey)
        {
            var jsonText = await Instances.FileOperator.Read_Text(jsonFilePath);

            var rootElement = JsonSerializer.Deserialize<JsonElement>(jsonText);

            var keyedElement = rootElement.GetProperty(objectKey);

            var output = keyedElement.Deserialize<T>();
            return output;
        }

        T Load_FromFile_Synchronous<T>(
            string jsonFilePath,
            string objectKey)
        {
            var jsonText = Instances.FileOperator.Read_AllText_Synchronous(jsonFilePath);

            var rootElement = JsonSerializer.Deserialize<JsonElement>(jsonText);

            var keyedElement = rootElement.GetProperty(objectKey);

            var output = keyedElement.Deserialize<T>();
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="F10Y.L0060.IJsonOperator.Deserialize_FromText{T}(string)"/>
        /// </summary>
        T Load_FromString<T>(string jsonString)
            => this.Deserialize_FromText<T>(jsonString);

        JsonArray New_Array(IEnumerable<JsonNode> nodes)
            => this.New_Array(nodes.ToArray());

        JsonArray New_Array(params JsonNode[] nodes)
            => new(nodes);

        JsonObject New_Object()
            => new();

        JsonNode Parse_AsNode(string jsonText)
        {
            var output = JsonObject.Parse(jsonText);
            return output;
        }

        JsonArray Parse_AsArray(string jsonText)
        {
            var node = this.Parse_AsNode(jsonText);

            var output = node.AsArray();
            return output;
        }
        
        JsonDocument Parse_AsDocument(string jsonText)
        {
            var output = JsonDocument.Parse(jsonText);
            return output;
        }

        JsonElement Parse_AsElement(string jsonText)
        {
            var document = this.Parse_AsDocument(jsonText);

            var output = document.RootElement;
            return output;
        }

        JsonObject Parse_AsObject(string jsonText)
        {
            var node = this.Parse_AsNode(jsonText);

            var output = node.AsObject();
            return output;
        }

        JsonObject Parse_Object_FromJsonText(string jsonText)
        {
            var output = JsonObject.Parse(jsonText).AsObject();
            return output;
        }

        T Parse_FromJsonText<T>(
            string jsonText,
            string keyName)
        {
            var jsonObject = this.Parse_Object_FromJsonText(jsonText);

            var jsonNode = jsonObject[keyName];

            var output = jsonNode.GetValue<T>();
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Parse_Object_FromJsonText(string)"/>.
        /// </summary>
        JsonObject Parse_FromJsonText(string jsonText)
            => this.Parse_Object_FromJsonText(jsonText);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Chooses <see cref="Parse_AsObject(string)"/> as the default.
        /// </remarks>
        JsonObject Parse(string jsonText)
            => this.Parse_AsObject(jsonText);

        JsonValue Parse_AsValue(string jsonText)
        {
            var node = this.Parse_AsNode(jsonText);

            var output = node.AsValue();
            return output;
        }

        void Save_ToFile_Synchronous<T>(
            string jsonFilePath,
            T value)
        {
            using var fileStream = Instances.FileStreamOperator.Open_Write(
                jsonFilePath);

            JsonSerializer.Serialize(
                fileStream,
                value);
        }

        async Task Save_ToFile<T>(
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

        Task Save_ToFile<T>(
            string jsonFilePath,
            T value)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            return this.Save_ToFile<T>(
                jsonFilePath,
                value,
                options);
        }

        string Save_ToString<T>(T value)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            var output = JsonSerializer.Serialize(
                value,
                options);

            return output;
        }

        Task Serialize<T>(
            string jsonFilePath,
            T value)
            => this.Serialize_ToFile<T>(
                jsonFilePath,
                value);

        Task Serialize_ToFile<T>(
            string jsonFilePath,
            T value,
            JsonSerializerOptions options)
            => Instances.JsonDocumentOperator.Serialize_ToFile(
                jsonFilePath,
                value,
                options);

        Task Serialize_ToFile_Indented<T>(
            string jsonFilePath,
            T value)
            => this.Serialize_ToFile(
                jsonFilePath,
                value,
                Instances.JsonSerializerOptionsSet.Indented);

        Task Serialize_ToFile<T>(
            string jsonFilePath,
            T value)
            => this.Serialize_ToFile_Indented(
                jsonFilePath,
                value);

        string Serialize_ToText(
            JsonObject jsonObject,
            JsonSerializerOptions options)
            // Just reuse the generic logic.
            => this.Serialize_ToText<JsonObject>(
                jsonObject,
                options);

        string Serialize_ToText(JsonObject jsonObject)
        {
            var options = this.Get_Options_Standard();

            var output = this.Serialize_ToText(
                jsonObject,
                options);

            return output;
        }

        string Serialize_ToText<T>(T value)
        {
            var options = this.Get_Options_Standard();

            var output = this.Serialize_ToText(
                value,
                options);

            return output;
        }

        string Serialize_ToText<T>(
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
