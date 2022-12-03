using KeyboardEmulator;
using MyGame.Sources.ServerCore.KeyState;
using MyGame.Sources.ServerCore.KeyStateCode;

namespace MyGame.Sources.ServerCore.NotECS.KeyState;

internal static class KeyEmulator
{
    public static void EmulateKeyPress(IKeyState state)
    {
        var procFinder = new ProcessFinder();
        var hWnd = procFinder.GetActiveProcesses();
        KeyEmul emul = new KeyEmul();

        for (int i = 0; i < state.Repeat; i++) { emul.PostClick(hWnd, state.VKey); }
    }

    public static void EmulateSendKey(IKeyStateCode state1, IKeyStateCode state2)
    {
        KeyEmul emul = new KeyEmul();

        for (int i = 0; i < state1.Repeat; i++)
        {
            emul.SendInput(state1.VKey, state2.VKey);
        }
    }
}
