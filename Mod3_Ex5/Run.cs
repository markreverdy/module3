namespace Mod3_Ex5
{
    class Run
    {
        static async Task Main(string[] args)
        {
            var result = ConcatenateContents();
            Console.WriteLine(result.Result);
        }

        static async Task<string> ReadHelloFileAsync()
        {
            using (StreamReader reader = new StreamReader("D:\\Desktop\\ProgramFiles\\Microsoft Visual Studio\\repos\\Module2_Ex5\\bin\\Debug\\net6.0\\Hello.txt"))
            {
                return await reader.ReadToEndAsync();
            }
        }

        static async Task<string> ReadWorldFileAsync()
        {
            using (StreamReader reader = new StreamReader("D:\\Desktop\\ProgramFiles\\Microsoft Visual Studio\\repos\\Module2_Ex5\\bin\\Debug\\net6.0\\World.txt"))
            {
                return await reader.ReadToEndAsync();
            }
        }

        static async Task<string> ConcatenateContents()
        {
            Task<string> helloTask = ReadHelloFileAsync();
            Task<string> worldTask = ReadWorldFileAsync();

            await Task.WhenAll(helloTask, worldTask);

            return helloTask.Result + worldTask.Result;
        }
    }
}