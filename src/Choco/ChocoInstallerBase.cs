using System;
using System.Text;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

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
#pragma warning disable IDE0075 //Simplify conditional expression
            get => Environment.GetEnvironmentVariable("ChocolateyInstall") is null ? false : true;
#pragma warning restore IDE0075 //Simplify conditional expression
        }
        
        public string InstallChoco()
        {
            string script = "Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))";
            var stdoutMessage = new StringBuilder();

            using (var runspace = RunspaceFactory.CreateRunspace())
            {
                runspace.Open();
                var pipeline = runspace.CreatePipeline();
                pipeline.Commands.AddScript(script);
                pipeline.Commands.Add("Out-String");

                var results = pipeline.Invoke();
                runspace.Close();

                foreach (PSObject obj in results)
                {
                    stdoutMessage.AppendLine(obj.ToString());
                }
            }

            return stdoutMessage.ToString();
        }

        public string InstallPackage(string packageLinkName)
        {
            string script = $"choco install {packageLinkName} -y -f";
            var stdoutMessage = new StringBuilder();

            using (var runspace = RunspaceFactory.CreateRunspace())
            {
                runspace.Open();
                var pipeline = runspace.CreatePipeline();
                pipeline.Commands.AddScript(script);
                pipeline.Commands.Add("Out-String");

                var results = pipeline.Invoke();
                runspace.Close();

                foreach (PSObject obj in results)
                {
                    stdoutMessage.AppendLine(obj.ToString());
                }
            }

            return stdoutMessage.ToString();
        }

        public string UpdatePackage(string packageLinkName)
        {
            string script = $"choco upgrade {packageLinkName} -y -f";
            var stdoutMessage = new StringBuilder();

            using (var runspace = RunspaceFactory.CreateRunspace())
            {
                runspace.Open();
                var pipeline = runspace.CreatePipeline();
                pipeline.Commands.AddScript(script);
                pipeline.Commands.Add("Out-String");

                var results = pipeline.Invoke();
                runspace.Close();

                foreach (PSObject obj in results)
                {
                    stdoutMessage.AppendLine(obj.ToString());
                }
            }

            return stdoutMessage.ToString();
        }

        public string UninstallPackage(string packageLinkName)
        {
            string script = $"choco uninstall {packageLinkName} -y -f";
            var stdoutMessage = new StringBuilder();

            using (var runspace = RunspaceFactory.CreateRunspace())
            {
                runspace.Open();
                var pipeline = runspace.CreatePipeline();
                pipeline.Commands.AddScript(script);
                pipeline.Commands.Add("Out-String");

                var results = pipeline.Invoke();
                runspace.Close();

                foreach (PSObject obj in results)
                {
                    stdoutMessage.AppendLine(obj.ToString());
                }
            }

            return stdoutMessage.ToString();
        }
    }
}
