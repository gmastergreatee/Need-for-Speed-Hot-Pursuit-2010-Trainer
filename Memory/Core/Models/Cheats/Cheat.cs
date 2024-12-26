namespace Memory.Core.Models.Cheats
{
    public abstract class Cheat : ICheat
    {
        public bool IsEnabled { get; protected set; } = false;
        public bool IsInitialized { get; protected set; } = false;

        public required string Name { get; set; }

        public abstract bool InitializeCheat(Memory memory);

        public abstract bool ApplyCheat();
    }
}
