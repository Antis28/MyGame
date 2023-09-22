using System;
using System.Collections.Generic;
using Entitas;
using MyGame.Sources.ServerCore;
using MyGame.Sources.ServerCore.NotECS;

namespace MyGame.Sources.Systems
{
//Регистрировать в классе производном от Feature

    /// <summary>
    /// Когда было прочитано сообщение, обработать его
    /// </summary>
    public sealed class ConverterMessagesSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;
        private readonly Dictionary<string, Action<ArgumentAction>> _keyCommands;

        public ConverterMessagesSystem(Contexts contexts) : base(contexts.game)
        {
            var navigator = new PlayerNavigator();
            _contexts = contexts;
            
                _keyCommands = new Dictionary<string, Action<ArgumentAction>>
            {
                // навигация для Player
                { "Right x 10", navigator.MoveRight10Click },
                { "Left x 10", navigator.MoveLeft10Click },
                { "Right", navigator.MoveRightClick },
                { "Left", navigator.MoveLeftClick },
                { "Space", navigator.PausePlayClick },
                { "Volume +", navigator.VolumeUpClick },
                { "Volume -", navigator.VolumeDownClick },
                { "Mute", navigator.MuteClick },
                {
                    "PageDown",
                    navigator.NextClick
                },
                {
                    "PageUp",
                    navigator.PreviousClick
                },

                // навигация управления питанием
                //{ "Hibernate", SleepMode.GoHibernateMode },
                { "StandBy", SleepMode.GoStandbyMode },

                // навигация управления браузером файлов
                { "GetFileSystem", FileBrowserHandler.SendFileSystemInJson },
                { "ExecutableFile", FileBrowserHandler.ExecutableFile },

                // Другое
                { "SaveName", LastMovieRepository.SaveFilePathFromPotPlayer },
                { "LoadLastMovie", LastMovieRepository.LoadLastMovie },
                { "Hibernate", TimerShutdown.test },
                { "SkipOpenning", AnilibriaPlayer.Skip },
            };
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Message);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasMessage;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (!entity.hasMessage) { return; }


                var message = entity.message.value;
                var command = message.Command;

                var argument = new ArgumentAction
                {
                    Argument = message.Argument,
                    Command = message.Command,
                    Port = entity.message.portClient,
                    Ip = entity.message.ipClient
                };


                if (_keyCommands.ContainsKey(command))
                {
                    var actionCommand = _keyCommands[command];
                    actionCommand(argument);
                }
                else { throw new ArgumentException("Сообщение от клиента не распознано"); }
            }
        }
    }
}
