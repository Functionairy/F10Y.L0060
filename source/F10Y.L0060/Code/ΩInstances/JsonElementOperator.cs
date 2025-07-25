using System;


namespace F10Y.L0060
{
    public class JsonElementOperator : IJsonElementOperator
    {
        #region Infrastructure

        public static IJsonElementOperator Instance { get; } = new JsonElementOperator();


        private JsonElementOperator()
        {
        }

        #endregion
    }
}
