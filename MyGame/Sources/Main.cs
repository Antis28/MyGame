using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ApiCrossConsole;
using DesperateDevs.Logging;
using MyGame.Sources.Services;
using MyGame.Sources.Systems;

namespace MyGame.Sources
{
    public class Main
    {
        private RootSystem _systems;

        public static IConsole Logger { get; set; }
        public static Contexts Context { get; set; }

        public async Task Start(IConsole logger)
        {
            Logger = logger;
            Logger.ShowMessage("Logger Up");
            Context = Contexts.sharedInstance;

            var services = new ServiceRootSystems(Context, GetServices());
            services.Initialize();

            _systems = new RootSystem(Context);
            _systems.Initialize();

            Context.game.CreateEntity().isLoadSettings = true;

            // SendAllDiscNames();

            // для unity3D поместить в Update 
            File.AppendAllText(@"C:\Users\Antis\Desktop\File1.txt", "before  while \n");
            while (true)
            {
                _systems.Execute();
               
                //await Task.Delay(500);               
                
                Thread.Sleep(500);
            }
        }


        private static ServicesRegister GetServices()
        {
            return new ServicesRegister(
                new MyTimeService(),
                new ConsoleLogService(Logger),
                new MultiThreadService()
            //     new UnityViewService(),        // responsible for creating gameobjects for views
            //     new UnityApplicationService(), // gives app functionality like .Quit()
            //     new UnityTimeService(),        // gives .deltaTime, .fixedDeltaTime etc
            //     new InControlInputService(),   // provides user input
            //     // next two are monobehaviours attached to gamecontroller
            //     GetComponent<UnityAiService>(),            // async steering calculations on MB
            //     GetComponent<UnityConfigurationService>(), // editor accessable global config
            //     new UnityCameraService(),                  // camera bounds, zoom, fov, orthsize etc
            //     new UnityPhysicsService()                  // raycast, checkcircle, checksphere etc.
            );
        }
    }
}
