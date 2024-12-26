using System.Timers;
using Memory.Core.Models.Cheats;
using Need_for_Speed___Hot_Pursuit_2010_Trainer.Cheats;

namespace Need_for_Speed___Hot_Pursuit_2010_Trainer
{
    public partial class MainForm : Form
    {
        System.Timers.Timer timer;
        Memory.Memory memory;

        bool? attachedStatus = null;
        List<Cheat> gameCheats = [];

        public MainForm()
        {
            this.InitializeCheats();

            memory = new Memory.Memory(gameCheats, Cheat_Constants.CodeCaveMinSizeInBytes);

            timer = new System.Timers.Timer(500);
            timer.Elapsed += timer_elapsed;
            timer.Start();

            InitializeComponent();
        }

        private void timer_elapsed(object? sender, ElapsedEventArgs e)
        {
            try
            {
                if (memory.OpenProcess(Cheat_Constants.GameExeName))
                {
                    if (attachedStatus == true)
                    {
                        return;
                    }
                    attachedStatus = true;

                    Invoke(() =>
                    {
                        EnableDisableTrainer(false);
                        lblTrainerStatus.Text = $"Successfully attached to game process {{{Cheat_Constants.GameExeName}.exe}} (PID: {memory.Process?.Id})";
                    });
                }
                else
                {
                    if (attachedStatus == false)
                    {
                        return;
                    }
                    attachedStatus = false;

                    Invoke(() =>
                    {
                        EnableDisableTrainer(true);
                        lblTrainerStatus.Text = $"Trainer NOT attached to game. Searching for {{{Cheat_Constants.GameExeName}.exe}}...";
                    });
                }
            }
            catch { }
        }

        private void InitializeCheats()
        {
            if (gameCheats.Count <= 0)
            {
                var unlimitedNitroCheat = new NFSHP_UnlimitedNitroCheat() { Name = Cheat_Constants.Nitro_Player_CheatName };
                var noBotsWithNitroCheat = new NFSHP_NoBotsWithNitroCheat(unlimitedNitroCheat) { Name = Cheat_Constants.Nitro_NoBots_CheatName };

                var unlimitedHPCheat = new NFSHP_UnlimitedHPCheat() { Name = Cheat_Constants.HP_Player_CheatName };
                var instantTakedownCheat = new NFSHP_InstantTakedownCheat(unlimitedHPCheat) { Name = Cheat_Constants.HP_Bot_CheatName };

                gameCheats.AddRange([
                    unlimitedNitroCheat,
                    noBotsWithNitroCheat,
                    unlimitedHPCheat,
                    instantTakedownCheat,
                ]);
            }
        }

        private void EnableDisableTrainer(bool isDisabled)
        {
            btnHPToggle.Enabled = !isDisabled;
            btnTakedownToggle.Enabled = !isDisabled;
            btnNitroToggle.Enabled = !isDisabled;
            btnBotsNoNitro.Enabled = !isDisabled;
        }

        #region HP related events
        private void btnHPToggle_Click(object sender, EventArgs e)
        {
            var hpCheat = memory.gameCheats.FirstOrDefault(i => i.Name == Cheat_Constants.HP_Player_CheatName);
            if (hpCheat != null)
            {
                if (hpCheat.ApplyCheat())
                {
                    lblHPStatus.Text = "ON";
                    lblHPStatus.ForeColor = Color.Green;
                }
                else
                {
                    lblHPStatus.Text = "OFF";
                    lblHPStatus.ForeColor = Color.Red;
                }
            }
        }

        private void btnTakedownToggle_Click(object sender, EventArgs e)
        {
            var takedownCheat = memory.gameCheats.FirstOrDefault(i => i.Name == Cheat_Constants.HP_Bot_CheatName);
            if (takedownCheat != null)
            {
                if (takedownCheat.ApplyCheat())
                {
                    lblTakedownStatus.Text = "ON";
                    lblTakedownStatus.ForeColor = Color.Green;
                }
                else
                {
                    lblTakedownStatus.Text = "OFF";
                    lblTakedownStatus.ForeColor = Color.Red;
                }
            }
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            memory.Dispose();
        }
    }
}
