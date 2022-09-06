using System;
using KeyboardEmulator;

namespace MyGame.Sources.ServerCore
{
    internal class MoveRight : KeyState
    {
        public int VKey => (Int32)VirtualKeys.RIGHT;

        public int Repeat => 1;
    }
    internal class MoveRight10 : KeyState
    {
        public int VKey => (Int32)VirtualKeys.RIGHT;

        public int Repeat => 10;
    }
    internal class MoveLeft : KeyState
    {
        public int VKey => (int)VirtualKeys.LEFT;

        public int Repeat => 1;
    }
    internal class MoveLeft10 : MoveLeft
    {
        public new int Repeat => 10;
    }
    internal class Mute : KeyState
    {
        public int VKey => (Int32)VirtualKeys.KEY_M;

        public int Repeat => 1;
    }
    internal class PageDown : KeyState
    {
        public int VKey => (Int32)VirtualKeys.NEXT;

        public int Repeat => 1;
    }
    internal class PageUp : KeyState
    {
        public int VKey => (Int32)VirtualKeys.PRIOR;

        public int Repeat => 1;
    }
    internal class PausePlay : KeyState
    {
        public int VKey => (Int32)VirtualKeys.SPACE;

        public int Repeat => 1;
    }
    internal class VolumeDown : KeyState
    {
        public int VKey => (Int32)VirtualKeys.DOWN;

        public int Repeat => 1;
    }
    internal class VolumeUp : KeyState
    {
        public int VKey => (Int32)VirtualKeys.UP;

        public int Repeat => 1;
    }
}
