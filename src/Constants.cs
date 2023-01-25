using System;
using System.IO;

namespace CUM
{
    internal static class Constants
    {
        public static string PackageListPath => Path.Combine(AppFolder, PackageListFileName);
        public static string AppFolder => AppDomain.CurrentDomain.BaseDirectory;
        public static string PackageListFileName => "PackageList.json";

        public static class Choco
        {
            public static string CommandName => "choco";
            public static string InstallCommandName => "install";
            public static string UpgradeCommandName => "upgrade";
            public static string UninstallCommandName => "uninstall";
            public static string ConfirmFlag => "-y";
            public static string ForceFlag => "-f";
            public static string EnvVarName => "ChocolateyInstall";
            public static string ChocoInstall => "Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))";
        }

        public static class States
        {

        }
    }
}
