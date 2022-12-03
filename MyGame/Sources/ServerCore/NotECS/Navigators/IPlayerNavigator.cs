using MyGame.Sources.ServerCore.KeyState;
using MyGame.Sources.ServerCore.KeyStateCode;

namespace MyGame.Sources.ServerCore;

internal interface IPlayerNavigator
{
    public void MoveRight();
    public void MoveRight10();
    public void MoveLeft();
    public void MoveLeft10();
    public void Mute();
    public void Next();
    public void Previous();
    public void PausePlay();
    public void VolumeDown();
    public void VolumeUp();
}