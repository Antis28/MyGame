using System.Threading;
using System.Threading.Tasks;
namespace MyGame.Sources
{
    public class Main
    {
        private RootSystem _systems;

        public void Start()
        {
            var context = Contexts.sharedInstance;
            _systems = new RootSystem(context);
            _systems.Initialize();

            while (true)
            {
                _systems.Execute(); 
                Thread.Sleep(100);
            }
        }
    }
}
