namespace Memory.Core.Models.Cheats
{
    public abstract class CodeInjectionCheat : Cheat, IDisposable
    {
        public CodeInjectionCheat(string cheatName)
        {
            this.Name = cheatName;
        }

        public abstract void Dispose();
    }
}
