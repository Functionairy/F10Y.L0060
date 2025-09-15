using System;


namespace F10Y.L0060
{
    public class TimeOnlyOperator : ITimeOnlyOperator
    {
        #region Infrastructure

        public static ITimeOnlyOperator Instance { get; } = new TimeOnlyOperator();


        private TimeOnlyOperator()
        {
        }

        #endregion
    }
}
