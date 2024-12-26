using Memory.Core;
using Memory.Core.Models.Cheats;

namespace Need_for_Speed___Hot_Pursuit_2010_Trainer.Cheats
{
    internal class NFSHP_NoBotsWithNitroCheat : CodeInjectionCheat
    {
        private Memory.Memory? memory;

        // just a dummy reference coz this cheat needs NFSHP_UnlimitedNitroCheat to be initialized
        public NFSHP_NoBotsWithNitroCheat(NFSHP_UnlimitedNitroCheat unlimitedNitroCheat) { }

        public override bool ApplyCheat()
        {
            if (memory == null || memory.Process == null || memory.Process.HasExited)
            {
                return false;
            }

            var isAllOthersWithoutNitro_Address = StaticVars.GetLabelAddress(Cheat_Constants.NitroTriggerByte_BotsVariable);
            if (isAllOthersWithoutNitro_Address == null)
            {
                return false;
            }

            this.IsEnabled = !this.IsEnabled;
            Kernel.WriteProcessMemory(
                memory.ProcessHandle,
                isAllOthersWithoutNitro_Address.Value,
                this.IsEnabled ? [1] : [0],
                1,
                out _
            );

            return this.IsEnabled;
        }

        public override void Dispose()
        {
            // Do nothing coz nothing was injected in this cheat
        }

        public override bool InitializeCheat(Memory.Memory memory)
        {
            this.memory = memory;
            return true;
        }
    }
}
