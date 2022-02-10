using System;
using System.IO;
using NLog;

namespace CUM.Logger
{
    /// <summary>
    /// Static class that provides static methods for event logging
    /// </summary>
    public static class NLogger
    {
        /// <summary>
        /// Gets an instance inherited from ILogger
        /// </summary>
        public static ILogger Logger { get; }
        /// <summary>
        /// Gets the path to the logging folder
        /// </summary>
        public static string LogDirPath { get; }

        static NLogger()
        {
            LogDirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            if(!Directory.Exists(LogDirPath))
            {
                Directory.CreateDirectory(LogDirPath);
            }

            string logFilePath = Path.Combine(LogDirPath, $"{DateTime.Now:MM.dd.yyyy}.txt");

            var fileTarget = new NLog.Targets.FileTarget("CUM")
            {
                FileName = logFilePath,
                DeleteOldFileOnStartup = false,
                Layout = "${message}"
            };

            var logConfig = new NLog.Config.LoggingConfiguration();
            logConfig.AddRuleForAllLevels(fileTarget);
            LogManager.Configuration = logConfig;

            Logger = LogManager.GetLogger("CUM");
        }

        /// <summary>
        /// Logs a message with the specified text into a file at the <b>LogDirPath</b> path with the specified logging level.<br/> 
        /// The logging level is set to <b>Info</b> if it is not set.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="logLevel"></param>
        public static void Log(string message, LogLevel logLevel = null)
        {
            logLevel ??= LogLevel.Info;
            Logger.Log(logLevel, $"[{DateTime.Now:HH:mm:ss}] ({logLevel.Name}) {message}");
        }
    }
}
