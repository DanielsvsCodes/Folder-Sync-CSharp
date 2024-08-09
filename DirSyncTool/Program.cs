using System;
using System.IO;
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

            EnsureDirectoryExists(options.SourcePath, "Source");
            EnsureDirectoryExists(options.ReplicaPath, "Replica");

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

        static void EnsureDirectoryExists(string path, string name)
        {
            if (!Directory.Exists(path))
            {
                Console.WriteLine($"{name} directory '{path}' does not exist. Would you like to create it? (y/n):");
                var response = Console.ReadLine();

                if (response?.ToLower() == "y")
                {
                    Directory.CreateDirectory(path);
                    Console.WriteLine($"{name} directory created at '{path}'.");
                }
                else
                {
                    Console.WriteLine($"Exiting: {name} directory is required.");
                    Environment.Exit(0);
                }
            }

            if (Directory.Exists(path))
            {
                Console.WriteLine($"{name} directory confirmed at '{path}'.");
            }
            else
            {
                Console.WriteLine($"Error: {name} directory could not be created at '{path}'.");
                Environment.Exit(0);
            }
        }
    }
}
