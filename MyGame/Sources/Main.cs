﻿using System.Threading;
using MyGame.Sources.ServerCore;
using MyGame.Sources.Services;
using MyGame.Sources.Systems;

namespace MyGame.Sources
{
    public class Main
    {
        private RootSystem _systems;

        public void Start()
        {
            new SleepMode();
            
            var context = Contexts.sharedInstance;

            var services = new ServiceRootSystems(context, GetServices());
            services.Initialize();

            _systems = new RootSystem(context);
            _systems.Initialize();

            // для unity3D поместить в Update 
            while (true)
            {
                _systems.Execute();
                Thread.Sleep(500);
            }
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
