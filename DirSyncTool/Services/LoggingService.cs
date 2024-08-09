using System;
using System.IO;

namespace DirSyncTool.Services
{
    public static class LoggingService
    {
        public static void Log(string message, string logFilePath)
        {
            string logMessage = $"{DateTime.Now}: {message}";
            Console.WriteLine(logMessage);
            File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
        }
    }
}
