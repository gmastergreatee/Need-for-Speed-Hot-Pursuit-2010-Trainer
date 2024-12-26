namespace Memory.Core.Models
{
    public class AddressLabelModel
    {
        public string LabelName { get; set; }
        public UInt32 Address { get; set; }

        public override string ToString()
        {
            return $"\"{LabelName}\": 0x{Address.ToString("X")}";
        }
    }
}
