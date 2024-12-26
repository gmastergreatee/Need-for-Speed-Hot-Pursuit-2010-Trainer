namespace Memory.Core.Models.Cheats
{
    public abstract class CodeInjectionCheat : Cheat, IDisposable
    {
        public abstract void Dispose();
    }
}
