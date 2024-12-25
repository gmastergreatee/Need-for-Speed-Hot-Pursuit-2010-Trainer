using System;

namespace MemoryDll
{
    /// <summary>
    /// AoB scan information.
    /// </summary>
    struct MemoryRegionResult
    {
        public UIntPtr CurrentBaseAddress { get; set; }
        public long RegionSize { get; set; }
        public UIntPtr RegionBase { get; set; }

    }
}
