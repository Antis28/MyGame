using System;
using KeyboardEmulator;

namespace MyGame.Sources.ServerCore
{
    internal static class ButtonClicker
    {
        public static void MoveRightClick()
        {
            EmulateKeyDown(new MoveRight());
        }
        public static void MoveRight10Click()
        {
            EmulateKeyDown(new MoveRight10());
        }
        public static void MoveLeftClick()
        {
            EmulateKeyDown(new MoveLeft());
        }
        public static void MoveLeft10Click()
        {
            EmulateKeyDown(new MoveLeft10());
        }
        public static void MuteClick()
        {
            EmulateKeyDown(new Mute());
        }
        public static void PageDownClick()
        {
            EmulateKeyDown(new PageDown());
        }
        public static void PageUpClick()
        {
            EmulateKeyDown(new PageUp());
        }
        public static void PausePlayClick()
        {
            EmulateKeyDown(new PausePlay());
        }
        public static void VolumeDownClick()
        {
            EmulateKeyDown(new VolumeDown());
        }
        public static void VolumeUpClick()
        {
            EmulateKeyDown(new VolumeUp());
        }
        private static void EmulateKeyDown(KeyState state)
        {
            var procFinder = new ProcessFinder();
            var hWnd = procFinder.GetActivePrcesses();
            KeyEmul emul = new KeyEmul();

            for (int i = 0; i < state.Repeat; i++) { emul.PostClick(hWnd, state.VKey); }
        }


        private struct MoveRight : KeyState
        {
            public int VKey => (Int32)VirtualKeys.RIGHT;

            public int Repeat => 1;
        }

        private struct MoveRight10 : KeyState
        {
            public int VKey => (Int32)VirtualKeys.RIGHT;
            public int Repeat => 10;
        }

        private struct MoveLeft : KeyState
        {
            public int VKey => (int)VirtualKeys.LEFT;

            public int Repeat => 1;
        }

        private struct MoveLeft10 : KeyState
        {
            public int VKey => (int)VirtualKeys.LEFT;
            public new int Repeat => 10;
        }

        private struct Mute : KeyState
        {
            public int VKey => (Int32)VirtualKeys.KEY_M;

            public int Repeat => 1;
        }

        private struct PageDown : KeyState
        {
            public int VKey => (Int32)VirtualKeys.NEXT;

            public int Repeat => 1;
        }

        private struct PageUp : KeyState
        {
            public int VKey => (Int32)VirtualKeys.PRIOR;

            public int Repeat => 1;
        }

        private struct PausePlay : KeyState
        {
            public int VKey => (Int32)VirtualKeys.SPACE;

            public int Repeat => 1;
        }

        private struct VolumeDown : KeyState
        {
            public int VKey => (Int32)VirtualKeys.DOWN;

            public int Repeat => 1;
        }

        private struct VolumeUp : KeyState
        {
            public int VKey => (Int32)VirtualKeys.UP;

            public int Repeat => 1;
        }

        private interface KeyState
        {
            Int32 VKey { get; }
            int Repeat { get; }
        }
    }
}
