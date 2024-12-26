namespace Memory.Core.Models.Cheats
{
    public abstract class Cheat : ICheat
    {
        public bool Enabled { get; set; } = false;
        public bool Initialized { get; set; } = false;

        public string Name { get; set; }

        public abstract bool InitializeCheat(Memory memory);

        public abstract bool ApplyCheat();
    }
}
