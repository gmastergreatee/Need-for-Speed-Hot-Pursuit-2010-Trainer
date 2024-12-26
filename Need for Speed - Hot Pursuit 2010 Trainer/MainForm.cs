using System.Timers;
using Memory.Core.Models.Cheats;
using Need_for_Speed___Hot_Pursuit_2010_Trainer.Cheats;

namespace Need_for_Speed___Hot_Pursuit_2010_Trainer
{
    public partial class MainForm : Form
    {
        System.Timers.Timer timer;
        Memory.Memory memory;

        bool attachedStatus = false;

        public MainForm()
        {
            memory = new Memory.Memory(GetAllCheats(), Cheat_Constants.CodeCaveMinSizeInBytes);

            timer = new System.Timers.Timer(500);
            timer.Elapsed += timer_elapsed;
            timer.Start();

            InitializeComponent();

            this.ResetTrainer();
        }

        private void timer_elapsed(object? sender, ElapsedEventArgs e)
        {
            try
            {
                if (memory.OpenProcess(Cheat_Constants.GameExeName))
                {
                    if (attachedStatus)
                    {
                        return;
                    }
                    attachedStatus = true;

                    Invoke(() =>
                    {
                        lblTrainerStatus.Text = $"Successfully attached to game process {{{Cheat_Constants.GameExeName}.exe}} (PID: {memory.Process?.Id})";
                    });
                }
                else
                {
                    if (!attachedStatus)
                    {
                        return;
                    }
                    attachedStatus = false;

                    Invoke(() =>
                    {
                        lblTrainerStatus.Text = $"Trainer NOT attached to game. Searching for {{{Cheat_Constants.GameExeName}.exe}}...";
                    });
                }
            }
            catch { }
        }

        private void ResetTrainer()
        {
            lblTrainerStatus.Text = "";
        }

        private List<Cheat> GetAllCheats()
        {
            var unlimitedNitroCheat = new NFSHP_UnlimitedNitroCheat();
            var noBotsWithNitroCheat = new NFSHP_NoBotsWithNitroCheat(unlimitedNitroCheat);

            return
            [
                unlimitedNitroCheat,
                noBotsWithNitroCheat,
            ];
        }

        #region HP related events
        private void btnHPToggle_Click(object sender, EventArgs e)
        {
        }

        private void btnTakedownToggle_Click(object sender, EventArgs e)
        {
        }
        #endregion

        #region Nitro related events
        private void btnNitroToggle_Click(object sender, EventArgs e)
        {
            var nitroCheat = memory.gameCheats.FirstOrDefault(i => i.Name == Cheat_Constants.Nitro_Player_CheatName);
            if (nitroCheat != null)
            {
                if (nitroCheat.ApplyCheat())
                {
                    lblFullNitro.Text = "ON";
                    lblFullNitro.ForeColor = Color.Green;
                }
                else
                {
                    lblFullNitro.Text = "OFF";
                    lblFullNitro.ForeColor = Color.Red;
                }
            }
        }

        private void btnBotsNoNitro_Click(object sender, EventArgs e)
        {
            var botsNoNitroCheat = memory.gameCheats.FirstOrDefault(i => i.Name == Cheat_Constants.Nitro_NoBots_CheatName);
            if (botsNoNitroCheat != null)
            {
                if (botsNoNitroCheat.ApplyCheat())
                {
                    lblBotsNoNitro.Text = "ON";
                    lblBotsNoNitro.ForeColor = Color.Green;
                }
                else
                {
                    lblBotsNoNitro.Text = "OFF";
                    lblBotsNoNitro.ForeColor = Color.Red;
                }
            }
        }
        #endregion

    }
}
