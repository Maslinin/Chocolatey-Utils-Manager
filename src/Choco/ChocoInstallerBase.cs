using System;
using System.Diagnostics;

namespace CUM.Choco
{
    internal class ChocoInstallerBase
    {
        /// <summary>
        /// Returns a ProcessStartInfo instance which contains the parameters for starting the process
        /// </summary>
        internal ProcessStartInfo ProcessStartInfo { get; }

        /// <summary>
        /// Initializes a new instance ChocoBaseInstaller
        /// </summary>
        internal ChocoInstallerBase()
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

        /// <summary>
        /// Returns true if Chocolatey is set; otherwise false
        /// </summary>
        internal bool ChocoExists
        {
#pragma warning disable IDE0075 //Simplify conditional expression
            get => Environment.GetEnvironmentVariable("ChocolateyInstall") is null ? false : true;
#pragma warning restore IDE0075 //Simplify conditional expression
        }

        /// <summary>
        /// Installs Chocolatey if it is not installed
        /// </summary>
        /// <returns> Message written by process from stdout </returns>
        internal string InstallChoco()
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

        /// <summary>
        /// Installs a package using Chocolatey
        /// </summary>
        /// <param name="packageLinkName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns> Message written by process from stdout </returns>
        internal string InstallPackage(string packageLinkName)
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

        /// <summary>
        /// Updates the package using Chocolatey
        /// </summary>
        /// <param name="packageLinkName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns> Message written by process from stdout </returns>
        internal string UpdatePackage(string packageLinkName)
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

        /// <summary>
        /// Deletes a package using Chocolatey<br/>
        /// The optional "cancellationToken" parameter is needed only if this method is used in an asynchronous thread
        /// </summary>
        /// <param name="packageLinkName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns> Message written by process from stdout </returns>
        internal string UninstallPackage(string packageLinkName)
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
