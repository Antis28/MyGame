using KeyboardEmulator;
using KeyboardEmulator.ForSendInput;
using MyGame.Sources.ServerCore.KeyState;
using MyGame.Sources.ServerCore.KeyStateCode;

namespace MyGame.Sources.ServerCore.NotECS.KeyState;

internal static class KeyEmulator
{
    public static void EmulateKeyPress(IKeyState state)
    {
        var procFinder = new ProcessFinder();
        var hWnd = procFinder.GetActiveProcesses();
        var emul = new KeyEmul();

        for (int i = 0; i < state.Repeat; i++) { emul.PostClick(hWnd, state.VKey); }
    }

    public static void EmulateSendKey(IKeyStateCode state1, IKeyStateCode state2)
    {
        var emul = new KeyEmul();
        emul.SendInput(state1.VKey, state2.VKey);
    }
    public static void EmulateSendKey(IKeyStateCode state1)
    {
        var emul = new KeyEmul();

        for (int i = 0; i < state1.Repeat; i++)
        {
            emul.SendInput(state1.VKey);
        }
    }
    public static void EmulateSendKey(params IKeyStateCode[] states)
    {
        var codes = new ScanCodeShort[states.Length];
        
        // Получаем список клавиш для нажатия
        for (var j = 0; j < states.Length; j++)
        {
            codes[j] = states[j].VKey;
        }
        
        new KeyEmul().SendInput(codes);
    }
}
