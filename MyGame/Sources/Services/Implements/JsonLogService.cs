#pragma warning disable CS0169
namespace MyGame.Sources.Services
{
    public class JsonLogService : ILogService
    {
        private string _filepath;
        private string _filename;

        private bool _prettyPrint;

        // etc...
        public void LogMessage(string message)
        {
            // open file
            // parse contents
            // write new contents
            // close file
        }

        public void LogMessage(string message, string sourceName)
        {
            throw new System.NotImplementedException();
        }
    }
}
