using System;

using F10Y.T0002;
using F10Y.T0011;


namespace F10Y.L0060
{
    [FunctionsMarker]
    public partial interface IEnvironmentOperator :
        L0001.L000.IEnvironmentOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        L0001.L000.IEnvironmentOperator _L0001_L000 => L0001.L000.EnvironmentOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles

        /// <inheritdoc cref="IGarbageCollectorOperator.Get_MemoryInfo"/>
        GCMemoryInfo Get_MemoryInfo()
            => Instances.GarbageCollectorOperator.Get_MemoryInfo();

        /// <inheritdoc cref="IGarbageCollectorOperator.Get_TotalAvailableMemory_InBytes()"/>
        long Get_TotalAvailableMemory_InBytes()
            => Instances.GarbageCollectorOperator.Get_TotalAvailableMemory_InBytes();
    }
}
