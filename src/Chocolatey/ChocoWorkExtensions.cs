using System.Diagnostics;

namespace CUM.Chocolatey
{
    static class ChocoWorkExtensions
    {
        internal static void SetHighPriorityToChocoProcesses(this ChocoBaseInstaller _)
        {
            var processes = Process.GetProcessesByName("choco");

            if (processes.Length != 0)
                foreach (var process in processes)
                {
                    process.PriorityClass = ProcessPriorityClass.High;
                }
        }

    }
}
