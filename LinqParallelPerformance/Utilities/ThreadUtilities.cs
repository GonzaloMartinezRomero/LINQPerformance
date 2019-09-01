using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LinqParallelPerformance.Manager.LinqParallelManager;

namespace LinqParallelPerformance.Utilities
{
    public sealed class ThreadUtilities
    {
        private object lockObjectIdentificator = new object();
        private object lockObjectEventStatusProgress = new object();
        private int currentThreadID = 1;
        private ConcurrentQueue<Tuple<int,ulong>> eventQueue = new ConcurrentQueue<Tuple<int, ulong>>();

        public int GetThreadIdentificator()
        {
            lock (lockObjectIdentificator)
            {
                return currentThreadID++;
            }
        }

        public Task CallStatusProgress(StatusProgress eventStatusProgress,int threadID, ulong itemsProcessed)
        {  
            eventQueue.Enqueue(new Tuple<int, ulong>(threadID,itemsProcessed));

            return Task.Run(() =>
            {
                lock (lockObjectEventStatusProgress)
                { 
                    while (!eventQueue.IsEmpty)
                    { 
                        if (eventQueue.TryDequeue(out Tuple<int, ulong> tupleAux))
                            eventStatusProgress?.Invoke(tupleAux.Item1, tupleAux.Item2);
                    }
                }
            });
        } 
    }
}
