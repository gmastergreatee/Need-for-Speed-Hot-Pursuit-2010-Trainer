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

            int? oldPid = this.Process?.Id;

            this.Process = procs[0];
            this.ProcessHandle = Kernel.OpenProcess(Kernel.Imps.DW_DesiredAccess.PROCESS_ALL_ACCESS, true, this.Process.Id);

            if (this.ProcessHandle == IntPtr.Zero) { return false; }

            if (oldPid != this.Process.Id)
            {
                // cleanup old variables
                this.CleanupStaticVars();
                this.Initialize();
            }

            return true;
        }

        private void CleanupStaticVars()
        {
            StaticVars.CodeCaveAddress = null;
            StaticVars.AddressLabels = [];
        }

        private bool Initialize()
        {
            try
            {
                // create code cave if required
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

                // initialize cheats
                foreach (var cheat in gameCheats)
                {
                    cheat.InitializeCheat(this);
                }

                // apply cheats which have already been enabled previously
                foreach (var cheat in gameCheats.Where(i => i.Enabled && i.Initialized))
                {
                    this.ApplyCheat(cheat);
                }

                return true;
            }
            catch (Exception ex) { }

            return false;
        }

        public void ApplyCheat(Cheat cheat)
        {
            cheat.ApplyCheat();
        }
    }
}
