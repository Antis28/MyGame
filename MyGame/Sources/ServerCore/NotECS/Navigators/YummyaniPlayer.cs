using KeyEmulator.MouseWorker;
using KeyEmulator.WindowWorkers;
using MessageObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyGame.Sources.ServerCore.NotECS.Navigators
{
    internal class YummyaniPlayer : Navigator
    {        

        public YummyaniPlayer(Dictionary<string, IKeyStateCode> commandSettings) : base(commandSettings)
        {
            var a = commandSettings;
        }
        public override void Skip()
        {
            var coord = WorkerWithMouse.GetCursorPosition();
            WorkerWithMouse.MouseMove(1823, 981);
            WorkerWithMouse.MouseClick(MouseButtons.left);
        }
    }
}
