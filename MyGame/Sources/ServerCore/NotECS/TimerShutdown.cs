using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyGame.Sources.ServerCore.NotECS
{
    internal class TimerShutdown
    {
        static int time = 0;
        static Timer timer;
        public static void test(ArgumentAction timeElapsed)
        {
            int num = 0;
            // устанавливаем метод обратного вызова
            TimerCallback tm = new TimerCallback(Count);          
            
            int.TryParse(timeElapsed.Argument, out time);

            // создаем таймер тикающий раз в 1 минуту
            timer = new Timer(tm, num, 0, 60000);
        }
        public static void Count(object obj)
        {
            // TODO: Выделить в нормальный логер
            Console.WriteLine("Осталось минут до гибернации - " + time);
            if (time <= 0)
            {               
                timer.Dispose();
                SleepMode.GoHibernateMode(new ArgumentAction());
            }
            time--;
        }
    }
    
}
