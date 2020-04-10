using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqParallelPerformance.Manager;
using static LinqParallelPerformance.Manager.LinqParallelManager;

namespace LinqParallelPerformance.Utilities
{
    public sealed class NotifyUtilities 
    {
        private static NotifyUtilities InstanceNotifyUtilities = null;
        private readonly ConcurrentQueue<NotifyDTO> threadsRequestNotify = new ConcurrentQueue<NotifyDTO>();

        private NotifyUtilities() { }

        static NotifyUtilities()
        {
            InstanceNotifyUtilities = new NotifyUtilities();
        }

        internal static void Notify(StatusProgress onStatusProgress, int threadID, ulong itemsProcessed)
        {
            //Add notification request
            InstanceNotifyUtilities.threadsRequestNotify.Enqueue(new NotifyDTO()
            {
                ThreadID = threadID,
                ItemsProcessed = itemsProcessed,
                OnStatusProgress = onStatusProgress
            });

            InstanceNotifyUtilities.StartNotify();
        }

        private void StartNotify()
        {
            while(!threadsRequestNotify.IsEmpty)
            {
                if(threadsRequestNotify.TryDequeue(out NotifyDTO notifyDTO))
                {
                    notifyDTO.CallNotifier();
                }
            }
        }

        private sealed class NotifyDTO
        {
            public int ThreadID { get; set; }
            public ulong ItemsProcessed { get; set; }
            public StatusProgress OnStatusProgress { get; set; }

            public void CallNotifier() => OnStatusProgress?.Invoke(ThreadID, ItemsProcessed);
        }
    }
}
