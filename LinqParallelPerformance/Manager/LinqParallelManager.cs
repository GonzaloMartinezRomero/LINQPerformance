using LinqParallelPerformance.Model;
using LinqParallelPerformance.Utilities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqParallelPerformance.Manager
{
    public class LinqParallelManager
    {
        public const uint MAX_THREAD_POOL = 4;

        private List<DefaultModel> collectionObjects = new List<DefaultModel>();
        private readonly DateTime dateTimeNow = DateTime.Now;
        private readonly List<DefaultModel.DefaultEnum> listDefaultEnums = new List<DefaultModel.DefaultEnum>()
        {
            DefaultModel.DefaultEnum.Test1,
            DefaultModel.DefaultEnum.Test3
        };
        public LinqParallelManager() { }

        public event EventHandler OnDataLoaded;
        public delegate void StatusProgress(int threadID,ulong itemsProcessed);
        public event StatusProgress OnStatusProgress;

        public void LoadData(ulong dataSize, int numberOfThreads)
        {
            if (numberOfThreads > MAX_THREAD_POOL || numberOfThreads < 1)
                throw new Exception($"MIN THREAD POOL ALLOWED: 1 Threads || MAX THREAD POOL ALLOWED: {MAX_THREAD_POOL} Threads");

            ConcurrentBag<DefaultModel> concurrentListCollectionObject = new ConcurrentBag<DefaultModel>();
            ThreadUtilities threadUtilities = new ThreadUtilities();

            List<Task> taskList = new List<Task>();
            ulong batchSize = dataSize / (ulong)numberOfThreads;

            ulong ratioFrecuency = batchSize / 20;
            ulong refreshFrecuency = (ratioFrecuency >= 1) ? ratioFrecuency : 1;
         
            for (int i = 1; i <= numberOfThreads; ++i)
            {
                taskList.Add(Task.Factory.StartNew(() =>
                {
                    ulong currentAmountItems = refreshFrecuency;
                    int threadID = threadUtilities.GetThreadIdentificator();

                    List<Task> taskListStatusProgress = new List<Task>();

                    for (ulong itemsProcessed = 1; itemsProcessed <= batchSize; ++itemsProcessed)
                    {   
                        if (OnStatusProgress != null && (itemsProcessed == currentAmountItems))
                        {   
                            Task taskStatusProgress = threadUtilities.CallStatusProgress(OnStatusProgress, threadID, itemsProcessed);
                            taskListStatusProgress.Add(taskStatusProgress);

                            currentAmountItems += refreshFrecuency;                          
                        }
                        concurrentListCollectionObject.Add(GenerateRandomDefaultModel());
                    }

                    if(taskListStatusProgress.Count > 0)
                        Task.WaitAll(taskListStatusProgress.ToArray());

                },TaskCreationOptions.LongRunning));
            }
                
            Task.WaitAll(taskList.ToArray());

            collectionObjects = new List<DefaultModel>(concurrentListCollectionObject);

            OnDataLoaded?.Invoke(this, null);
        }

        //Return as copy
        public List<DefaultModel> GetObjectsCollection() => new List<DefaultModel>(collectionObjects);

        public List<DefaultModel> ComplexLinqNoAsParallel()
        {
            List<DefaultModel> result = collectionObjects.Where(FilterWhere)
                                                         .Select(SelectFilter)
                                                         .OrderBy(x=>x.Date)
                                                         .ThenBy(x=>x.Name)
                                                         .ToList();

            return result;
        }

        public async Task<List<DefaultModel>> ComplexLinqNoAsParallelAsync()
        {
            return await Task.Run(() => { return ComplexLinqNoAsParallel(); });
        }

        public List<DefaultModel> ComplexLinqAsParallel()
        {
            List<DefaultModel> result = collectionObjects.AsParallel()
                                                         .Where(FilterWhere)
                                                         .Select(SelectFilter)
                                                         .OrderBy(x => x.Date)
                                                         .ThenBy(x => x.Name)
                                                         .ToList();

            return result;
        }

        public async Task<List<DefaultModel>> ComplexLinqAsParallelAsync()
        {
            return await Task.Run(() => { return ComplexLinqAsParallel(); });
        }

        private DefaultModel GenerateRandomDefaultModel()
        {
            Array arrayOfEnum = Enum.GetValues(typeof(DefaultModel.DefaultEnum));
            int numberOfEnum = arrayOfEnum.Length;

            DefaultModel model = new DefaultModel()
            {
                Name = RandomUtilities.RandomString(),
                Date = RandomUtilities.RandomDate(),
                EnumDefault = (DefaultModel.DefaultEnum)arrayOfEnum.GetValue(RandomUtilities.RandomInteger() % numberOfEnum),
                Number = RandomUtilities.RandomInteger(),
                LongNumber = RandomUtilities.RandomDouble()
            };

            return model;
        }

        private DefaultModel SelectFilter(DefaultModel defaultModel)
        {
            return new DefaultModel()
            {
                Name = defaultModel.Name,
                Date = defaultModel.Date,
                EnumDefault = defaultModel.EnumDefault,
                LongNumber = defaultModel.LongNumber,
                Number = defaultModel.Number
            };
        }

        private bool FilterWhere(DefaultModel defaultModel)
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

            bool dateOk = defaultModel.Date > dateTimeNow;
            generalStateFilter.Add(dateOk);

            bool enumOk = listDefaultEnums.Contains(defaultModel.EnumDefault);
            generalStateFilter.Add(enumOk);

            return !generalStateFilter.Any(x => x == false);
        }
    }
}
