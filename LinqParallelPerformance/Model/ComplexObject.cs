using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqParallelPerformance.Model
{
    public sealed class ComplexObject
    {
        public enum DefaultEnum
        {
            Test1, Test2, Test3, Test4
        }

        public string Name { get; set; }
        public int Number { get; set; }
        public double LongNumber { get; set; }
        public DateTime Date { get; set; }
        public DefaultEnum EnumDefault { get; set; }
    }
}
