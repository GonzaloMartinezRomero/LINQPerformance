using LinqParallelPerformance.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using LinqParallelPerformance.Manager;
using System.Text;
using System.Collections.Concurrent;

namespace MainForm
{
    public partial class Form1 : Form
    {
        private ulong elementsForLoad = 0;
        private LinqParallelManager linqPerformanceManager = new LinqParallelManager();
        private Action<int,ulong> delegateStatusBar = null;
        private Dictionary<int, ulong> threadInformationDataLoaded = new Dictionary<int, ulong>();
        private object lockObject = new object();
         
        public Form1()
        {
            InitializeComponent();
           
            linqPerformanceManager.OnStatusProgress += LinqPerformanceManager_OnStatusProgress;
            delegateStatusBar = new Action<int, ulong>(ShowLoadInformation);            

            for (int i = 1; i <= LinqParallelManager.MAX_THREAD_POOL; ++i)
                threadInformationDataLoaded.Add(i, 0);
        }
     
        private void LinqPerformanceManager_OnStatusProgress(int threadID, ulong itemsProcessed)
        {   
            object result = Invoke(delegateStatusBar,new object[] {threadID, itemsProcessed } );
        }            

        private void ShowLoadInformation(int threadID, ulong dataLoaded)
        {
            lock (lockObject)
            {
                Console.WriteLine();
                threadInformationDataLoaded[threadID] = dataLoaded;
                StringBuilder textInformation = new StringBuilder();

                foreach (KeyValuePair<int, ulong> kvp in threadInformationDataLoaded.OrderBy(x => x.Key))
                    textInformation.AppendLine($"Thread {kvp.Key}: {kvp.Value} items processed");

                TextStatusProgress.Text = textInformation.ToString();
                TextStatusProgress.Refresh();
            }
        }

        private async void LoadDataAsync(object sender, EventArgs e)
        {
            TextStatusProgress.Clear();

            try
            {
                CheckInputParameters();

                LoadDataButton.Enabled = false;

                await Task.Run(() => { linqPerformanceManager.LoadData(elementsForLoad); });
                TextStatusProgress.Text += Environment.NewLine + "All items loaded!!";
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
            string numberOfItems = inputNumberValues.Text;

            if (!UInt64.TryParse(numberOfItems, out elementsForLoad))
                throw new Exception("Invalid input parameter. Must be a integer number");

            inputNumberValues.Enabled = false;
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
            inputNumberValues.Clear();

            LoadDataButton.Enabled = true;

            textNoParalellAsyn.Clear();
            ButtonNoParallelLinq.Enabled = false;

            textParallelAsym.Clear();
            ButtonNoParallelLinq.Enabled = false;

            TextStatusProgress.Clear();
        }
    }
}
