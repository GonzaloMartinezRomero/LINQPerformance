using LinqParallelPerformance.Model;
using LinqParallelPerformance.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqParallelPerformance.Manager
{
    internal sealed class ComplexObjectBuilder
    { 
        public List<ComplexObject.DefaultEnum> DefaultsEnums
        {
            get
            {
                return new List<ComplexObject.DefaultEnum>()
                {
                    ComplexObject.DefaultEnum.Test1,
                    ComplexObject.DefaultEnum.Test3
                };
            }
        } 

        public ComplexObject GenerateRandomDefaultModel()
        {
            Array arrayOfEnum = Enum.GetValues(typeof(ComplexObject.DefaultEnum));
            int numberOfEnum = arrayOfEnum.Length;

            ComplexObject model = new ComplexObject()
            {
                Name = RandomUtilities.RandomString(),
                Date = RandomUtilities.RandomDate(),
                EnumDefault = (ComplexObject.DefaultEnum)arrayOfEnum.GetValue(RandomUtilities.RandomInteger() % numberOfEnum),
                Number = RandomUtilities.RandomInteger(),
                LongNumber = RandomUtilities.RandomDouble()
            };

            return model;
        }
    }
}
