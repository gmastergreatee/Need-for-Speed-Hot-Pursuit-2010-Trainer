using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memory;
using Memory.Core.Models.Cheats;

namespace Need_for_Speed___Hot_Pursuit_2010_Trainer.Cheats
{
    internal class NFSHP_UnlimitedNitroCheat : CodeInjectionCheat
    {
        private UInt32 targetAddress = 0;
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
                var targetJumpAddress = AddressUtils.AddressStringToNumber(Cheat_Constants.NitroAccessorAddress, memory.Process);
                if (targetJumpAddress == null)
                {
                    throw new Exception($"[{this.Name}] : Unable to get target jump address");
                }

                this.targetAddress = targetJumpAddress.Value;

                this.Initialized = true;
            }
            catch { }
            return this.Initialized;
        }
    }
}
