using System.Collections.Concurrent;
using static LinqParallelPerformance.Manager.LinqPerformanceManager;

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

        internal static void Notify(StatusProgress onStatusProgress ,int threadNumber, int threadID, int itemsProcessed)
        {
            //Add notification request
            InstanceNotifyUtilities.threadsRequestNotify.Enqueue(new NotifyDTO()
            {
                ThreadID = threadID,
                ItemsProcessed = itemsProcessed,
                ThreadNumber = threadNumber,
                OnStatusProgress = onStatusProgress
            });

            InstanceNotifyUtilities.StartToNotify();
        }

        private void StartToNotify()
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
            public int ItemsProcessed { get; set; }
            public StatusProgress OnStatusProgress { get; set; }
            public int ThreadNumber { get; internal set; }

            public void CallNotifier() => OnStatusProgress?.Invoke(ThreadNumber, ThreadID, ItemsProcessed);
        }
    }
}
