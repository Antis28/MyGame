using KeyEmulator.MouseWorker;
using KeyEmulator.WindowWorkers;
using System;

namespace MyGame.Sources.ServerCore.NotECS
{
    public class SkipOpenning
    {
        public static void Skip(ArgumentAction argument)
        {
            IntPtr hWnd = WorkerWithWindows.GetDesktopWindow();
            RECT rect = new RECT();
            WorkerWithWindows.GetWindowRect(hWnd, out rect);

            WorkerWithMouse.MouseMove(rect.right - 170, rect.bottom - 125);
            WorkerWithMouse.MouseClick(MouseButtons.left);
        }
    }
}
