using System.IO;
using System.ServiceProcess;
using System.Threading.Tasks;
using ApiCrossConsole;

namespace AtlantisService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected async override void OnStart(string[] args)
        {
            var logger = ConsoleCreator.CreateForService();
            new MyGame.Sources.Main().Start(logger);
            while (true)
            {
                File.AppendAllText(@"C:\Users\Antis\Desktop\File1.txt", "Test ");
                await Task.Delay(300);
            }
        }
    }
}
