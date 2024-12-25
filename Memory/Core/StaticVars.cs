using Memory.Core.Models;

namespace Memory.Core
{
    internal static class StaticVars
    {
        public static int CodeCaveAddress { get; set; } = 0;
        public static List<CodeCaveBytes> CodeCaveBytes { get; set; } = [];

        public static CodeCaveBytes? GetCodeCaveByName(string caveName)
        {
            return CodeCaveBytes.FirstOrDefault(i => i.RangeName == caveName);
        }
    }
}
