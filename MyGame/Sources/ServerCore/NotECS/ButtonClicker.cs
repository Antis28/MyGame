using KeyboardEmulator;
using MyGame.Sources.ServerCore.KeyState;
using MyGame.Sources.ServerCore.KeyStateCode;

namespace MyGame.Sources.ServerCore
{
    internal static partial class ButtonClicker
    {
        public static void MoveRightClick()
        {
            EmulateKeyPress(new MoveRight());
        }

        public static void MoveRight10Click()
        {
            EmulateSendKey(new PressShift(), new PressPageDown() );
        }

        public static void MoveLeftClick()
        {
            EmulateKeyPress(new MoveLeft());
        }

        public static void MoveLeft10Click()
        {
            EmulateSendKey(new PressShift(), new PressPageUp());
        }

        public static void MuteClick()
        {
            EmulateKeyPress(new Mute());
        }

        public static void PageDownClick()
        {
            EmulateKeyPress(new PageDown());
        }

        public static void PageUpClick()
        {
            EmulateKeyPress(new PageUp());
        }

        public static void PausePlayClick()
        {
            EmulateKeyPress(new PausePlay());
        }

        public static void VolumeDownClick()
        {
            EmulateKeyPress(new VolumeDown());
        }

        public static void VolumeUpClick()
        {
            EmulateKeyPress(new VolumeUp());
        }

        private static void EmulateKeyPress(IKeyState state)
        {
            var procFinder = new ProcessFinder();
            var hWnd = procFinder.GetActiveProcesses();
            KeyEmul emul = new KeyEmul();

            for (int i = 0; i < state.Repeat; i++) { emul.PostClick(hWnd, state.VKey); }
        }

        private static void EmulateSendKey(IKeyStateCode state1, IKeyStateCode state2)
        {
            KeyEmul emul = new KeyEmul();

            for (int i = 0; i < state1.Repeat; i++)
            {
                emul.SendInput(state1.VKey, state2.VKey);
            }
        }

       
    }
}
