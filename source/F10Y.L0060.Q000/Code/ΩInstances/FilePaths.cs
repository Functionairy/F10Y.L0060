using System;


namespace F10Y.L0060.Q000
{
    public class FilePaths : IFilePaths
    {
        #region Infrastructure

        public static IFilePaths Instance { get; } = new FilePaths();


        private FilePaths()
        {
        }

        #endregion
    }
}
