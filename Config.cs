using System.IO;
using Newtonsoft.Json;

namespace Mod3_Ex7
{
    public class Config
    {
        public int N { get; set; }

        public static Config ReadFromJsonFile(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Config>(json);
        }
    }
}
