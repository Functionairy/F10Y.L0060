using System;


namespace F10Y.L0060
{
    public class DateOnlyOperator : IDateOnlyOperator
    {
        #region Infrastructure

        public static IDateOnlyOperator Instance { get; } = new DateOnlyOperator();


        private DateOnlyOperator()
        {
        }

        #endregion
    }
}
