using System;
using DirSyncTool.Services;
using DirSyncTool.Models;

namespace DirSyncTool
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = ParseArguments(args);

            if (options == null)
            {
                Console.WriteLine("Usage: DirSyncTool <sourcePath> <replicaPath> <intervalInSeconds> <logFilePath>");
                return;
            }

            var syncService = new SyncService(options);

            syncService.StartSync();
        }

        static SyncOptions? ParseArguments(string[] args)
        {
            if (args.Length < 4)
            {
                return null;
            }

            return new SyncOptions
            {
                SourcePath = args[0],
                ReplicaPath = args[1],
                Interval = int.TryParse(args[2], out int interval) ? interval : 60,
                LogFilePath = args[3]
            };
        }
    }
}
