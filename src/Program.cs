using System.Windows.Forms;

namespace CUM
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [System.STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Installer.Installer());
        }
    }
}
