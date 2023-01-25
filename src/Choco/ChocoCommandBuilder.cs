using System.Text;

namespace CUM.Choco
{
    internal class ChocoCommandBuilder
    {
        private readonly StringBuilder _command = new StringBuilder().Append(Constants.Choco.CommandName).Append(' ');

        public string Get => this._command.ToString();
        
        public ChocoCommandBuilder AddChocoCommand()
        {
            this._command.Append(Constants.Choco.CommandName);
            return this;
        }

        public ChocoCommandBuilder AddInstallCommand()
        {
            this._command.Append(Constants.Choco.InstallCommandName).Append(' ');
            return this;
        }

        public ChocoCommandBuilder AddUpgradeCommand()
        {
            this._command.Append(Constants.Choco.UpgradeCommandName).Append(' ');
            return this;
        }

        public ChocoCommandBuilder AddUninstallCommand() 
        {
            this._command.Append(Constants.Choco.UninstallCommandName).Append(' ');
            return this;
        }

        public ChocoCommandBuilder AddPackageRefName(string packageRefName)
        {
            this._command.Append(packageRefName).Append(' ');
            return this;
        }

        public ChocoCommandBuilder AddConfirmFlag()
        {
            this._command.Append(Constants.Choco.ConfirmFlag).Append(' ');
            return this;
        }

        public ChocoCommandBuilder AddForceFlag() 
        {
            this._command.Append(Constants.Choco.ForceFlag).Append(' ');
            return this;
        }
    }
}
