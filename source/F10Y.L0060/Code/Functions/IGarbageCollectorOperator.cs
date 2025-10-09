using System;

using F10Y.T0002;
using F10Y.T0011;


namespace F10Y.L0060
{
    [FunctionsMarker]
    public partial interface IGarbageCollectorOperator :
        L0000.IGarbageCollectorOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        L0000.IGarbageCollectorOperator _L0000 => L0000.GarbageCollectorOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles

        /// <inheritdoc cref="GC.GetGCMemoryInfo()"/>
        GCMemoryInfo Get_MemoryInfo()
            => GC.GetGCMemoryInfo();

        /// <inheritdoc cref="GCMemoryInfo.TotalAvailableMemoryBytes"/>
        long Get_TotalAvailableMemory_InBytes(GCMemoryInfo memoryInfo)
            => memoryInfo.TotalAvailableMemoryBytes;

        /// <inheritdoc cref="Get_TotalAvailableMemory_InBytes(GCMemoryInfo)"/>
        long Get_TotalAvailableMemory_InBytes()
        {
            var memoryInfo = this.Get_MemoryInfo();

            var output = this.Get_TotalAvailableMemory_InBytes(memoryInfo);
            return output;
        }
    }
}
