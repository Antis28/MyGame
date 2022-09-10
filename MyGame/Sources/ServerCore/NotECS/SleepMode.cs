using System;
using System.Runtime.InteropServices;


namespace MyGame.Sources.ServerCore
{
    public class SleepMode
    {
        [DllImport("Powrprof.dll", CharSet=CharSet.Auto, ExactSpelling=true)]
        private static extern bool SetSuspendState(bool hibernate, bool forceCritical, bool disableWakeEvent);

        public static void GoHibernateMode()
        {
            SetSuspendState(true, true, true);
            // Hibernate for winforms
            // Application.SetSuspendState(PowerState.Hibernate, true, true);

        }
        public static void GoStandbyMode()
        {
            SetSuspendState(false, true, true);
            // Standby for winforms
            // Application.SetSuspendState(PowerState.Suspend, true, true);
        }
    }
}
