using System;
using System.Windows.Forms;
using System.Security;
using System.Diagnostics;

namespace CUM.Chocolatey
{
    internal class ChocoBase
    {
        internal string ChocolatePath { get; set; } = @"C:\Program Files\Internet Explorer\iexplore.exe";
        internal string PSPath { get; set; } = $@"{Environment.SystemDirectory}\WindowsPowerShell\v1.0\powershell.exe";

        public ChocoBase()
        {
            
        }

        internal void ChocoInstall()
        {
            string install = "Set-ExecutionPolicy Bypass -Scope Process -Force -Verb RunAs; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))";
            var chocoInstall = new Process();

            chocoInstall.StartInfo.RedirectStandardInput = true;
            chocoInstall.StartInfo.RedirectStandardOutput = true;
            chocoInstall.StartInfo.UseShellExecute = false;
            chocoInstall.StartInfo.CreateNoWindow = true;
            chocoInstall.StartInfo.Verb = "runAs";
            chocoInstall.StartInfo.FileName = PSPath;
            chocoInstall.Start();

            chocoInstall.StandardInput.WriteLine(install);
            chocoInstall.StandardInput.Flush();
            chocoInstall.StandardInput.Close();
            chocoInstall.WaitForExit();

            MessageBox.Show(chocoInstall.StandardOutput.ReadToEnd(),
                "Successful installation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        internal void InstallPackage(string packageLinkName)
        {
            var chocoInstall = new Process();

            chocoInstall.StartInfo.RedirectStandardInput = true;
            chocoInstall.StartInfo.RedirectStandardOutput = true;
            chocoInstall.StartInfo.UseShellExecute = false;
            chocoInstall.StartInfo.CreateNoWindow = true;
            chocoInstall.StartInfo.Verb = "runAs";
            chocoInstall.StartInfo.FileName = PSPath;
            //chocoInstall.StartInfo.LoadUserProfile = true;
            chocoInstall.Start();

            chocoInstall.StandardInput.WriteLine($"choco install {packageLinkName} -y");
            chocoInstall.StandardInput.Flush();
            chocoInstall.StandardInput.Close();
            chocoInstall.WaitForExit();

            MessageBox.Show(chocoInstall.StandardOutput.ReadToEnd(),
                "Successful installation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        internal void UpdatePackage(string packageLinkName)
        {
            var chocoInstall = new Process();

            chocoInstall.StartInfo.RedirectStandardInput = true;
            chocoInstall.StartInfo.RedirectStandardOutput = true;
            chocoInstall.StartInfo.UseShellExecute = false;
            chocoInstall.StartInfo.CreateNoWindow = true;
            chocoInstall.StartInfo.Verb = "runAs";
            chocoInstall.StartInfo.FileName = PSPath;
            chocoInstall.Start();

            chocoInstall.StandardInput.WriteLine($"choco update {packageLinkName} -y");
            chocoInstall.StandardInput.Flush();
            chocoInstall.StandardInput.Close();
            chocoInstall.WaitForExit();

            MessageBox.Show(chocoInstall.StandardOutput.ReadToEnd(),
                "Successful update",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
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

            MessageBox.Show(chocoInstall.StandardOutput.ReadToEnd(),
                "Successful uninstall",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        internal bool ChocoExists()
        {
            return Environment.GetEnvironmentVariable("ChocolateyInstall") != null ? true : false;
        }
    }
}
