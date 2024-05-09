using KeyEmulator.MouseWorker;
using KeyEmulator.WindowWorkers;
using MessageObjects;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyGame.Sources.ServerCore.NotECS.Navigators
{
    internal class YummyaniPlayer : Navigator
    {        
        int lastXCoord  = 426;

        public YummyaniPlayer(Dictionary<string, IKeyStateCode> commandSettings) : base(commandSettings)
        {
            var a = commandSettings;
        }
        public override void Skip()
        {           
            WorkerWithMouse.MouseMove(1823, 981);
            WorkerWithMouse.MouseClick(MouseButtons.left);
        }

        public override void Next()
        {
            MoveEpisode(true);
        }  
        public override void Previous()
        {
            MoveEpisode(false);
        }
        private void MoveEpisode(bool isNext, int delta = 50)
        {
            WorkerWithMouse.MouseMove(1894, 1057);
            WorkerWithMouse.MouseClick(MouseButtons.left);

            Thread.Sleep(700);

            if (isNext)
            {
                lastXCoord += delta;
            }
            else
            {
                lastXCoord -= delta;
            }

            WorkerWithMouse.MouseMove(lastXCoord, 452);
            WorkerWithMouse.MouseClick(MouseButtons.left);
            Thread.Sleep(700);

            WorkerWithMouse.MouseMove(1265, 988);
            WorkerWithMouse.MouseClick(MouseButtons.left);
        }
    }
}
