using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SSCommunication.Interfaces
{
    public interface IBackgroundTaskQueue
    {
        SemaphoreSlim GetSemaphoreSlim();
        void QueueBackgroundWorkItem(Func<Task> workItem);

        Func<Task> DequeueAsync();
    }
}
