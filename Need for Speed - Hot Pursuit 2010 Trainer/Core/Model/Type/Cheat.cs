namespace Need_for_Speed___Hot_Pursuit_2010_Trainer.Core.Model.Type
{
    public abstract class Cheat
    {
        public delegate void CheatStatusChangeEvent(bool statusChanged);
        public event CheatStatusChangeEvent StatusChanged;

        public CheatTypeEnum CheatType { get; set; }

        protected void TriggerStatusChanged(bool status)
        {
            StatusChanged?.Invoke(status);
        }
    }
}
