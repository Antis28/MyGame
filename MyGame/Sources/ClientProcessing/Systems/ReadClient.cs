using System;
using System.Net.Sockets;
using Entitas;
using MyGame.Sources.Debug;

namespace MyGame.Sources.ClientProcessing.Systems
{
//Регистрировать в классе производном от Feature
    public sealed class ReadClientSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        // Буфер для принимаемых данных.
        Byte[] bytes = new Byte[1024];
        String data = String.Empty;


        public ReadClientSystem(Contexts contexts)
        {
            _entities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Client));
        }

        public void Execute()
        {

            foreach (var entity in _entities)
            {
                var client = entity.client.value;
                // Получаем информацию от клиента
                NetworkStream stream = client.GetStream();

                // Принимаем данные от клиента в цикле пока не дойдём до конца.
                Read(stream);

                // Закрываем соединение.
                client.Close();
                entity.isDestroyed = true;

                DebugHelper.CreateEntityMessage(data, GetType().Name);
                // сохраняем полученное сообщение
                var messageEntity = Contexts.sharedInstance.game.CreateEntity();
                messageEntity.AddMessage(data);
            }
        }

        private void Read(NetworkStream stream)
        {
            try
            {
                int count;
                while ((count = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    // Преобразуем данные в UTF8 string.
                    data = System.Text.Encoding.UTF8.GetString(bytes, 0, count);

                    // Преобразуем полученную строку в массив Байт.
                    byte[] msg = System.Text.Encoding.UTF8.GetBytes("Response: Success");

                    // Отправляем данные обратно клиенту (ответ).
                    stream.Write(msg, 0, msg.Length);
                }
            } catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        // public String Read(string backMessage)
        // {
        //     // Получаем информацию от клиента
        //     stream = client.GetStream();
        //
        //     int i;
        //     // Принимаем данные от клиента в цикле пока не дойдём до конца.
        //     while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
        //     {
        //         // Преобразуем данные в UTF8 string.
        //         data = System.Text.Encoding.UTF8.GetString(bytes, 0, i);
        //         consoleV.ShowMessage(data);
        //
        //         // Преобразуем полученную строку в массив Байт.
        //         byte[] msg = System.Text.Encoding.UTF8.GetBytes(backMessage);
        //         
        //         // Отправляем данные обратно клиенту (ответ).
        //         stream.Write(msg, 0, msg.Length);
        //     }
        //     // Закрываем соединение.
        //     client.Close();
        //     return data;
        // }
    }
}
