using System.Diagnostics;
using Memory.Core;
using Memory.Core.Models.Cheats;

namespace Memory
{
    public class Memory
    {
        private readonly List<Cheat> gameCheats;
        private readonly uint? _codeCaveSize;

        public Process? Process { get; private set; }
        public IntPtr ProcessHandle { get; private set; }

        public Memory(List<Cheat> gameCheats, uint? codeCaveSize = null)
        {
            this.gameCheats = gameCheats;
            this._codeCaveSize = codeCaveSize;
        }

        public bool OpenProcess(string processName)
        {
            var procs = Process.GetProcessesByName(processName);
            if (procs.Length <= 0) { return false; }

            this.Process = procs[0];
            this.ProcessHandle = Kernel.OpenProcess(Kernel.Imps.DW_DesiredAccess.PROCESS_ALL_ACCESS, true, this.Process.Id);

            if (this.ProcessHandle == IntPtr.Zero) { return false; }
            this.Initialize();

            return true;
        }

        private bool Initialize()
        {
            if (_codeCaveSize != null && _codeCaveSize > 0)
            {
                StaticVars.CodeCaveAddress = Kernel.VirtualAllocEx(
                    ProcessHandle,
                    (UIntPtr)null,
                    _codeCaveSize.Value,
                    Kernel.Imps.FL_AllocationType.MEM_COMMIT | Kernel.Imps.FL_AllocationType.MEM_RESERVE,
                    Kernel.Imps.FL_Protection.PAGE_EXECUTE_READWRITE
                );
            }

            foreach (var cheat in gameCheats)
            {
                cheat.InitializeCheat();
            }

            return true;
        }
    }
}
