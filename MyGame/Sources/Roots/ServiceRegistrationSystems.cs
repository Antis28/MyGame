// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using MyGame.Sources.Services;

namespace MyGame.Sources.Systems
{
    public class ServiceRegistrationSystems : Feature
    {
        public ServiceRegistrationSystems(Contexts contexts, Services.Services services)
        {
            // Add(new RegisterViewServiceSystem(contexts, services.View));
             Add(new RegisterTimeServiceSystem(contexts, services.Time));
            // Add(new RegisterApplicationServiceSystem(contexts, services.Application));
            // Add(new RegisterInputServiceSystem(contexts, services.Input));
            // Add(new RegisterAiServiceSystem(contexts, services.Ai));
            // Add(new RegisterConfigurationServiceSystem(contexts, services.Config));
            // Add(new RegisterCameraServiceSystem(contexts, services.Camera));
            // Add(new RegisterPhysicsServiceSystem(contexts, services.Physics));
            // Add(new ServiceRegistrationCompleteSystem(contexts));
        }
    }
}
