using Memory.Core.Models;

namespace Memory.Core
{
    internal static class StaticVars
    {
        public static UInt32? CodeCaveAddress { get; set; } = null;
        public static List<AddressLabelModel> AddressLabels { get; set; } = [];

        public static UInt32? GetLabelAddress(string label)
        {
            return StaticVars.AddressLabels.FirstOrDefault(i => i.LabelName == label)?.Address;
        }
    }
}
