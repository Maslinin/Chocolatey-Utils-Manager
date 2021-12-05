using System;
using System.Diagnostics;

namespace CUM.Chocolatey
{
    internal class ChocoBaseInstaller
    {
        internal string PSPath { get; set; } = $@"{Environment.SystemDirectory}\WindowsPowerShell\v1.0\powershell.exe";

        internal ChocoBaseInstaller() { }

        internal bool ChocoExists
        {
            get => Environment.GetEnvironmentVariable("ChocolateyInstall") != null ? true : false;
        }

        internal void ChocoInstall()
        {
            string install = "Set-ExecutionPolicy Bypass -Scope Process -Force -Verb RunAs; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))";
            var chocoInstall = new Process();

            chocoInstall.StartInfo.RedirectStandardInput = true;
            chocoInstall.StartInfo.RedirectStandardOutput = true;
            chocoInstall.StartInfo.UseShellExecute = false;
            chocoInstall.StartInfo.CreateNoWindow = true;
            chocoInstall.StartInfo.LoadUserProfile = true;
            chocoInstall.StartInfo.Verb = "runAs";
            chocoInstall.StartInfo.FileName = PSPath;
            chocoInstall.Start();

            chocoInstall.StandardInput.WriteLine(install);
            chocoInstall.StandardInput.Flush();
            chocoInstall.StandardInput.Close();
            chocoInstall.WaitForExit();
        }

        internal void InstallPackage(string packageLinkName)
        {
            var chocoInstall = new Process();

            chocoInstall.StartInfo.RedirectStandardInput = true;
            chocoInstall.StartInfo.RedirectStandardOutput = true;
            chocoInstall.StartInfo.UseShellExecute = false;
            chocoInstall.StartInfo.CreateNoWindow = true;
            chocoInstall.StartInfo.LoadUserProfile = true;
            chocoInstall.StartInfo.Verb = "runAs";
            chocoInstall.StartInfo.FileName = PSPath;
            chocoInstall.Start();

            chocoInstall.StandardInput.WriteLine($"choco install {packageLinkName} -y");
            chocoInstall.StandardInput.Flush();
            chocoInstall.StandardInput.Close();
            chocoInstall.WaitForExit();
        }

        internal void UpdatePackage(string packageLinkName)
        {
            var chocoInstall = new Process();

            chocoInstall.StartInfo.RedirectStandardInput = true;
            chocoInstall.StartInfo.RedirectStandardOutput = true;
            chocoInstall.StartInfo.UseShellExecute = false;
            chocoInstall.StartInfo.CreateNoWindow = true;
            chocoInstall.StartInfo.LoadUserProfile = true;
            chocoInstall.StartInfo.Verb = "runAs";
            chocoInstall.StartInfo.FileName = PSPath;
            chocoInstall.Start();

            chocoInstall.StandardInput.WriteLine($"choco update {packageLinkName} -y");
            chocoInstall.StandardInput.Flush();
            chocoInstall.StandardInput.Close();
            chocoInstall.WaitForExit();
        }

        internal void DeletePackage(string packageLinkName)
        {
            var chocoInstall = new Process();

            chocoInstall.StartInfo.RedirectStandardInput = true;
            chocoInstall.StartInfo.RedirectStandardOutput = true;
            chocoInstall.StartInfo.UseShellExecute = false;
            chocoInstall.StartInfo.CreateNoWindow = true;
            chocoInstall.StartInfo.Verb = "runAs";
            chocoInstall.StartInfo.FileName = PSPath;
            chocoInstall.Start();

            chocoInstall.StandardInput.WriteLine($"choco uninstall {packageLinkName} -y");
            chocoInstall.StandardInput.Flush();
            chocoInstall.StandardInput.Close();
            chocoInstall.WaitForExit();
        }
    }
}
