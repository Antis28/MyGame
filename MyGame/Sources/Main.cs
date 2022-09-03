using System.Threading;
using System.Threading.Tasks;
namespace MyGame.Sources
{
    public class Main
    {
        private RootSystem _systems;

        public void Start()
        {
            // var _services = new Services(
            //     new UnityViewService(),        // responsible for creating gameobjects for views
            //     new UnityApplicationService(), // gives app functionality like .Quit()
            //     new UnityTimeService(),        // gives .deltaTime, .fixedDeltaTime etc
            //     new InControlInputService(),   // provides user input
            //     // next two are monobehaviours attached to gamecontroller
            //     GetComponent<UnityAiService>(),            // async steering calculations on MB
            //     GetComponent<UnityConfigurationService>(), // editor accessable global config
            //     new UnityCameraService(),                  // camera bounds, zoom, fov, orthsize etc
            //     new UnityPhysicsService()                  // raycast, checkcircle, checksphere etc.
            // );
            
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
