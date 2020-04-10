using LinqParallelPerformance.Manager;
using LinqParallelPerformance.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForm
{
    public partial class Form1 : Form
    {
        private const long MB_RATIO = 1048576;
        private ulong elementsForLoad = 0;
        private int numberOfThreads = 1;
        private int degreeParalelism = 1;
        private LinqPerformanceTester linqPerformanceManager = new LinqPerformanceTester();
        private Action<int,int,ulong> delegateStatusBar = null;
        private Dictionary<ThreadKey, ulong> threadInformationDataLoaded = new Dictionary<ThreadKey, ulong>();
        
        public Form1()
        {
            InitializeComponent();
           
            //Configure Form...
            linqPerformanceManager.OnStatusProgress += LinqPerformanceManager_OnStatusProgress;
            delegateStatusBar = new Action<int,int, ulong>(ShowLoadInformation);

            this.comboParallelModes.Items.AddRange(Enum.GetNames(typeof(ParallelExecutionMode)));
            this.comboTaskCreationOpt.Items.AddRange(Enum.GetNames(typeof(TaskCreationOptions)));

            this.numberOfThreadInput.Maximum = LinqPerformanceTester.MAX_THREAD_POOL;
        }
     
        private void LinqPerformanceManager_OnStatusProgress(int threadNumber, int threadID, ulong itemsProcessed)
        {   
            object result = Invoke(delegateStatusBar,new object[] { threadNumber, threadID, itemsProcessed } );
        }            

        private void ShowLoadInformation(int threadNumber, int threadID, ulong dataLoaded)
        { 
            threadInformationDataLoaded[new ThreadKey(threadNumber,threadID)] = dataLoaded;

            StringBuilder textInformation = new StringBuilder();
            textInformation.AppendLine("Generating complex objects...");

            foreach (KeyValuePair<ThreadKey, ulong> kvp in threadInformationDataLoaded.OrderBy(x => x.Key.ThreadNumber))
                textInformation.AppendLine($"Thread #{kvp.Key.ThreadNumber}:(ID {kvp.Key.ThreadID}): {kvp.Value} items processed");

            TextStatusProgress.Text = textInformation.ToString();
            TextStatusProgress.Refresh();
        }

        private async void LoadDataAsync(object sender, EventArgs e)
        {
            TextStatusProgress.Clear();

            try
            {
                CheckInputLoadDataParameters();

                DisableConfigurationLoadDataButtons();

                threadInformationDataLoaded.Clear();      

                TaskCreationOptions taskCreationOptions = TaskCreationOptions.None;
                Enum.TryParse(this.comboTaskCreationOpt.SelectedItem?.ToString(), out taskCreationOptions);

                linqPerformanceManager.ClearLoadedData();

                Stopwatch watch = Stopwatch.StartNew();
                await Task.Run(() => { linqPerformanceManager.LoadData(elementsForLoad, numberOfThreads, taskCreationOptions); });
                watch.Stop();

                TextStatusProgress.Text += Environment.NewLine + $"Memory usage: {System.GC.GetTotalMemory(forceFullCollection:true)/ MB_RATIO} MB";
                TextStatusProgress.Text += Environment.NewLine + $"All items loaded in {watch.ElapsedMilliseconds.ToString()} ms!!";
                TextStatusProgress.Text += Environment.NewLine + $"Processor cores: {Environment.ProcessorCount}";
                TextStatusProgress.Update();

                ButtonNoParallelLinq.Enabled = true;
                ButtonParalellLinq.Enabled = true;
            }
            catch (Exception exception)
            {
                TextStatusProgress.Text = BuildTraceException(exception);
            }
        }

        private void DisableConfigurationLoadDataButtons()
        {
            inputNumberValues.Enabled = false;
            numberOfThreadInput.Enabled = false;
            comboTaskCreationOpt.Enabled = false;
            LoadDataButton.Enabled = false;
        }

        private void CheckInputLoadDataParameters()
        {  
            if (!UInt64.TryParse(inputNumberValues.Value.ToString(), out elementsForLoad))
                throw new Exception("Invalid input parameter number of items. Must be a integer number");

            if (!Int32.TryParse(numberOfThreadInput.Value.ToString(),out numberOfThreads))
                throw new Exception("Invalid input parameter of threads. Must be a integer number");
        }      

        private void LoadProgress(string status)
        {
            this.TextStatusProgress.Text = status;
        }

        private async void ButtonNoParaAsyn_Click(object sender, EventArgs e)
        {
            ButtonNoParallelLinq.Enabled = false;

            try
            {
                textNoParalellAsyn.Text = "Processing....";

                Stopwatch watch = Stopwatch.StartNew();
                List<ComplexObject> processedItems = await linqPerformanceManager.ComplexLinqNoAsParallelAsync();
                watch.Stop();

                textNoParalellAsyn.Text = processedItems.Count + " items processed in " + watch.ElapsedMilliseconds.ToString() + "ms";

            }
            catch (Exception exception)
            {
                textNoParalellAsyn.Text = BuildTraceException(exception);
            }
            finally
            {
                ButtonNoParallelLinq.Enabled = true;
            }            
        }

        private async void ButtonParalellAsyn_Click(object sender, EventArgs e)
        {
            ButtonParalellLinq.Enabled = false;

            try
            {
                textParallelAsym.Text = "Processing....";

                ParallelExecutionMode parallelExecutionMode = ParallelExecutionMode.Default;
                Enum.TryParse(this.comboParallelModes.SelectedItem?.ToString(), out parallelExecutionMode);

                if (!Int32.TryParse(numericDegreeOfParalelism.Value.ToString(), out degreeParalelism))
                    throw new Exception("Invalid input parameter of degree paralelism. Must be a integer number");

                Stopwatch watch = Stopwatch.StartNew();
                List<ComplexObject> processedItems = await linqPerformanceManager.ComplexLinqAsParallelAsync(parallelExecutionMode, degreeParalelism);
                watch.Stop();

                textParallelAsym.Text = processedItems.Count + " items processed in " + watch.ElapsedMilliseconds.ToString() + "ms";
            }
            catch (Exception exception)
            {
                textParallelAsym.Text = BuildTraceException(exception);
            }
            finally
            {
                ButtonParalellLinq.Enabled = true;
            }                                                 
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            inputNumberValues.Enabled = true;
            numberOfThreadInput.Enabled = true;

            LoadDataButton.Enabled = true;

            textNoParalellAsyn.Clear();
            ButtonNoParallelLinq.Enabled = false;

            textParallelAsym.Clear();
            ButtonNoParallelLinq.Enabled = false;

            comboTaskCreationOpt.Enabled = true;

            TextStatusProgress.Clear();
        }

        private string BuildTraceException(Exception exception)
        {
            StringBuilder exceptionMessage = new StringBuilder();
            Exception exceptionAux = exception;

            while(exceptionAux != null)
            {
                exceptionMessage.AppendLine(exceptionAux.Message);
                exceptionAux = exceptionAux.InnerException;
            }

            return exceptionMessage.ToString();
        }

        private sealed class ThreadKey
        {
            public int ThreadNumber { get; }
            public int ThreadID { get; }

            private ThreadKey() { }

            public ThreadKey(int threadNumber, int threadID)
            {
                this.ThreadNumber = threadNumber;
                this.ThreadID = threadID;
            }

            public override bool Equals(object obj)
            {
               if(obj is ThreadKey threadKeyAux)
               {
                    return this.ThreadNumber == threadKeyAux.ThreadNumber &&
                           this.ThreadID == threadKeyAux.ThreadID;
               }

                return false;
            }

            public override int GetHashCode()
            {
                return this.ToString().GetHashCode();
            }

            public override string ToString()
            {
                return ThreadNumber.ToString() + ThreadID.ToString();
            }
        }
    }
}
