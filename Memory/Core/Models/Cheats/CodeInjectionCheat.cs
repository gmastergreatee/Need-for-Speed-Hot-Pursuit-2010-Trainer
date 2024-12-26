namespace Memory.Core.Models.Cheats
{
    public abstract class CodeInjectionCheat : Cheat
    {
        public CodeInjectionCheat(string cheatName)
        {
            this.Name = cheatName;
        }
    }
}
