using KeyEmulator.MouseWorker;
using KeyEmulator.WindowWorkers;
using MessageObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyGame.Sources.ServerCore.NotECS
{
    public class AnilibriaPlayer : Navigator
    {
        private static RECT rect;

        public AnilibriaPlayer(Dictionary<string, IKeyStateCode> commandSettings) : base(commandSettings)
        {
        }
        public async override void Next()
        {
            WorkerWithMouse.MouseMove(113, 1063);
            await Task.Delay(100);
            WorkerWithMouse.MouseClick(MouseButtons.left);
        }
        public async override void Previous()
        {
            WorkerWithMouse.MouseMove(31, 1063);
            await Task.Delay(100);
            WorkerWithMouse.MouseClick(MouseButtons.left);           
        }

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
