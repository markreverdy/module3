using System;
using System.IO;
using System.Threading.Tasks;

namespace Mod3_Ex7
{
    public class Logger
    {
        private readonly object _lock = new object();
        private int logEntryCount = 0;
        private readonly int entriesBeforeBackup;
        public event Action OnBackupRequired;
        private readonly string logFilePath = "log.txt";
        private readonly string backupFolderPath = "Backup";

        public Logger(int entriesBeforeBackup)
        {
            this.entriesBeforeBackup = entriesBeforeBackup;
            Directory.CreateDirectory(backupFolderPath);
        }

        public async Task LogAsync(string message)
        {
            lock (_lock)
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now}: {message}");
                }

                logEntryCount++;

                if (logEntryCount >= entriesBeforeBackup)
                {
                    OnBackupRequired?.Invoke();
                }
            }
        }

        public async Task BackupAsync()
        {
            lock (_lock)
            {
                string backupFileName = $"{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                string backupFilePath = Path.Combine(backupFolderPath, backupFileName);

                // Check if file exists and modify the filename accordingly
                int counter = 1;
                while (File.Exists(backupFilePath))
                {
                    backupFileName = $"{DateTime.Now:yyyyMMdd_HHmmss}_{counter}.txt";
                    backupFilePath = Path.Combine(backupFolderPath, backupFileName);
                    counter++;
                }

                File.Copy(logFilePath, backupFilePath);

                logEntryCount = 0;
            }
        }
    }
}
