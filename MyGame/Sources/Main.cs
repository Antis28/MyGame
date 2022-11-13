﻿using System;
using System.Net.Sockets;
using System.Threading;
using MyGame.Sources.Services;
using MyGame.Sources.Systems;
using CrossConsole;

namespace MyGame.Sources
{
    public class Main
    {
        private RootSystem _systems;

        public void Start()
        {
            var context = Contexts.sharedInstance;

            var services = new ServiceRootSystems(context, GetServices());
            services.Initialize();

            _systems = new RootSystem(context);
            _systems.Initialize();

            context.game.CreateEntity().isLoadSettings = true;
            Connect("hi");

            // для unity3D поместить в Update 
            while (true)
            {
                _systems.Execute();
                Thread.Sleep(500);
            }
        }

        private static ServicesRegister GetServices()
        {
            return new ServicesRegister(
                new MyTimeService(),
                new ConsoleLogService(),
                new MultiThreadService()
                //     new UnityViewService(),        // responsible for creating gameobjects for views
                //     new UnityApplicationService(), // gives app functionality like .Quit()
                //     new UnityTimeService(),        // gives .deltaTime, .fixedDeltaTime etc
                //     new InControlInputService(),   // provides user input
                //     // next two are monobehaviours attached to gamecontroller
                //     GetComponent<UnityAiService>(),            // async steering calculations on MB
                //     GetComponent<UnityConfigurationService>(), // editor accessable global config
                //     new UnityCameraService(),                  // camera bounds, zoom, fov, orthsize etc
                //     new UnityPhysicsService()                  // raycast, checkcircle, checksphere etc.
            );
        }
        static async void  Connect(String message)
        {
            // Настраиваем его на IP нашего сервера и тот же порт.
            String  server = "192.168.1.201";
            Int32 port = 9090;
            try
            {
                // Создаём TcpClient.
                TcpClient client = new TcpClient();
                await client.ConnectAsync(server, port);
                
                // Переводим наше сообщение в UTF8, а затем в массив Byte.
                Byte[] data = System.Text.Encoding.UTF8.GetBytes(message);
                // Получаем поток для чтения и записи данных.
                NetworkStream stream = client.GetStream();
                // Отправляем сообщение нашему серверу. 
                await stream.WriteAsync(data, 0, data.Length);
                ConsoleCreator.CreateForDotNetFramework().ShowMessage(message);
                // Получаем ответ от сервера.
                // Буфер для хранения принятого массива bytes.
                data = new Byte[256];
                // Строка для хранения полученных UTF8 данных.
                // Читаем первый пакет ответа сервера. 
                // Можно читать всё сообщение.
                // Для этого надо организовать чтение в цикле как на сервере.
                Int32 bytes = await stream.ReadAsync(data, 0, data.Length);
                var responseData = System.Text.Encoding.UTF8.GetString(data, 0, bytes);
                ConsoleCreator.CreateForDotNetFramework().ShowMessage(responseData);
                
                // Закрываем всё.
                stream.Close();
                client.Close();
            } catch (ArgumentNullException e) { ConsoleCreator.CreateForDotNetFramework().ShowMessage(e.Message); } catch (SocketException e)
            {
                ConsoleCreator.CreateForDotNetFramework().ShowMessage(e.Message); 
            }
        }
    }
}
