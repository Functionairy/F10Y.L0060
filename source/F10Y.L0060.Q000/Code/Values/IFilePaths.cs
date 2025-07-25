using System;

using F10Y.T0003;
using F10Y.T0011;


namespace F10Y.L0060.Q000
{
    [ValuesMarker]
    public partial interface IFilePaths :
        L0004.L000.IFilePaths,
        Z0000.Z001.IFilePaths
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public L0004.L000.IFilePaths _L0004_L000 => L0004.L000.FilePaths.Instance;

        [Ignore]
        public Z0000.Z001.IFilePaths Z0000_Z001 => Z0000.Z001.FilePaths.Instance;

#pragma warning restore IDE1006 // Naming Styles
    }
}
