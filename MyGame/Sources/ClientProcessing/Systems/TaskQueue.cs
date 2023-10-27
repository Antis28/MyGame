using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;


namespace MyGame.Sources.ClientProcessing.Systems
{
    public class TaskQueue
    {
        private readonly ConcurrentQueue<Func<Task>> _queue = new ConcurrentQueue<Func<Task>>();
        private volatile bool _isProcessing;

        public async Task Enqueue(Func<Task> taskFactory)
        {
            _queue.Enqueue(taskFactory);
            if (!_isProcessing)
            {
                await Task.Run(ProcessQueue);
            }
        }

        private async Task ProcessQueue()
        {
            _isProcessing = true;
            while (_queue.TryDequeue(out var taskFactory))
            {
                await taskFactory();
            }
            _isProcessing = false;
        }
    }
}
