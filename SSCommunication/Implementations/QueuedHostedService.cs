using Microsoft.Extensions.Hosting;
using SSCommunication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SSCommunication.Implementations
{
    public class QueuedHostedService : BackgroundService
    {
        public IBackgroundTaskQueue _taskqueue;
        private Action<Task> tsk_finished;
        public QueuedHostedService(IBackgroundTaskQueue taskqueue)
        {
            _taskqueue = taskqueue;
            tsk_finished = (a) =>
            {
                Release(a);
            };
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                var ss = _taskqueue.GetSemaphoreSlim();
                
                while (true)
                {
                    await ss.WaitAsync();
                    var task = _taskqueue.DequeueAsync();
                    if (task != null)
                    {
                        ExecuteParallel(task);
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO : Add Logging
            }
        }

        private void Release(Task a)
        {
            try
            {
                _taskqueue.GetSemaphoreSlim().Release();
            }
            catch (Exception ex)
            {
                //TODO : Add Logging
            }
        }
        private void ExecuteParallel(Func<Task> task)
        {
            try
            {
                task.Invoke().ContinueWith(tsk_finished);
            }
            catch (Exception ex)
            {
                //TODO : Add Logging
            }
        }

    }
}
