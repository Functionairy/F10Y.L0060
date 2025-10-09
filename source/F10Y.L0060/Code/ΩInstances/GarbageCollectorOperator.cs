using System;


namespace F10Y.L0060
{
    public class GarbageCollectorOperator : IGarbageCollectorOperator
    {
        #region Infrastructure

        public static IGarbageCollectorOperator Instance { get; } = new GarbageCollectorOperator();


        private GarbageCollectorOperator()
        {
        }

        #endregion
    }
}
