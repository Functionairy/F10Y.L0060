using System;


namespace F10Y.L0060
{
    public class DateTimeOperator : IDateTimeOperator
    {
        #region Infrastructure

        public static IDateTimeOperator Instance { get; } = new DateTimeOperator();


        private DateTimeOperator()
        {
        }

        #endregion
    }
}
