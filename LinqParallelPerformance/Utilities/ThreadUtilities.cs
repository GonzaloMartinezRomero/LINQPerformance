using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqParallelPerformance.Utilities
{
    public sealed class ThreadUtilities
    {
        private object lockObject = new object();
        private int currentThreadID = 1;

        public int GetThreadIdentificator()
        {
            lock (lockObject)
            {
                return currentThreadID++;
            }
        }
    }
}
