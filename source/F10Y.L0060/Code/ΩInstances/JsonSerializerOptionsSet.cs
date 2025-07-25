using System;


namespace F10Y.L0060
{
    public class JsonSerializerOptionsSet : IJsonSerializerOptionsSet
    {
        #region Infrastructure

        public static IJsonSerializerOptionsSet Instance { get; } = new JsonSerializerOptionsSet();


        private JsonSerializerOptionsSet()
        {
        }

        #endregion
    }
}
