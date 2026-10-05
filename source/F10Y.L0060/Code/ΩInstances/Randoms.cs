using System;


namespace F10Y.L0060
{
    public class Randoms : IRandoms
    {
        #region Infrastructure

        public static IRandoms Instance { get; } = new Randoms();


        private Randoms()
        {
        }

        #endregion
    }
}
