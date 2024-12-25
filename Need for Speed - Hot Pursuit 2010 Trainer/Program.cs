using System.Diagnostics;

namespace Need_for_Speed___Hot_Pursuit_2010_Trainer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var processName = Path.GetFileNameWithoutExtension(Environment.ProcessPath);
            if (Process.GetProcessesByName(processName).Length > 1)
            {
                MessageBox.Show("Only one instance of the program may be running at a time", Cheats.NFSHP_Constants.FormTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}