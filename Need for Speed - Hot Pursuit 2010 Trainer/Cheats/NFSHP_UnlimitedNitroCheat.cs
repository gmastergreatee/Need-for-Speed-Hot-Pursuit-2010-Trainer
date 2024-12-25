using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoryDll;
using Need_for_Speed___Hot_Pursuit_2010_Trainer.Core;
using Need_for_Speed___Hot_Pursuit_2010_Trainer.Core.Model.Type;

namespace Need_for_Speed___Hot_Pursuit_2010_Trainer.Cheats
{
    public class NFSHP_UnlimitedNitroCheat : CodeInjectionCheat
    {
        Mem mem;

        public NFSHP_UnlimitedNitroCheat(Mem mem)
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
            throw new NotImplementedException();
        }
    }
}
