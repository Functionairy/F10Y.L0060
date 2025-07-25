using System;


namespace F10Y.L0060
{
    public class JsonOperator : IJsonOperator
    {
        #region Infrastructure

        public static IJsonOperator Instance { get; } = new JsonOperator();


        private JsonOperator()
        {
        }

        #endregion
    }
}
