using KeyEmulator.MouseWorker;
using KeyEmulator.WindowWorkers;
using MessageObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyGame.Sources.ServerCore.NotECS.Navigators
{
    internal class YouTubePlayer : Navigator
    {
        private static RECT rect;

        public YouTubePlayer(Dictionary<string, IKeyStateCode> commandSettings) : base(commandSettings)
        {
        }

        public void Skip(ArgumentAction argument)
        {
          //  InitRect();  
          //  WorkerWithMouse.MouseMove(rect.right - 170, rect.bottom - 125);
            //WorkerWithMouse.MouseClick(MouseButtons.left);
        }
        public async override void Next()
        {
            WorkerWithMouse.MouseMove(165, 1050);
            await Task.Delay(100);
            WorkerWithMouse.MouseClick(MouseButtons.left);
            await Task.Delay(100);
            WorkerWithMouse.MouseMove(500, 500);
        }
        public async override void Previous ()
        {
            WorkerWithMouse.MouseMove(50, 1050);
            await Task.Delay(100);
            WorkerWithMouse.MouseClick(MouseButtons.left);
            await Task.Delay(100);
            WorkerWithMouse.MouseMove(500, 500);
        }
        public async override void PausePlay()
        {
            WorkerWithMouse.MouseMove(110, 1050);
            await Task.Delay(100);
            WorkerWithMouse.MouseClick(MouseButtons.left);
            await Task.Delay(100);
            WorkerWithMouse.MouseMove(500, 500);
        }
        private static void InitRect()
        {
            IntPtr hWnd = WorkerWithWindows.GetDesktopWindow();
            rect = new RECT();
            WorkerWithWindows.GetWindowRect(hWnd, out rect);
        }
    }
}
