using System.Timers;
using MemoryDll;

namespace Need_for_Speed___Hot_Pursuit_2010_Trainer
{
    public partial class MainForm : Form
    {
        System.Timers.Timer timer;
        Mem m = new Mem();

        const string gameExeName = "NFS11";
        bool isAttached = false;
        int processId = 0;

        public MainForm()
        {
            timer = new System.Timers.Timer(200);
            timer.Elapsed += timer_elapsed;
            timer.Start();

            InitializeComponent();

            this.ResetTrainer();
        }

        private void timer_elapsed(object? sender, ElapsedEventArgs e)
        {
            var pid = m.GetProcIdFromName(gameExeName);
            if (isAttached && pid == 0)
            {
                this.ResetTrainer();
            }

            if (
                (isAttached && processId != pid) ||
                (!isAttached && pid != 0)
            )
            {
                processId = pid;
                this.PrepareForCodeInjection();
            }
        }

        private void ResetTrainer()
        {
            isAttached = false;
            processId = 0;
        }

        private void PrepareForCodeInjection()
        {

        }
    }
}
