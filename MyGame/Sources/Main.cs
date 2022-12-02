using System;
using System.Net.Sockets;
using System.Threading;
using MyGame.Sources.Services;
using MyGame.Sources.Systems;
using CrossConsole;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace MyGame.Sources
{
    public class Main
    {
        private RootSystem _systems;

        public void Start()
        {
            var context = Contexts.sharedInstance;

            var services = new ServiceRootSystems(context, GetServices());
            services.Initialize();

            _systems = new RootSystem(context);
            _systems.Initialize();

            context.game.CreateEntity().isLoadSettings = true;

            // SendAllDiscNames();

            // для unity3D поместить в Update 
            while (true)
            {
                _systems.Execute();
                Thread.Sleep(500);
            }
        }

        // private void SendAllDiscNames()
        // {
        //     DriveInfo[] allDrives = DriveInfo.GetDrives();
        //     string output = JsonConvert.SerializeObject(allDrives);
        //     var res =
        //         from driveInfo in allDrives
        //         where driveInfo.DriveType.ToString() == "Fixed"
        //         select $"{driveInfo.VolumeLabel} ({driveInfo.Name}) ";
        //
        //     Print(res.ToArray());
        //     var t = Directory.GetDirectories(allDrives[0].Name);
        //     Print(t);
        // }

        private void Print(string text)
        {
            ConsoleCreator.CreateForDotNetFramework().ShowMessage(text);
        }

        private void Print(params string[] texts)
        {
            foreach (var text in texts) { Print(Path.GetFileName(text)); }
        }

        private void Print(params object[] objects)
        {
            foreach (var text in objects) { Print(text.ToString()); }
        }

        private static ServicesRegister GetServices()
        {
            return new ServicesRegister(
                new MyTimeService(),
                new ConsoleLogService(),
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
