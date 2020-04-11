using LinqParallelPerformance.Model;
using LinqParallelPerformance.Utilities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LinqParallelPerformance.Manager
{
    public class LinqPerformanceManager
    {
        public const uint MAX_THREAD_POOL = 8;
        public const int REFRESH_FRECUENCY = 20000;

        public event EventHandler OnDataLoaded;
        public delegate void StatusProgress(int threadNumber, int threadID, int itemsProcessed);
        public event StatusProgress OnStatusProgress;

        private List<ComplexObject> collectionObjects = new List<ComplexObject>();
       
        private int threadNumber = 1;
        private readonly object lockedObject = new object();

        public LinqPerformanceManager() { }

        public void LoadData(int dataSize, int numberOfThreads, TaskCreationOptions taskCreationOptions)
        {
            if (numberOfThreads > MAX_THREAD_POOL || numberOfThreads < 1)
                throw new Exception($"MIN THREAD POOL ALLOWED: 1 Threads || MAX THREAD POOL ALLOWED: {MAX_THREAD_POOL} Threads");
              
            ConcurrentBag<ComplexObject> concurrentListCollectionObject = new ConcurrentBag<ComplexObject>();

            List<Task> taskList = new List<Task>();
            int batchSize = dataSize / numberOfThreads;
            
            for (int i = 1; i <= numberOfThreads; ++i)
            {
                taskList.Add(Task.Factory.StartNew(()=>
                {
                    int numberOfThread = GetThreadNumber();                     
                    ComplexObjectBuilder complexObjectBuilder = new ComplexObjectBuilder();

                    for (int itemsProcessed = 1; itemsProcessed <= batchSize; ++itemsProcessed)
                    {   
                        //Notify the numbers of items processed
                        if (OnStatusProgress != null && (itemsProcessed % REFRESH_FRECUENCY == 0 || itemsProcessed == batchSize))
                             NotifyUtilities.Notify(OnStatusProgress, numberOfThread, Thread.CurrentThread.ManagedThreadId, itemsProcessed);                          
                     
                        //Add generated items to collection
                        concurrentListCollectionObject.Add(complexObjectBuilder.GenerateRandomDefaultModel());
                    }

                }, taskCreationOptions));
            }
           
            //Wait for finish 
            Task.WaitAll(taskList.ToArray());

            collectionObjects = new List<ComplexObject>(concurrentListCollectionObject);

            OnDataLoaded?.Invoke(this, null);
        }

        public void ClearLoadedData()
        {
            threadNumber = 1;
            collectionObjects.Clear();
        }                                  

        public List<ComplexObject> ComplexLinqNoAsParallel()
        {
            List<ComplexObject> result = collectionObjects.Where(FilterWhere)
                                                         .Select(SelectFilter)
                                                         .OrderBy(x=>x.Date)
                                                         .ThenBy(x=>x.Name)
                                                         .ToList();

            return result;
        }

        public async Task<List<ComplexObject>> ComplexLinqNoAsParallelAsync()
        {
            return await Task.Run(() => { return ComplexLinqNoAsParallel(); });
        }

        public List<ComplexObject> ComplexLinqAsParallel(ParallelExecutionMode parallelExecutionMode, int degreeOfParalelism)
        {
            List<ComplexObject> result = collectionObjects.AsParallel()
                                                         .WithExecutionMode(parallelExecutionMode)
                                                         .WithDegreeOfParallelism(degreeOfParalelism)
                                                         .Where(FilterWhere)
                                                         .Select(SelectFilter)
                                                         .OrderBy(x => x.Date)
                                                         .ThenBy(x => x.Name)
                                                         .ToList();

            return result;
        }

        public async Task<List<ComplexObject>> ComplexLinqAsParallelAsync(ParallelExecutionMode parallelExecutionMode, int degreeOfParalelism)
        {
            return await Task.Run(() => { return ComplexLinqAsParallel(parallelExecutionMode, degreeOfParalelism); });
        }

        public int NumberOfElementProcessed()
        {
            return this.collectionObjects.Count;
        }

        private ComplexObject SelectFilter(ComplexObject defaultModel)
        {
            return new ComplexObject()
            {
                Name = defaultModel.Name,
                Date = defaultModel.Date,
                EnumDefault = defaultModel.EnumDefault,
                LongNumber = defaultModel.LongNumber,
                Number = defaultModel.Number
            };
        }

        private bool FilterWhere(ComplexObject defaultModel)
        {
            List<bool> generalStateFilter = new List<bool>();

            //Number of letter a must be >10
            bool nameOk = defaultModel.Name
                                      .Where(x => x == 'A')
                                      .Count() > 10;
            generalStateFilter.Add(nameOk);


            //Number must be divisible by 3
            bool numberOk = defaultModel.Number % 3 == 0;
            generalStateFilter.Add(numberOk);

            //LongNumber 
            bool longNumerOk = Math.Sqrt(defaultModel.LongNumber) > 30.12345d;
            generalStateFilter.Add(longNumerOk);

            bool dateOk = defaultModel.Date > DateTime.Now;
            generalStateFilter.Add(dateOk);

            ComplexObjectBuilder complexObjectBuilder = new ComplexObjectBuilder();
            bool enumOk = complexObjectBuilder.DefaultsEnums.Contains(defaultModel.EnumDefault);
            generalStateFilter.Add(enumOk);

            return !generalStateFilter.Any(x => x == false);
        }

        private int GetThreadNumber()
        {
            lock (lockedObject)
            {
                return threadNumber++;
            }
        }
    }
}
