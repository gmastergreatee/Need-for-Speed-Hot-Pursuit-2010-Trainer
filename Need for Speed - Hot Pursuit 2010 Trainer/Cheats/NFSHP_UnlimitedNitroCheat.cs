using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memory;
using Memory.Core;
using Memory.Core.Models.Cheats;

namespace Need_for_Speed___Hot_Pursuit_2010_Trainer.Cheats
{
    internal class NFSHP_UnlimitedNitroCheat : CodeInjectionCheat
    {
        private UInt32 jumpFromThisAddress = 0;
        private UInt32 codeCaveAddress = 0;

        private string jumpBytes = "";

        private Memory.Memory memory;

        public NFSHP_UnlimitedNitroCheat() : base(Cheat_Constants.NitroCheatName)
        {
        }

        public override bool ApplyCheat()
        {
            this.Enabled = !this.Enabled;

            if (this.Enabled)
            {
            }
            else
            {

            }

            return this.Enabled;
        }

        public override bool InitializeCheat(Memory.Memory memory)
        {
            this.memory = memory;
            try
            {
                var targetToJumpFrom_Address = AddressUtils.AddressStringToNumber(Cheat_Constants.NitroAccessorAddress, memory.Process);
                if (targetToJumpFrom_Address == null)
                {
                    throw new Exception($"[{this.Name}] : Unable to get target jump address");
                }

                this.jumpFromThisAddress = targetToJumpFrom_Address.Value;
                this.jumpBytes = AddressUtils.ParseAsm_CreateLabels(this.jumpFromThisAddress, Cheat_Constants.NitroJumpBytes);

                this.codeCaveAddress = StaticVars.CodeCaveAddress.Value + StaticVars.CodeCaveUsedBytes;
                var caveBytes = AddressUtils.ParseAsm_CreateLabels(this.codeCaveAddress, Cheat_Constants.NitroCaveBytes);

                this.jumpBytes = AddressUtils.ParseAsm_AssignLabels(this.jumpFromThisAddress, this.jumpBytes);
                caveBytes = AddressUtils.ParseAsm_AssignLabels(this.codeCaveAddress, caveBytes);

                Kernel.WriteProcessMemory(
                    memory.ProcessHandle,
                    this.codeCaveAddress,
                    AddressUtils.HexStringToByteArray(caveBytes),
                    (UInt32)caveBytes.Length / 2,
                    out int bytesWritten
                );

                StaticVars.CodeCaveUsedBytes += (uint)(caveBytes.Length / 2);

                this.Initialized = true;
            }
            catch { }
            return this.Initialized;
        }
    }
}
