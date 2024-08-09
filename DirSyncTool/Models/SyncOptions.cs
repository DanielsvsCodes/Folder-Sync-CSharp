namespace DirSyncTool.Models
{
    public class SyncOptions
    {
        public string SourcePath { get; set; } = string.Empty;
        public string ReplicaPath { get; set; } = string.Empty;
        public int Interval { get; set; }
        public string LogFilePath { get; set; } = string.Empty;
    }
}
