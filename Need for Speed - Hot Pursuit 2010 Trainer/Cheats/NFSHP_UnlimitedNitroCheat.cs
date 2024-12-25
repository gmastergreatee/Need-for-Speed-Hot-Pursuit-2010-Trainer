using Memory;
using Need_for_Speed___Hot_Pursuit_2010_Trainer.Core.Model.Type;

namespace Need_for_Speed___Hot_Pursuit_2010_Trainer.Cheats
{
    public class NFSHP_UnlimitedNitroCheat : CodeInjectionCheat
    {
        public Memory.Memory Mem { get; }

        public NFSHP_UnlimitedNitroCheat(Memory.Memory mem)
        {
            this.Mem = mem;
        }

        public override bool InitCheat()
        {
            // put aob in codecave
            // 
            // replace jump paths
            return true;
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
