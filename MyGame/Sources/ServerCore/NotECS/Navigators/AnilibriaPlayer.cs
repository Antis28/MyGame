using KeyEmulator.MouseWorker;
using KeyEmulator.WindowWorkers;
using MessageObjects;
using MyGame.Sources.ServerCore.NotECS.Navigators;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyGame.Sources.ServerCore.NotECS
{
    public class AnilibriaPlayer : Navigator
    {
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

        public override void Skip()
        {
            InitRect();

            WorkerWithMouse.MouseMove(rect.right - 170, rect.bottom - 125);
            WorkerWithMouse.MouseClick(MouseButtons.left);
        }

        //------------------------------------------------------------
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
        //------------------------------------------------------------               
    }
}
