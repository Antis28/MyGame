// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace MyGame.Sources.Services
{
    public class Services
    {
        public readonly IViewService View;
        public readonly IApplicationService Application;
        public readonly ITimeService Time;
        public readonly IInputService Input;
        public readonly IAiService Ai;
        public readonly IConfigurationService Config;
        public readonly ICameraService Camera;
        public readonly IPhysicsService Physics;

        public Services(IViewService view, IApplicationService application, ITimeService time, IInputService input, IAiService ai, IConfigurationService config, ICameraService camera, IPhysicsService physics)
        {
            View = view;
            Application = application;
            Time = time;
            Input = input;
            Ai = ai;
            Config = config;
            Camera = camera;
            Physics = physics;
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
}
