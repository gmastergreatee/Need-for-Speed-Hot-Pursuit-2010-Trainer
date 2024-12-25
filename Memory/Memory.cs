using System.Diagnostics;
using Memory.Core;

namespace Memory
{
    public class Memory
    {
        public Process? Process { get; private set; }
        public IntPtr ProcessHandle { get; private set; }

        public bool OpenProcess(string processName)
        {
            var procs = Process.GetProcessesByName(processName);
            if (procs.Count() <= 0) { return false; }

            this.Process = procs[0];
            this.ProcessHandle = Kernel.OpenProcess(Kernel.Imps.DW_DesiredAccess.PROCESS_ALL_ACCESS, true, this.Process.Id);

            if (this.ProcessHandle == IntPtr.Zero) { return false; }

            return true;
        }
    }
}
