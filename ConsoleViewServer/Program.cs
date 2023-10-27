using System;
using System.IO;
using System.Threading.Tasks;
using CrossConsole;
using MessageObjects;
using Newtonsoft.Json;
using File = System.IO.File;

namespace ConsoleViewServer
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Task t = null;
            var logger = ConsoleCreator.CreateForDotNetFramework();
            // var logger = ConsoleCreator.CreateForService();
            // TestJsonSettings();
            try
            {
                t = new MyGame.Sources.Main().Start(logger);
            }
            catch (Exception e)
            {

                logger.ShowError(e);
            }
            t.Wait();
        }

        private static void TestJsonSettings()
        {
            var path = Environment.CurrentDirectory + @"\command settings.json";
            // deserialize JSON directly from a file

            var text = File.ReadAllText(path);
            var commandSettings = JsonConvert.DeserializeObject<CommandsSettings>(text, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            //var commandSettings = JsonConvert.DeserializeObject<CommandsSettings>(text);

            var jsString = JsonConvert.SerializeObject(commandSettings, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.Auto,
            });
            using (var sw = new StreamWriter(path)) { sw.Write(jsString); }
        }
    }
}
