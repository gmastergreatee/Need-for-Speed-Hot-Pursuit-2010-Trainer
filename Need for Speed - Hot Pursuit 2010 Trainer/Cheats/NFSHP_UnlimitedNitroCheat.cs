using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Need_for_Speed___Hot_Pursuit_2010_Trainer.Core;
using Need_for_Speed___Hot_Pursuit_2010_Trainer.Core.Model.Type;

namespace Need_for_Speed___Hot_Pursuit_2010_Trainer.Cheats
{
    public class NFSHP_UnlimitedNitroCheat : CodeInjectionCheat
    {
        Memory.Memory mem;

        public NFSHP_UnlimitedNitroCheat(Memory.Memory mem)
        {
            this.mem = mem;
        }

        public override bool InitCheat()
        {
            // put aob in codecave
            // 
            // replace jump paths
        }

        public override bool ToggleCheat()
        {
            var cheatStatus = true;

            // toggle cheat code

            TriggerStatusChanged(cheatStatus);
            return cheatStatus;
        }
    }
}
