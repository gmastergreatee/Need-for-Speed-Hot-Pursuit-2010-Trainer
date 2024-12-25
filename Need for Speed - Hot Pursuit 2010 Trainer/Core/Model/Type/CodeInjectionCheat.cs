using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Need_for_Speed___Hot_Pursuit_2010_Trainer.Core.Model.Type
{
    public abstract class CodeInjectionCheat : Cheat, ICheat
    {
        public abstract bool InitCheat();

        public abstract bool ToggleCheat();
    }
}
