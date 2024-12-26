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
        private UInt32 jumpToCodeCaveAddress = 0;

        private string jumpBytes = "";
        private string caveBytes = "";
        public NFSHP_UnlimitedNitroCheat() : base(Cheat_Constants.NitroCheatName)
        {
        }

        public override bool ApplyCheat()
        {
            this.Enabled = !this.Enabled;
            return this.Enabled;
        }

        public override bool InitializeCheat(Memory.Memory memory)
        {
            try
            {
                var targetToJumpFrom_Address = AddressUtils.AddressStringToNumber(Cheat_Constants.NitroAccessorAddress, memory.Process);
                if (targetToJumpFrom_Address == null)
                {
                    throw new Exception($"[{this.Name}] : Unable to get target jump address");
                }

                this.jumpFromThisAddress = targetToJumpFrom_Address.Value;
                this.jumpBytes = AddressUtils.ParseAsm_CreateLabels(this.jumpFromThisAddress, Cheat_Constants.NitroJumpBytes);

                this.jumpToCodeCaveAddress = StaticVars.CodeCaveAddress.Value + StaticVars.CodeCaveUsedBytes;
                this.caveBytes = AddressUtils.ParseAsm_CreateLabels(this.jumpToCodeCaveAddress, Cheat_Constants.NitroCaveBytes);

                //StaticVars.CodeCaveUsedBytes += 

                this.Initialized = true;
            }
            catch { }
            return this.Initialized;
        }
    }
}
