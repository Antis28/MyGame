// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Threading;

namespace MyGame.Sources.Services
{
    /// <summary>
    /// Позволяет серверу работать в многопоточном режиме с клиентами
    /// </summary>
    public class MultiThreadService: IMultiThreadService
    {
        public MultiThreadService()
        {
            MaxThreadsCount = Environment.ProcessorCount * 4;
            // Установим максимальное количество рабочих потоков
            ThreadPool.SetMaxThreads(MaxThreadsCount, MaxThreadsCount);
            // Установим минимальное количество рабочих потоков
            ThreadPool.SetMinThreads(2, 2);
        }
        public int MaxThreadsCount { get; }
        
    }
}
