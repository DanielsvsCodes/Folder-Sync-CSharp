# Folder Sync

Folder Sync is a C# command-line application designed to synchronize two directories: a source directory and a replica directory. The tool ensures that the replica directory mirrors the content of the source directory by periodically copying, updating, or deleting files as needed. Synchronization is one-way, meaning changes are only propagated from the source to the replica.

## Features

- One-way Synchronization: The replica folder is updated to exactly match the content of the source folder.
- Periodic Synchronization: Synchronization occurs periodically at intervals specified by the user.
- Logging: All file operations (creation, copying, and deletion) are logged to both a file and the console.
- Command-line Configuration: Folder paths, synchronization intervals, and log file paths are provided via command-line arguments.
- Directory Creation Prompt: If the specified source or replica directory does not exist, the user is prompted to create it.
- No Third-party Libraries: The synchronization logic is implemented using .NET's built-in libraries.

## Requirements

- .NET SDK (version 5.0 or later)
- Windows, macOS, or Linux

## Getting Started

1. Clone the Repository:
```
git clone https://github.com/DanielsvsCodes/Folder-Sync-CSharp.git
cd DirSyncTool
```

2. Build the Project:
```
dotnet build
```

3. Running the Application:
   
You can run the application directly from the command line by specifying the source directory, replica directory, synchronization interval (in seconds), and log file path.
```
dotnet run -- "<sourcePath>" "<replicaPath>" <intervalInSeconds> "<logFilePath>"
```
Example used for testing:
```
dotnet run -- "..\SourceFolder" "..\ReplicaFolder" 30 "..\sync.log"
```
- `<sourcePath>`: The path to the source directory.
- `<replicaPath>`: The path to the replica directory.
- `<intervalInSeconds>`: The synchronization interval in seconds (e.g., 60 for every 60 seconds).
- `<logFilePath>`: The path to the log file where operations are recorded.

4. Handling Non-Existent Directories:

If the specified source or replica directory does not exist, the program will prompt you to create it:
```
Source directory 'C:\Invalid\SourcePath' does not exist. Would you like to create it? (y/n):
```
- If you type y, the directory will be created, and the program will proceed.
- If you type n, the program will exit, as the directory is required for synchronization.

5. Stopping the Application:

The application will continue running, performing synchronization at the specified interval. To stop the application, press [CTRL] + C in the terminal where the application is running.

## Project Structure

- DirSyncTool/Models: Contains the SyncOptions class, which stores command-line options.
- DirSyncTool/Services: Contains the SyncService class, which handles the synchronization logic and LoggingService, which handles logging.
- DirSyncTool/Utils: Contains the FileUtils class, which performs the file operations.
- Program.cs: The entry point of the application, where command-line arguments are parsed and the synchronization service is started.

## Logging

All operations, such as file copying, updating, and deleting, are logged to both the console and the specified log file. The log file provides a history of synchronization operations, which can be useful for troubleshooting.

## Troubleshooting

- Application Exits Immediately: Ensure that the paths are correctly specified and that the interval is set appropriately. The application should remain running until you manually stop it.
- No Files Are Copied: Ensure that the source directory contains files and that the paths are accessible. Also, ensure that the interval is set correctly.
- Log File Not Created: Ensure that the log file path is valid and that the application has write permissions for the specified directory.
