namespace Memory.Core.Models
{
    public interface ICheat
    {
        string Name { get; set; }
        bool InitializeCheat(Memory memory);
        bool ApplyCheat();
    }
}
