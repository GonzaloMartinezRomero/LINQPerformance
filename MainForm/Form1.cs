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
        private LinqParallelManager linqPerformanceManager = new LinqParallelManager();
        private Action<int,ulong> delegateStatusBar = null;
        private Dictionary<int, ulong> threadInformationDataLoaded = new Dictionary<int, ulong>();
        
        public Form1()
        {
            InitializeComponent();
           
            linqPerformanceManager.OnStatusProgress += LinqPerformanceManager_OnStatusProgress;
            delegateStatusBar = new Action<int, ulong>(ShowLoadInformation);                     
        }
     
        private void LinqPerformanceManager_OnStatusProgress(int threadID, ulong itemsProcessed)
        {   
            object result = Invoke(delegateStatusBar,new object[] {threadID, itemsProcessed } );
        }            

        private void ShowLoadInformation(int threadID, ulong dataLoaded)
        {       
            threadInformationDataLoaded[threadID] = dataLoaded;
            StringBuilder textInformation = new StringBuilder();
            textInformation.AppendLine("Generating complex objects...");

            foreach (KeyValuePair<int, ulong> kvp in threadInformationDataLoaded.OrderBy(x => x.Key))
                textInformation.AppendLine($"Thread {kvp.Key}: {kvp.Value} items processed");

            TextStatusProgress.Text = textInformation.ToString();
            TextStatusProgress.Refresh();
        }

        private async void LoadDataAsync(object sender, EventArgs e)
        {
            TextStatusProgress.Clear();

            try
            {
                CheckInputParameters();

                LoadDataButton.Enabled = false;

                threadInformationDataLoaded.Clear();
                for (int i = 1; i <= numberOfThreads; ++i)
                    threadInformationDataLoaded.Add(i, 0);

                Stopwatch watch = Stopwatch.StartNew();
                await Task.Run(() => { linqPerformanceManager.LoadData(elementsForLoad, numberOfThreads); });
                watch.Stop();

                TextStatusProgress.Text += Environment.NewLine + $"Memory usage: {System.GC.GetTotalMemory(forceFullCollection:true)/ MB_RATIO} MB";
                TextStatusProgress.Text += Environment.NewLine + $"All items loaded in {watch.ElapsedMilliseconds.ToString()} ms!!";
                TextStatusProgress.Update();

                ButtonNoParallelLinq.Enabled = true;
                ButtonParalellLinq.Enabled = true;
            }
            catch (Exception exception)
            {
                TextStatusProgress.Text = exception.Message;
            }
        }

        private void CheckInputParameters()
        {  
            if (!UInt64.TryParse(inputNumberValues.Value.ToString(), out elementsForLoad))
                throw new Exception("Invalid input parameter number of items. Must be a integer number");

            if (!Int32.TryParse(numberOfThreadInput.Value.ToString(),out numberOfThreads))
                throw new Exception("Invalid input parameter of threads. Must be a integer number");

            inputNumberValues.Enabled = false;
            numberOfThreadInput.Enabled = false;
        }      

        private void LoadProgress(string status)
        {
            this.TextStatusProgress.Text = status;
        }

        private async void ButtonNoParaAsyn_Click(object sender, EventArgs e)
        {
            ButtonNoParallelLinq.Enabled = false;

            Stopwatch watch = Stopwatch.StartNew();
            List<DefaultModel> processedItems = await linqPerformanceManager.ComplexLinqNoAsParallelAsync();
            watch.Stop();

            textNoParalellAsyn.Text = elementsForLoad +" items processed in "+ watch.ElapsedMilliseconds.ToString() +"ms";

            ButtonNoParallelLinq.Enabled = true;
        }

        private async void ButtonParalellAsyn_Click(object sender, EventArgs e)
        {
            ButtonParalellLinq.Enabled = false;

            Stopwatch watch = Stopwatch.StartNew();
            List<DefaultModel> processedItems = await linqPerformanceManager.ComplexLinqAsParallelAsync();
            watch.Stop();

            textParallelAsym.Text = elementsForLoad + " items processed in " + watch.ElapsedMilliseconds.ToString() + "ms";

            ButtonParalellLinq.Enabled = true;
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

            TextStatusProgress.Clear();
        }
    }
}
