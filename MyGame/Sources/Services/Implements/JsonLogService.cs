namespace MyGame.Sources.Services
{
    public class JsonLogService : ILogService
    {
        string filepath;
        string filename;

        bool prettyPrint;

        // etc...
        public void LogMessage(string message)
        {
            // open file
            // parse contents
            // write new contents
            // close file
        }
    }
}
