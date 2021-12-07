using System;
using System.Diagnostics;

namespace CUM.Chocolatey
{
    internal class ChocoBaseInstaller
    {
        internal string PSPath { get; private set; } = $@"{Environment.SystemDirectory}\WindowsPowerShell\v1.0\powershell.exe";

        internal ProcessStartInfo ProcessStartInfo { get; private set; }

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
                FileName = PSPath
            };
        }

        internal bool ChocoExists
        {
            get => Environment.GetEnvironmentVariable("ChocolateyInstall") == null ? false : true;
        }

        internal void ChocoInstall()
        {
            string install = "Set-ExecutionPolicy Bypass -Scope Process -Force -Verb RunAs; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))";

            var chocoInstall = new Process { StartInfo = ProcessStartInfo };

            chocoInstall.Start();
            chocoInstall.PriorityClass = ProcessPriorityClass.High;

            chocoInstall.StandardInput.WriteLine(install);
            chocoInstall.StandardInput.Flush();
            chocoInstall.StandardInput.Close();
            chocoInstall.WaitForExit();
        }

        internal void InstallPackage(string packageLinkName)
        {
            var chocoInstall = new Process { StartInfo = ProcessStartInfo };

            chocoInstall.Start();
            chocoInstall.PriorityClass = ProcessPriorityClass.High;

            chocoInstall.StandardInput.WriteLine($"choco install {packageLinkName} -y -f");
            chocoInstall.StandardInput.Flush();
            chocoInstall.StandardInput.Close();
            chocoInstall.WaitForExit();
        }

        internal void UpdatePackage(string packageLinkName)
        {
            var chocoInstall = new Process { StartInfo = ProcessStartInfo };

            chocoInstall.Start();
            chocoInstall.PriorityClass = ProcessPriorityClass.High;

            chocoInstall.StandardInput.WriteLine($"choco update {packageLinkName} -y -f");
            chocoInstall.StandardInput.Flush();
            chocoInstall.StandardInput.Close();
            chocoInstall.WaitForExit();
        }

        internal void UninstallPackage(string packageLinkName)
        {
            var chocoInstall = new Process { StartInfo = ProcessStartInfo };

            chocoInstall.Start();
            chocoInstall.PriorityClass = ProcessPriorityClass.High;

            chocoInstall.StandardInput.WriteLine($"choco uninstall {packageLinkName} -y -f");
            chocoInstall.StandardInput.Flush();
            chocoInstall.StandardInput.Close();
            chocoInstall.WaitForExit();
        }
    }
}
