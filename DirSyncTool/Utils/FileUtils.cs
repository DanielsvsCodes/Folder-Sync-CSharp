using System;
using System.IO;
using DirSyncTool.Services;

namespace DirSyncTool.Utils
{
    public static class FileUtils
    {
        public static void SyncFolders(string sourcePath, string replicaPath, string logFilePath)
        {
            if (!string.IsNullOrEmpty(replicaPath))
            {
                Directory.CreateDirectory(replicaPath);
            }
            else
            {
                throw new ArgumentNullException(nameof(replicaPath), "Replica path cannot be null or empty.");
            }

            foreach (var filePath in Directory.GetFiles(sourcePath, "*", SearchOption.AllDirectories))
            {
                string relativePath = filePath.Substring(sourcePath.Length + 1);
                string replicaFilePath = Path.Combine(replicaPath, relativePath);

                string? directoryPath = Path.GetDirectoryName(replicaFilePath);

                if (!string.IsNullOrEmpty(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                else
                {
                    throw new ArgumentNullException(nameof(directoryPath), $"The directory path for '{replicaFilePath}' could not be determined.");
                }

                File.Copy(filePath, replicaFilePath, true);
                LoggingService.Log($"Copied/Updated: {replicaFilePath}", logFilePath);
            }

            foreach (var replicaFilePath in Directory.GetFiles(replicaPath, "*", SearchOption.AllDirectories))
            {
                string relativePath = replicaFilePath.Substring(replicaPath.Length + 1);
                string sourceFilePath = Path.Combine(sourcePath, relativePath);

                if (!File.Exists(sourceFilePath))
                {
                    File.Delete(replicaFilePath);
                    LoggingService.Log($"Deleted: {replicaFilePath}", logFilePath);
                }
            }

            foreach (var sourceDirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                string relativeDirPath = sourceDirPath.Substring(sourcePath.Length + 1);
                string replicaDirPath = Path.Combine(replicaPath, relativeDirPath);

                if (!Directory.Exists(replicaDirPath))
                {
                    Directory.CreateDirectory(replicaDirPath);
                    LoggingService.Log($"Created directory: {replicaDirPath}", logFilePath);
                }
            }

            foreach (var replicaDirPath in Directory.GetDirectories(replicaPath, "*", SearchOption.AllDirectories))
            {
                string relativeDirPath = replicaDirPath.Substring(replicaPath.Length + 1);
                string sourceDirPath = Path.Combine(sourcePath, relativeDirPath);

                if (!Directory.Exists(sourceDirPath))
                {
                    Directory.Delete(replicaDirPath, true);
                    LoggingService.Log($"Deleted directory: {replicaDirPath}", logFilePath);
                }
            }
        }
    }
}
