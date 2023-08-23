namespace Mod3_Ex7
{
    class Action
    {
        public static async Task Main(string[] args)
        {
            string configFilePath = "config.json";
            Config config = Config.ReadFromJsonFile(configFilePath);

            Logger logger = new Logger(config.N);
            App app = new App(logger);

            await app.RunAsync();
        }
    }
}