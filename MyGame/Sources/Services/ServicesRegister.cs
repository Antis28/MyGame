// ReSharper disable once InvalidXmlDocComment
/// <summary>
// https://russianblogs.com/article/7030565561/
// Создание сервиса на примере сервиса логирования:
// 1) создать интерфейс ILogService в файле ServicesRegister
// 2) добавить в объявление коструктора класса ServicesRegister параметр ILogService log и назначить его в поле ILogService Log
// 3) реализовать интерфейс ILogService например в классе ConsoleLogService
// 4) инициализировать создав объект new ConsoleLogService() в классе Main в методе GetServices при создании объекта ServicesRegister
// 5) создать компонент  LogServiceComponent : IComponent с полем public ILogService instance; с атрибутом [Meta, Unique]
// 6) зарегистрировать создав систему RegisterLogServiceSystem : IInitializeSystem и вызвать в Initialize 
//     метод _metaContext.ReplaceLogService(_logService);
// 7) вызвать Add в ServiceRootSystems : Feature и передать вторым параметром servicesRegister.MultiThread
//
//     Окончательный результат состоит в том, что мы можем получить доступ к этим экземплярам службы глобально, 
//     через экземпляр Contexts (_context.meta.logService.instance). И мы создаем их только в одном месте.
/// </summary>
// ReSharper disable InconsistentNaming

namespace MyGame.Sources.Services
{
    public class ServicesRegister
    {
        // public readonly IInputService Input;
        // public readonly IAiService Ai;
        // public readonly IConfigurationService Config;
        // public readonly ICameraService Camera;
        // public readonly IPhysicsService Physics;
        public readonly ILogService Log;

        public readonly IMultiThreadService MultiThread;

        // public readonly IViewService View;
        // public readonly IApplicationService Application;
        public readonly ITimeService Time;

        public ServicesRegister(
            // IViewService view, 
            // IApplicationService application, 
            ITimeService time,
            // IInputService input, 
            // IAiService ai, 
            // IConfigurationService config, 
            // ICameraService camera, 
            // IPhysicsService physics,
            ILogService log,
            IMultiThreadService multiThread)
        {
            // View = view;
            // Application = application;
            Time = time;
            // Input = input;
            // Ai = ai;
            // Config = config;
            // Camera = camera;
            // Physics = physics;
            Log = log;
            MultiThread = multiThread;
        }
    }

    public interface IPhysicsService { }

    public interface ICameraService { }

    public interface IConfigurationService { }

    public interface IAiService { }

    public interface IInputService { }

    public interface ITimeService { }

    public interface IApplicationService { }

    public interface IViewService { }

    public interface ILogService
    {
        void LogMessage(string message, string sourceName);
    }

    public interface IMultiThreadService
    {
        int MaxThreadsCount { get; }
    }
}
