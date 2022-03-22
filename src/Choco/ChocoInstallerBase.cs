using System;
using System.Text;
using System.Management.Automation.Runspaces;
using System.Management.Automation;

namespace CUM.Choco
{
    public class ChocoInstallerBase : IChoco
    {
        /// <summary>
        /// Initializes a new instance ChocoBaseInstaller
        /// </summary>
        public ChocoInstallerBase() { }

        public bool ChocoExists
        {
            get => Environment.GetEnvironmentVariable("ChocolateyInstall") is not null;
        }

        public string InstallChoco()
        {
            string script = "Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))";

            return ChocoInstallerBase.RunScript(script);
        }

        public string InstallPackage(string packageLinkName)
        {
            string script = $"choco install {packageLinkName} -y -f";

            return ChocoInstallerBase.RunScript(script);
        }

        public string UpdatePackage(string packageLinkName)
        {
            string script = $"choco upgrade {packageLinkName} -y -f";

            return ChocoInstallerBase.RunScript(script);
        }

        public string UninstallPackage(string packageLinkName)
        {
            string script = $"choco uninstall {packageLinkName} -y -f";

            return ChocoInstallerBase.RunScript(script);
        }

        private static string RunScript(string script)
        {
            var stdoutMessage = new StringBuilder();

            using (var runspace = RunspaceFactory.CreateRunspace())
            {
                runspace.Open();

                using (var pipeline = runspace.CreatePipeline())
                {
                    pipeline.Commands.AddScript(script);
                    pipeline.Commands.Add("Out-String");

                    var results = pipeline.Invoke();
                    runspace.Close();

                    foreach (var obj in results)
                    {
                        stdoutMessage.AppendLine(obj.ToString());
                    }
                }
            }

            return stdoutMessage.ToString();
        }
    }
}
