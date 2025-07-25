using System;

using F10Y.T0003;
using F10Y.T0011;


namespace F10Y.L0060
{
    [ValuesMarker]
    public partial interface IValues
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public L0000.IValues _L0000 => L0000.Values.Instance;

#pragma warning restore IDE1006 // Naming Styles
    }
}
