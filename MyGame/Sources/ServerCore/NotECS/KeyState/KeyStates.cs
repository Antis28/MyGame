using KeyboardEmulator.ForPostMessage;

namespace MyGame.Sources.ServerCore.KeyState;

#region Nested Types

// Для PostMessage
//
internal struct MoveLeft : IKeyState
{
    public int VKey => (int)VirtualKeys.LEFT;

    public int Repeat => 1;
}
//
// internal struct MoveLeft10 : IKeyState
// {
//     public int VKey => (int)VirtualKeys.LEFT;
//     public int Repeat => 10;
// }
//
// internal struct MoveRight : IKeyState
// {
//     public int VKey => (Int32)VirtualKeys.RIGHT;
//
//     public int Repeat => 1;
// }
//
// internal struct MoveRight10 : IKeyState
// {
//     public int VKey => (Int32)VirtualKeys.RIGHT;
//     public int Repeat => 10;
// }
//
// internal struct Shift : IKeyState
// {
//     public int VKey => (Int32)VirtualKeys.SHIFT;
//     public int Repeat => 1;
// }
//
// internal struct Mute : IKeyState
// {
//     public int VKey => (Int32)VirtualKeys.KEY_M;
//
//     public int Repeat => 1;
// }
//
// internal struct PageDown : IKeyState
// {
//     public int VKey => (Int32)VirtualKeys.NEXT;
//
//     public int Repeat => 1;
// }
//
// internal struct PageUp : IKeyState
// {
//     public int VKey => (Int32)VirtualKeys.PRIOR;
//
//     public int Repeat => 1;
// }
//
// internal struct PausePlay : IKeyState
// {
//     public int VKey => (Int32)VirtualKeys.SPACE;
//
//     public int Repeat => 1;
// }
//
// internal struct VolumeDown : IKeyState
// {
//     public int VKey => (Int32)VirtualKeys.DOWN;
//
//     public int Repeat => 1;
// }
//
// internal struct VolumeUp : IKeyState
// {
//     public int VKey => (Int32)VirtualKeys.UP;
//
//     public int Repeat => 1;
// }

#endregion
