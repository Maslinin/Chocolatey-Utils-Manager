using System;
using System.Diagnostics;
using System.Threading;

namespace CUM.Choco
{
    internal class ChocoBaseInstaller
    {
        /// <summary>
        /// Returns a ProcessStartInfo instance which contains the parameters for starting the process
        /// </summary>
        internal ProcessStartInfo ProcessStartInfo { get; }

        /// <summary>
        /// Initializes a new instance ChocoBaseInstaller
        /// </summary>
        internal ChocoBaseInstaller()
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
            get => Environment.GetEnvironmentVariable("ChocolateyInstall") == null ? false : true;
#pragma warning restore IDE0075 //Simplify conditional expression
        }

        /// <summary>
        /// Installs Chocolatey if it is not installed
        /// </summary>
        internal void ChocoInstall()
        {
            string install = "Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))";

            var chocoInstall = new Process { StartInfo = ProcessStartInfo };
            if (!chocoInstall.Start())
                throw new InvalidOperationException($"process {chocoInstall.Id} is failed");

            chocoInstall.PriorityClass = ProcessPriorityClass.High;
            chocoInstall.PriorityBoostEnabled = true;

            chocoInstall.StandardInput.WriteLine(install);
            chocoInstall.StandardInput.Flush();
            chocoInstall.StandardInput.Close();

            chocoInstall.WaitForExit();
            chocoInstall.Close();
        }

        /// <summary>
        /// Installs a package using Chocolatey<br/>
        /// The optional "cancellationToken" parameter is needed only if current method is used in an asynchronous thread
        /// </summary>
        /// <param name="packageLinkName"></param>
        /// <param name="cancellationToken"></param>
        internal void InstallPackage(string packageLinkName, CancellationToken ? cancellationToken = null)
        {
            if(cancellationToken?.IsCancellationRequested ?? false)
                cancellationToken?.ThrowIfCancellationRequested();

            var chocoInstall = new Process { StartInfo = ProcessStartInfo };
            if (!chocoInstall.Start())
                throw new InvalidOperationException($"process {chocoInstall.Id} is failed: {packageLinkName}");

            chocoInstall.PriorityClass = ProcessPriorityClass.High;
            chocoInstall.PriorityBoostEnabled = true;

            chocoInstall.StandardInput.WriteLine($"choco install {packageLinkName} -y -f");
            chocoInstall.StandardInput.Flush();
            chocoInstall.StandardInput.Close();

            chocoInstall.WaitForExit();
            chocoInstall.Close();
        }

        /// <summary>
        /// Updates the package using Chocolatey<br/>
        /// The optional "cancellationToken" parameter is needed only if this method is used in an asynchronous thread
        /// </summary>
        /// <param name="packageLinkName"></param>
        /// <param name="cancellationToken"></param>
        internal void UpdatePackage(string packageLinkName, CancellationToken ? cancellationToken = null)
        {
            if (cancellationToken?.IsCancellationRequested ?? false)
                cancellationToken?.ThrowIfCancellationRequested();

            var chocoInstall = new Process { StartInfo = ProcessStartInfo };
            if (!chocoInstall.Start())
                throw new InvalidOperationException($"process {chocoInstall.Id} is failed: {packageLinkName}");

            chocoInstall.PriorityClass = ProcessPriorityClass.High;
            chocoInstall.PriorityBoostEnabled = true;

            chocoInstall.StandardInput.WriteLine($"choco update {packageLinkName} -y -f");
            chocoInstall.StandardInput.Flush();
            chocoInstall.StandardInput.Close();

            chocoInstall.WaitForExit();
            chocoInstall.Close();
        }

        /// <summary>
        /// Deletes a package using Chocolatey<br/>
        /// The optional "cancellationToken" parameter is needed only if this method is used in an asynchronous thread
        /// </summary>
        /// <param name="packageLinkName"></param>
        /// <param name="cancellationToken"></param>
        internal void UninstallPackage(string packageLinkName, CancellationToken ? cancellationToken = null)
        {
            if (cancellationToken?.IsCancellationRequested ?? false)
                cancellationToken?.ThrowIfCancellationRequested();

            var chocoInstall = new Process { StartInfo = ProcessStartInfo };
            if (!chocoInstall.Start())
                throw new InvalidOperationException($"process {chocoInstall.Id} is failed: {packageLinkName}");

            chocoInstall.PriorityClass = ProcessPriorityClass.High;
            chocoInstall.PriorityBoostEnabled = true;

            chocoInstall.StandardInput.WriteLine($"choco uninstall {packageLinkName} -y -f");
            chocoInstall.StandardInput.Flush();
            chocoInstall.StandardInput.Close();

            chocoInstall.WaitForExit();
            chocoInstall.Close();
        }
    }
}
