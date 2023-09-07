using System.Threading;

namespace MyGame.Sources.ServerCore.NotECS
{
    internal class TimerShutdown
    {
        static int time = 0;
        static Timer timer;

        public static void test(ArgumentAction timeElapsed)
        {
            var num = 0;
            // устанавливаем метод обратного вызова
            var tm = new TimerCallback(Count);

            int.TryParse(timeElapsed.Argument, out time);

            // создаем таймер тикающий раз в 1 минуту
            timer = new Timer(tm, num, 0, 60000);
        }

        public static void Count(object obj)
        {
            // TODO: Переделать в логер ECS(DI), если будет в ECS
            var message = $"Осталось минут до гибернации - {time}";
            Main.Logger.ShowMessage(message);

            if (time <= 0)
            {
                timer.Dispose();
                SleepMode.GoHibernateMode(new ArgumentAction());
            }

            time--;
        }
    }
}
