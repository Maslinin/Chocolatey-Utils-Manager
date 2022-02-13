using System;
using System.Diagnostics;

namespace CUM.Choco
{
    public class ChocoInstallerBase : IChoco
    {
        /// <summary>
        /// Gets a ProcessStartInfo instance which contains the parameters for starting the process
        /// </summary>
        public ProcessStartInfo ProcessStartInfo { get; }

        /// <summary>
        /// Initializes a new instance ChocoInstallerBase
        /// </summary>
        public ChocoInstallerBase()
        {
            ProcessStartInfo = new ProcessStartInfo
            {
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                LoadUserProfile = true,
                Verb = "runAs",
                FileName = $@"{Environment.SystemDirectory}\WindowsPowerShell\v1.0\powershell.exe"
            };
        }

        public bool ChocoExists
        {
#pragma warning disable IDE0075 //Simplify conditional expression
            get => Environment.GetEnvironmentVariable("ChocolateyInstall") is null ? false : true;
#pragma warning restore IDE0075 //Simplify conditional expression
        }

        public string InstallChoco()
        {
            string install = "Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))";

            string stdoutMessage = string.Empty;
            using (var chocoInstall = new Process { StartInfo = ProcessStartInfo })
            {
                if (!chocoInstall.Start())
                    throw new InvalidOperationException($"process {chocoInstall.Id} is failed");

                chocoInstall.PriorityClass = ProcessPriorityClass.High;
                chocoInstall.PriorityBoostEnabled = true;

                chocoInstall.StandardInput.WriteLine(install);
                chocoInstall.StandardInput.Flush();
                chocoInstall.StandardInput.Close();

                chocoInstall.WaitForExit();

                stdoutMessage = chocoInstall.StandardOutput.ReadToEnd();
                chocoInstall.Close();
            }

            return stdoutMessage;
        }

        public string InstallPackage(string packageLinkName)
        {
            string stdoutMessage = string.Empty;
            using (var chocoInstall = new Process { StartInfo = ProcessStartInfo })
            {
                if (!chocoInstall.Start())
                    throw new InvalidOperationException($"process {chocoInstall.Id} is failed: {packageLinkName}");

                chocoInstall.PriorityClass = ProcessPriorityClass.High;
                chocoInstall.PriorityBoostEnabled = true;

                chocoInstall.StandardInput.WriteLine($"choco install {packageLinkName} -y");
                chocoInstall.StandardInput.Flush();
                chocoInstall.StandardInput.Close();

                chocoInstall.WaitForExit();

                stdoutMessage = chocoInstall.StandardOutput.ReadToEnd();
                chocoInstall.Close();
            }

            return stdoutMessage;
        }

        public string UpdatePackage(string packageLinkName)
        {
            string stdoutMessage = string.Empty;
            using (var chocoInstall = new Process { StartInfo = ProcessStartInfo })
            {
                if (!chocoInstall.Start())
                    throw new InvalidOperationException($"process {chocoInstall.Id} is failed: {packageLinkName}");

                chocoInstall.PriorityClass = ProcessPriorityClass.High;
                chocoInstall.PriorityBoostEnabled = true;

                chocoInstall.StandardInput.WriteLine($"choco upgrade {packageLinkName} -y");
                chocoInstall.StandardInput.Flush();
                chocoInstall.StandardInput.Close();

                chocoInstall.WaitForExit();

                stdoutMessage = chocoInstall.StandardOutput.ReadToEnd();
                chocoInstall.Close();
            }

            return stdoutMessage;
        }

        public string UninstallPackage(string packageLinkName)
        {
            string stdoutMessage = string.Empty;
            using (var chocoInstall = new Process { StartInfo = ProcessStartInfo } )
            {
                if (!chocoInstall.Start())
                    throw new InvalidOperationException($"process {chocoInstall.Id} is failed: {packageLinkName}");

                chocoInstall.PriorityClass = ProcessPriorityClass.High;
                chocoInstall.PriorityBoostEnabled = true;

                chocoInstall.StandardInput.WriteLine($"choco uninstall {packageLinkName} -y");
                chocoInstall.StandardInput.Flush();
                chocoInstall.StandardInput.Close();

                chocoInstall.WaitForExit();

                stdoutMessage = chocoInstall.StandardOutput.ReadToEnd();
                chocoInstall.Close();
            }

            return stdoutMessage;
        }
    }
}
