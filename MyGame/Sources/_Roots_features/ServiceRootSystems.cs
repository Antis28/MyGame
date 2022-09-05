using MyGame.Sources.Services;

namespace MyGame.Sources.Systems
{
    public class ServiceRootSystems : Feature
    {
        public ServiceRootSystems(Contexts contexts, ServicesRegister servicesRegister)
        {
            // Add(new RegisterViewServiceSystem(contexts, services.View));
            Add(new RegisterTimeServiceSystem(contexts, servicesRegister.Time));
            // Add(new RegisterApplicationServiceSystem(contexts, services.Application));
            // Add(new RegisterInputServiceSystem(contexts, services.Input));
            // Add(new RegisterAiServiceSystem(contexts, services.Ai));
            // Add(new RegisterConfigurationServiceSystem(contexts, services.Config));
            // Add(new RegisterCameraServiceSystem(contexts, services.Camera));
            // Add(new RegisterPhysicsServiceSystem(contexts, services.Physics));
            // Add(new ServiceRegistrationCompleteSystem(contexts));
            Add(new RegisterLogServiceSystem(contexts, servicesRegister.Log));
            Add(new RegisterMultiThreadServiceSystem(contexts, servicesRegister.MultiThread));
        }
    }
}
