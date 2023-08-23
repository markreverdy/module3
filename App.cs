using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod3_Ex7
{
    public class App
    {
        private Logger logger;

        public App(Logger logger)
        {
            this.logger = logger;
            this.logger.OnBackupRequired += async () => await this.logger.BackupAsync();
        }

        public async Task RunAsync()
        {
            Task task1 = LogMessagesAsync(50);
            Task task2 = LogMessagesAsync(50);

            await Task.WhenAll(task1, task2);
        }

        private async Task LogMessagesAsync(int numMessages)
        {
            for (int i = 0; i < numMessages; i++)
            {
                await logger.LogAsync($"Log Entry {i + 1}");
            }
        }
    }
}
