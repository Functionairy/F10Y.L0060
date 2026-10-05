using System;

using F10Y.T0003;


namespace F10Y.L0060
{
    [ValuesMarker]
    public partial interface IRandoms
    {
        /// <inheritdoc cref="Random.Shared"/>
        Random Shared => Random.Shared;
    }
}
