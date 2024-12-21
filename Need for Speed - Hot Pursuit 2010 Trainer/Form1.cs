using System.Timers;
using Memory;

namespace Need_for_Speed___Hot_Pursuit_2010_Trainer
{
    public partial class Form1 : Form
    {
        System.Timers.Timer timer;
        Mem m = new Mem();

        const string gameExeName = "NFS11";
        bool isAttached = false;
        int processId = 0;

        public Form1()
        {
            timer = new System.Timers.Timer(200);
            timer.Elapsed += timer_elapsed;
            timer.Start();

            InitializeComponent();
        }

        private void timer_elapsed(object? sender, ElapsedEventArgs e)
        {
            var pid = m.GetProcIdFromName(gameExeName);
            if (isAttached && pid == 0)
            {
                isAttached = false;
                // detached from process
            }

            if (isAttached && processId != pid)
            {
                // new instance of game found
                processId = pid;
                // inject related code and prepare trainer
            }

            if (!isAttached && pid != 0)
            {
                processId = pid;
                // inject related code and prepare trainer
            }
        }
    }
}
