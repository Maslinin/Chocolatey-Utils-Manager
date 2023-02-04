using System.Text;
using static CUM.Constants.Choco;

namespace CUM.Choco
{
    internal class ChocoCommandBuilder
    {
        private readonly StringBuilder _command = new StringBuilder()
            .Append(CommandName)
            .Append(' ');

        public string Get => this._command.ToString();
        
        public ChocoCommandBuilder AddChocoCommand()
        {
            this._command.Append(CommandName);
            return this;
        }

        public ChocoCommandBuilder AddInstallCommand()
        {
            this._command.Append(InstallCommandName).Append(' ');
            return this;
        }

        public ChocoCommandBuilder AddUpgradeCommand()
        {
            this._command.Append(UpgradeCommandName).Append(' ');
            return this;
        }

        public ChocoCommandBuilder AddUninstallCommand() 
        {
            this._command.Append(UninstallCommandName).Append(' ');
            return this;
        }

        public ChocoCommandBuilder AddPackageRefName(string packageRefName)
        {
            this._command.Append(packageRefName).Append(' ');
            return this;
        }

        public ChocoCommandBuilder AddConfirmFlag()
        {
            this._command.Append(ConfirmFlag).Append(' ');
            return this;
        }

        public ChocoCommandBuilder AddForceFlag() 
        {
            this._command.Append(ForceFlag).Append(' ');
            return this;
        }
    }
}
