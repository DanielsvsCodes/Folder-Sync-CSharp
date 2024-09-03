# Folder Sync

## Overview

Folder Sync is a C# command-line application designed to synchronize two directories: a source directory and a replica directory. The tool ensures that the replica directory mirrors the content of the source directory by periodically copying, updating, or deleting files as needed. Synchronization is one-way, meaning changes are only propagated from the source to the replica.

## Technologies Used

- **C#**: The core programming language used for developing the application.
- **.NET SDK (version 5.0 or later)**: Framework for building and running the application.
- **Command-Line Interface (CLI)**: For providing user input and configuration.
- **Built-in .NET Libraries**: Used for file system operations and logging.

## How It Works

Folder Sync performs one-way synchronization between a source and a replica directory:

- **One-way Synchronization**: The replica folder is updated to exactly match the content of the source folder.
- **Periodic Synchronization**: Synchronization occurs periodically at intervals specified by the user.
- **Logging**: All file operations (creation, copying, and deletion) are logged to both a file and the console.
- **Command-line Configuration**: Folder paths, synchronization intervals, and log file paths are provided via command-line arguments.
- **Directory Creation Prompt**: If the specified source or replica directory does not exist, the user is prompted to create it.
- **No Third-party Libraries**: The synchronization logic is implemented using .NET's built-in libraries.

## Project Structure

```plaintext
Folder-Sync/
├── DirSyncTool/
│   ├── Models/
│   │   └── SyncOptions.cs
│   ├── Services/
│   │   ├── SyncService.cs
│   │   └── LoggingService.cs
│   ├── Utils/
│   │   └── FileUtils.cs
│   └── Program.cs
├── bin/
├── obj/
├── LICENSE
├── README.md
└── FolderSync.sln
```

## Prerequisites

- **.NET SDK (version 5.0 or later)**: Make sure the .NET SDK is installed and available in your system PATH.
- **Operating System**: Windows, macOS, or Linux.

## Getting Started

### Step 1: Clone the Repository

```bash
git clone https://github.com/DanielsvsCodes/Folder-Sync-CSharp.git
cd Folder-Sync
```

### Step 2: Build the Project

Build the project using the .NET CLI:

```bash
dotnet build
```

### Step 3: Running the Application

Run the application from the command line by specifying the source directory, replica directory, synchronization interval (in seconds), and log file path:

```bash
dotnet run -- "<sourcePath>" "<replicaPath>" <intervalInSeconds> "<logFilePath>"
```

Example:

```bash
dotnet run -- "..\SourceFolder" "..\ReplicaFolder" 30 "..\sync.log"
```

- +<sourcePath>+: The path to the source directory.
- +<replicaPath>+: The path to the replica directory.
- +<intervalInSeconds>+: The synchronization interval in seconds (e.g., 60 for every 60 seconds).
- +<logFilePath>+: The path to the log file where operations are recorded.

### Step 4: Handling Non-Existent Directories

If the specified source or replica directory does not exist, the program will prompt you to create it:

```plaintext
Source directory 'C:\Invalid\SourcePath' does not exist. Would you like to create it? (y/n):
```

- If you type `y`, the directory will be created, and the program will proceed.
- If you type `n`, the program will exit, as the directory is required for synchronization.

### Step 5: Stopping the Application

The application will continue running, performing synchronization at the specified interval. To stop the application, press `[CTRL] + C` in the terminal where the application is running.

## Logging

All operations, such as file copying, updating, and deleting, are logged to both the console and the specified log file. The log file provides a history of synchronization operations, which can be useful for troubleshooting.

## Troubleshooting

- **Application Exits Immediately**: Ensure that the paths are correctly specified and that the interval is set appropriately. The application should remain running until you manually stop it.
- **No Files Are Copied**: Ensure that the source directory contains files and that the paths are accessible. Also, ensure that the interval is set correctly.
- **Log File Not Created**: Ensure that the log file path is valid and that the application has write permissions for the specified directory.
