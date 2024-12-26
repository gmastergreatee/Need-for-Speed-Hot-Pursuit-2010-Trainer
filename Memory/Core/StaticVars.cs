using Memory.Core.Models;

namespace Memory.Core
{
    public static class StaticVars
    {
        public static UInt32? CodeCaveAddress { get; internal set; } = null;
        public static UInt32 CodeCaveUsedBytes { get; set; } = 0;
        public static List<AddressLabelModel> AddressLabels { get; set; } = [];

        public static UInt32? GetLabelAddress(string label)
        {
            return StaticVars.AddressLabels.FirstOrDefault(i => i.LabelName == label)?.Address;
        }

        public static void AddLabel(string labelName, UInt32 address)
        {
            var existingLabel = StaticVars.AddressLabels.FirstOrDefault(i => i.LabelName == labelName);
            if (existingLabel != null)
            {
                existingLabel.Address = address;
                return;
            }

            StaticVars.AddressLabels.Add(new AddressLabelModel()
            {
                LabelName = labelName,
                Address = address
            });
        }
    }
}
