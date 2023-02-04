using System;
using System.Threading.Tasks;
using System.Management.Automation.Runspaces;

namespace CUM.Choco
{
    public sealed class ChocoManager : IChocoManager
    {
        private readonly Runspace _runspace;

        public ChocoManager()
        {
            this._runspace = RunspaceFactory.CreateRunspace();
            this._runspace.Open();
        }

        public bool ChocoExists
        {
            get => Environment.GetEnvironmentVariable(Constants.Choco.EnvVarName) is not null;
        }

        public async Task InstallChoco()
        {
            if (!this.ChocoExists)
            {
                string script = Constants.Choco.ChocoInstall;
                await RunScript(script);
            }
        }

        public async Task InstallPackage(string packageRefName)
        {
            if (this.ChocoExists)
            {
                string script = new ChocoCommandBuilder().AddInstallCommand().AddPackageRefName(packageRefName).AddConfirmFlag().AddForceFlag().Get;
                await RunScript(script);
            }
        }

        public async Task UpgradePackage(string packageRefName)
        {
            if (this.ChocoExists)
            {
                string script = new ChocoCommandBuilder().AddUpgradeCommand().AddPackageRefName(packageRefName).AddConfirmFlag().AddForceFlag().Get;
                await RunScript(script);
            }
        }

        public async Task UninstallPackage(string packageRefName)
        {
            if (this.ChocoExists)
            {
                string script = new ChocoCommandBuilder().AddUninstallCommand().AddPackageRefName(packageRefName).AddConfirmFlag().AddForceFlag().Get;
                await RunScript(script);
            }
        }

        private async Task RunScript(string script)
        {
            await Task.Run(() =>
            {
                using var pipeline = this._runspace.CreatePipeline();
                pipeline.Commands.AddScript(script);
                pipeline.Commands.Add("Out-String");

                pipeline.Invoke();
            });
        }

        public void Dispose()
        {
            this._runspace.Close();
            this._runspace.Dispose();
        }
    }
}