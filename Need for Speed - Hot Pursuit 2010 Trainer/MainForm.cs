using System.Timers;
using Memory.Core.Models.Cheats;
using Need_for_Speed___Hot_Pursuit_2010_Trainer.Cheats;

namespace Need_for_Speed___Hot_Pursuit_2010_Trainer
{
    public partial class MainForm : Form
    {
        System.Timers.Timer timer;
        Memory.Memory memory;

        public MainForm()
        {
            memory = new Memory.Memory(GetAllCheats(), Cheat_Constants.CodeCaveMinSizeInBytes);

            timer = new System.Timers.Timer(200);
            timer.Elapsed += timer_elapsed;
            timer.Start();

            InitializeComponent();

            this.ResetTrainer();
        }

        private void timer_elapsed(object? sender, ElapsedEventArgs e)
        {
            if (memory.OpenProcess(Cheat_Constants.GameExeName))
            {
                lblTrainerStatus.Text = $"Successfully attached to game process (PID: {memory.Process?.Id})";
            }
            else
            {
                lblTrainerStatus.Text = "Trainer NOT attached to game. Searching for NFS11.exe...";
            }
        }

        private void ResetTrainer()
        {
            lblTrainerStatus.Text = "";
        }

        private List<Cheat> GetAllCheats()
        {
            return [];
        }
    }
}
