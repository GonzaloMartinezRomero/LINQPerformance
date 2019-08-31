using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqParallelPerformance.Utilities
{
    public static class ThreadUtilities
    {
        private static object lockObject = new object();
        private static int currentThreadID = 1;

        public static int GetThreadIdentificator()
        {
            lock (lockObject)
            {
                return currentThreadID++;
            }
        }
    }
}
