using System;
using KeyboardEmulator;

namespace MyGame.Sources.ServerCore
{
    internal class KeyProvider
    {
        public KeyState State { get; set; }

        public KeyProvider(string response)
        {
            MessageToBeheviour(response);
            if (State == null)
                throw new ArgumentException("Сообщение не распознано");
        }

        /// <summary>
        /// Конвертирует сообщение в объект
        /// </summary>
        /// <param name="response"></param>
        private void MessageToBeheviour(string response)
        {
            switch (response)
            {
                case "Right x 10":
                    State = new MoveRight10();
                    break;
                case "Left x 10":
                    State = new MoveLeft10();
                    break;
                case "Right":
                    State = new MoveRight();
                    break;
                case "Left":
                    State = new MoveLeft();
                    break;
                case "Space":
                    State = new PausePlay();
                    break;
                case "Volume +":
                    State = new VolumeUp();
                    break;
                case "Volume -":
                    State = new VolumeDown();
                    break;
                case "Mute":
                    State = new Mute();
                    break;
                case "PageDown":
                    State = new PageDown();
                    break;
                case "PageUp":
                    State = new PageUp();
                    break;
            }
        }

        internal void PostClick()
        {
            var procFinder = new ProcessFinder();
            var hWnd = procFinder.GetActivePrcesses();
            KeyEmul emul = new KeyEmul();

            for (int i = 0; i < State.Repeat; i++) { emul.PostClick(hWnd, State.VKey); }
        }
    }
    
    internal interface KeyState
    {
        Int32 VKey { get; }
        int Repeat { get; }
    }
}
