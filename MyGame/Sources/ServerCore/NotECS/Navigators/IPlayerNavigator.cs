namespace MyGame.Sources.ServerCore;

internal interface IPlayerNavigator
{
    void MoveRightClick(ArgumentAction _);
    void MoveRight10Click(ArgumentAction _);
    void MoveLeftClick(ArgumentAction _);
    void MoveLeft10Click(ArgumentAction _);
    void MuteClick(ArgumentAction _);
    void NextClick(ArgumentAction _);
    void PreviousClick(ArgumentAction _);
    void PausePlayClick(ArgumentAction _);
    void VolumeDownClick(ArgumentAction _);
    void VolumeUpClick(ArgumentAction _);
}