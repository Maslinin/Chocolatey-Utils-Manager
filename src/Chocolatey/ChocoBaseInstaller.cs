using System;
using System.Diagnostics;
using System.Threading;

namespace CUM.Chocolatey
{
    internal class ChocoBaseInstaller
    {
        internal ProcessStartInfo ProcessStartInfo { get; }
        internal string PSPath { get; } = $@"{Environment.SystemDirectory}\WindowsPowerShell\v1.0\powershell.exe";

        internal ChocoBaseInstaller()
        {
            ProcessStartInfo = new ProcessStartInfo
            {
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                Verb = "runAs",
                FileName = PSPath
            };
        }

        internal bool ChocoExists
        {
#pragma warning disable IDE0075 //Simplify conditional expression
            get => Environment.GetEnvironmentVariable("ChocolateyInstall") == null ? false : true;
#pragma warning restore IDE0075 //Simplify conditional expression
        }

        internal void ChocoInstall()
        {
            string install = "Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))";

            var chocoInstall = new Process { StartInfo = ProcessStartInfo };

            if (!chocoInstall.Start())
                throw new InvalidOperationException($"{chocoInstall.Id} - process error");

            chocoInstall.PriorityClass = ProcessPriorityClass.High;
            chocoInstall.PriorityBoostEnabled = true;

            chocoInstall.StandardInput.WriteLine(install);
            chocoInstall.StandardInput.Flush();
            chocoInstall.StandardInput.Close();

            chocoInstall.WaitForExit();
            chocoInstall.Close();
        }

        internal void InstallPackage(string packageLinkName, CancellationToken ? token = null)
        {
            if((bool)token?.IsCancellationRequested)
                token?.ThrowIfCancellationRequested();

            var chocoInstall = new Process { StartInfo = ProcessStartInfo };

            if (!chocoInstall.Start())
                throw new InvalidOperationException($"{chocoInstall.Id} - {packageLinkName} - process error");

            chocoInstall.PriorityClass = ProcessPriorityClass.High;
            chocoInstall.PriorityBoostEnabled = true;

            chocoInstall.StandardInput.WriteLine($"choco install {packageLinkName} -y -f");
            chocoInstall.StandardInput.Flush();
            chocoInstall.StandardInput.Close();

            chocoInstall.WaitForExit();
            chocoInstall.Close();
        }

        internal void UpdatePackage(string packageLinkName, CancellationToken ? token = null)
        {
            if ((bool)token?.IsCancellationRequested)
                token?.ThrowIfCancellationRequested();

            var chocoInstall = new Process { StartInfo = ProcessStartInfo };

            if (!chocoInstall.Start())
                throw new InvalidOperationException($"{chocoInstall.Id} - {packageLinkName} - process error");

            chocoInstall.PriorityClass = ProcessPriorityClass.High;
            chocoInstall.PriorityBoostEnabled = true;

            chocoInstall.StandardInput.WriteLine($"choco update {packageLinkName} -y -f");
            chocoInstall.StandardInput.Flush();
            chocoInstall.StandardInput.Close();

            chocoInstall.WaitForExit();
            chocoInstall.Close();
        }

        internal void UninstallPackage(string packageLinkName, CancellationToken ? token = null)
        {
            if ((bool)token?.IsCancellationRequested)
                token?.ThrowIfCancellationRequested();

            var chocoInstall = new Process { StartInfo = ProcessStartInfo };

            if (!chocoInstall.Start())
                throw new InvalidOperationException($"{chocoInstall.Id} - {packageLinkName} - process error");

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
