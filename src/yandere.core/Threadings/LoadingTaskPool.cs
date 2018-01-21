using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Threadings
{
    public class LoadingTaskPool
    {
        private static readonly Queue<ILoadingTask> loadingTaskQueue = new Queue<ILoadingTask>(15);

        public async static Task<object> RunTask(ILoadingTask task, params object[] args)
        {
            if (loadingTaskQueue.Contains(task)) return Task.Run(() => (object)null);

            loadingTaskQueue.Enqueue(task);

            while (loadingTaskQueue.Peek() != task) await Task.Delay(1000);
            loadingTaskQueue.Dequeue();

            return Task.Run(() => task.Run(args));
        }

        public async static Task<TReturn> RunTask<TReturn>(ILoadingTask<TReturn> task, params object[] args)
        {
            if (loadingTaskQueue.Contains(task)) return await Task.Run(() => default(TReturn));

            loadingTaskQueue.Enqueue(task);

            while (loadingTaskQueue.Peek() != task) await Task.Delay(1000);
            loadingTaskQueue.Dequeue();

            return await Task.Run(() => task.Run(args));
        }
    }
}
