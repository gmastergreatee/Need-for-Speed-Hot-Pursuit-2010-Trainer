﻿using Memory.Core;
using Memory.Core.Models.Cheats;

namespace Need_for_Speed___Hot_Pursuit_2010_Trainer.Cheats
{
    internal class NFSHP_InstantTakedownCheat : CodeInjectionCheat
    {
        private Memory.Memory? memory;

        // just a dummy reference coz this cheat needs NFSHP_UnlimitedHPCheat to be initialized
        public NFSHP_InstantTakedownCheat(NFSHP_UnlimitedHPCheat unlimitedHPCheat) { }

        public override bool ApplyCheat()
        {
            if (memory == null || memory.Process == null || memory.Process.HasExited)
            {
                return false;
            }

            var isInstantTakedown_Address = StaticVars.GetLabelAddress(Cheat_Constants.HPTriggerByte_BotVariable);
            if (isInstantTakedown_Address == null)
            {
                return false;
            }

            this.IsEnabled = !this.IsEnabled;
            Kernel.WriteProcessMemory(
                memory.ProcessHandle,
                isInstantTakedown_Address.Value,
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
