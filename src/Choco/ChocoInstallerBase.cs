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
        internal ChocoInstallerBase() { }

        public bool ChocoExists
        {
#pragma warning disable IDE0075 //Simplify conditional expression
            get => Environment.GetEnvironmentVariable("ChocolateyInstall") is null ? false : true;
#pragma warning restore IDE0075 //Simplify conditional expression
        }
        
        /// <summary>
        /// Installs Chocolatey if it is not installed
        /// </summary>
        /// <returns> Message written by process from stdout </returns>
        ///
        internal string InstallChoco()
        {
            string install = "Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))";

            var runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();

            var pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(install);
            pipeline.Commands.Add("Out-String");

            var results = pipeline.Invoke();
            runspace.Close();

            var stringBuilder = new StringBuilder();
            foreach (PSObject obj in results)
            {
                stringBuilder.AppendLine(obj.ToString());
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Installs a package using Chocolatey
        /// </summary>
        /// <param name="packageLinkName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns> Message written by process from stdout </returns>
        internal string InstallPackage(string packageLinkName)
        {
            string install = $"choco install {packageLinkName} -y -f";

            var runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();

            var pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(install);
            pipeline.Commands.Add("Out-String");

            var results = pipeline.Invoke();
            runspace.Close();

            var stringBuilder = new StringBuilder();
            foreach (PSObject obj in results)
            {
                stringBuilder.AppendLine(obj.ToString());
            }

            return stringBuilder.ToString();
        }

        public string UpdatePackage(string packageLinkName)
        {
            string install = $"choco upgrade {packageLinkName} -y -f";

            var runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();

            var pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(install);
            pipeline.Commands.Add("Out-String");

            var results = pipeline.Invoke();
            runspace.Close();

            var stringBuilder = new StringBuilder();
            foreach (PSObject obj in results)
            {
                stringBuilder.AppendLine(obj.ToString());
            }

            return stringBuilder.ToString();
        }

        public string UninstallPackage(string packageLinkName)
        {
            string install = $"choco uninstall {packageLinkName} -y -f";

            var runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();

            var pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(install);
            pipeline.Commands.Add("Out-String");

            var results = pipeline.Invoke();
            runspace.Close();

            var stringBuilder = new StringBuilder();
            foreach (PSObject obj in results)
            {
                stringBuilder.AppendLine(obj.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}
