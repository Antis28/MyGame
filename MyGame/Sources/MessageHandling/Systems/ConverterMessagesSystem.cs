using System;
using System.Collections.Generic;
using Entitas;
using MyGame.Sources.ServerCore;

namespace MyGame.Sources.Systems
{
//Регистрировать в классе производном от Feature
    /// <summary>
    /// Когда было прочитано сообщение, обработать его
    /// </summary>
    public sealed class ConverterMessagesSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;
        private readonly Dictionary<string, Action> _keyCommands;

        public ConverterMessagesSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
            _keyCommands = new Dictionary<string, Action>()
            {
                { "Right x 10", ButtonClicker.MoveRight10Click },
                { "Left x 10", ButtonClicker.MoveLeft10Click },
                { "Right", ButtonClicker.MoveRightClick },
                { "Left", ButtonClicker.MoveLeftClick },
                { "Space", ButtonClicker.PausePlayClick },
                { "Volume +", ButtonClicker.VolumeUpClick },
                { "Volume -", ButtonClicker.VolumeDownClick },
                { "Mute", ButtonClicker.MuteClick },
                { "PageDown", ButtonClicker.PageDownClick },
                { "PageUp", ButtonClicker.PageUpClick },
                { "Hibernate", SleepMode.GoHibernateMode },
                { "StandBy", SleepMode.GoStandbyMode },
                { "SaveName", CreateSettingsEntity },
            };
        }

        private static void CreateSettingsEntity()
        {
            var procFinder = new KeyboardEmulator.ProcessFinder();
            var process = procFinder.GetActiveProcess();

            var saveEntity = Contexts.sharedInstance.game.CreateEntity();
            saveEntity.ReplaceSettings(process.MainWindowTitle);
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
                if (_keyCommands.ContainsKey(message))
                {
                    var actionCommand = _keyCommands[message];
                    actionCommand();
                }
                else { throw new ArgumentException("Сообщение от клиента не распознано"); }
            }
        }
    }
}
