using SSCommunication.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SSCommunication.Implementations
{
    public class BackgroundTaskQueue : IBackgroundTaskQueue
    {
        private ConcurrentQueue<Func<Task>> _workItems = new ConcurrentQueue<Func<Task>>();
        SemaphoreSlim _signal = new SemaphoreSlim(0);



        public BackgroundTaskQueue()
        {
        }
        public Func<Task> DequeueAsync()
        {

            _workItems.TryDequeue(out var workItem);
            return workItem;
        }

        public void QueueBackgroundWorkItem(Func<Task> workItem)
        {
            if (workItem != null)
            {
                _workItems.Enqueue(workItem);
                _signal.Release();
            }
        }

        public SemaphoreSlim GetSemaphoreSlim()
        {
            return _signal;
        }
    }
}
