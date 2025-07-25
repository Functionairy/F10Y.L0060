using System;
using System.Text.Json;

using F10Y.T0002;


namespace F10Y.L0060
{
    [FunctionsMarker]
    public partial interface IJsonElementOperator
    {
        public JsonElement Clone(JsonElement jElement)
        {
            var output = jElement.Clone();
            return output;
        }

        public T Deserialize<T>(JsonElement jsonElement)
        {
            var output = jsonElement.Deserialize<T>();
            return output;
        }

        public T Deserialize<T, TSerialization>(
            JsonElement jsonElement,
            Func<TSerialization, T> converter)
        {
            var serialization = this.Deserialize<TSerialization>(jsonElement);

            var output = converter(serialization);
            return output;
        }

        public Func<JsonElement, T> Get_Deserialize<T, TSerialization>(Func<TSerialization, T> converter)
            => jsonElement => this.Deserialize(
                jsonElement,
                converter);

        public Func<T, JsonElement> Get_Serialize<T, TSerialization>(Func<T, TSerialization> converter)
            => value => this.Serialize(
                value,
                converter);

        public JsonElement Serialize_AsImplementationType<T>(T value)
        {
            var implementationType = Instances.TypeOperator.Get_Type_ImplementationType(value);

            var output = JsonSerializer.SerializeToElement(
                value,
                implementationType);

            return output;
        }

        public JsonElement Serialize_AsDeclaredType<T>(T value)
        {
            // The type used by the JSON serializer is the declared type of the value.
            var output = JsonSerializer.SerializeToElement(value);
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Serialize_AsImplementationType{T}(T)"/> as the default.
        /// </summary>
        public JsonElement Serialize<T>(T value)
            => this.Serialize_AsImplementationType(value);

        public JsonElement Serialize<T, TSerialization>(
            T value,
            Func<T, TSerialization> converter)
        {
            var serialization = converter(value);

            var output = this.Serialize(serialization);
            return output;
        }
    }
}
