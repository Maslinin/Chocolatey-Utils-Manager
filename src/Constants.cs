using System;
using System.IO;

namespace ChocolateyUtilsManager
{
    internal static class Constants
    {
        public static class IO
        {
            public static string PackageListPath => Path.Combine(AppFolder, PackageListFileName);
            public static string AppFolder => AppDomain.CurrentDomain.BaseDirectory;
            public static string PackageListFileName => "PackageList.json";
        }

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

        public static class Option
        {
            public static string Install => "Install";
            public static string Upgrade => "Upgrad"; //No last letter, since the word ending will change depending on the state of the process (time)
            public static string Uninstall => "Uninstall";
        }
    }
}
