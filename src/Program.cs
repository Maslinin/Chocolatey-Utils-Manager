using System.Windows.Forms;

namespace ChocolateyUtilsManager
{
    internal static class Program
    {
        [System.STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
