using KeyEmulator.MouseWorker;
using KeyEmulator.WindowWorkers;
using System;

namespace MyGame.Sources.ServerCore.NotECS
{
    public class AnilibriaPlayer
    {
        private static RECT rect;

        public static void Skip(ArgumentAction argument)
        {
            InitRect();

            WorkerWithMouse.MouseMove(rect.right - 170, rect.bottom - 125);
            WorkerWithMouse.MouseClick(MouseButtons.left);
        }
        public static void NextEpisode(ArgumentAction argument)
        {
            WorkerWithMouse.MouseMove(113,1063);
            WorkerWithMouse.MouseClick(MouseButtons.left);
        }
        public static void PreviousEpisode(ArgumentAction argument)
        {           
            WorkerWithMouse.MouseMove(31, 1063);
            WorkerWithMouse.MouseClick(MouseButtons.left);
        }

        private static void InitRect()
        {
            IntPtr hWnd = WorkerWithWindows.GetDesktopWindow();
            rect = new RECT();
            WorkerWithWindows.GetWindowRect(hWnd, out rect);
        }
    }
}
