using System;
using System.IO;
using System.Timers;
using System.Threading;
using DirSyncTool.Models;
using DirSyncTool.Utils;

namespace DirSyncTool.Services
{
    public class SyncService
    {
        private readonly SyncOptions _options;
        private System.Timers.Timer _timer;
        private readonly ManualResetEvent _resetEvent = new ManualResetEvent(false);

        public SyncService(SyncOptions options)
        {
            _options = options;
            _timer = new System.Timers.Timer();
        }

        public void StartSync()
        {
            _timer.Interval = _options.Interval * 1000;
            _timer.AutoReset = true;
            _timer.Elapsed += PerformSync;
            _timer.Start();

            PerformSync();

            Console.WriteLine("Synchronization started. Press '[CTRL] + C' to stop.");
            _resetEvent.WaitOne();
        }

        private void PerformSync()
        {
            PerformSync(this, null);
        }

        private void PerformSync(object? sender, ElapsedEventArgs? e)
        {
            Console.WriteLine($"Synchronization triggered at {DateTime.Now}");

            try
            {
                Console.WriteLine("Starting synchronization...");
                FileUtils.SyncFolders(_options.SourcePath, _options.ReplicaPath, _options.LogFilePath);
            }
            catch (Exception ex)
            {
                LoggingService.Log($"Error during synchronization: {ex.Message}", _options.LogFilePath);
            }
        }

        public void StopSync()
        {
            _timer.Stop();
            _timer.Dispose();
            _resetEvent.Set();
        }
    }
}
