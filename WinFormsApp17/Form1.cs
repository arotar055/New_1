using System;
using System.Threading;
using System.Windows.Forms;

namespace WinFormsApp17
{
    public partial class Form1 : Form
    {
        private ManualResetEvent event_for_suspend1;
        private ManualResetEvent event_for_stop1;
        private Thread firstThread;

        private ManualResetEvent event_for_suspend2;
        private ManualResetEvent event_for_stop2;
        private Thread secondThread;

        private ManualResetEvent event_for_suspend3;
        private ManualResetEvent event_for_stop3;
        private Thread thirdThread;

        public SynchronizationContext uiContext;
        private Random random;

        public Form1()
        {
            InitializeComponent();
            uiContext = SynchronizationContext.Current;
            event_for_suspend1 = new ManualResetEvent(true);
            event_for_stop1 = new ManualResetEvent(false);
            event_for_suspend2 = new ManualResetEvent(true);
            event_for_stop2 = new ManualResetEvent(false);
            event_for_suspend3 = new ManualResetEvent(true);
            event_for_stop3 = new ManualResetEvent(false);
            random = new Random();
        }

        private void ThreadFunc(ProgressBar progressBar, ManualResetEvent suspendEvent, ManualResetEvent stopEvent)
        {
            uiContext.Send(d => progressBar.Minimum = 0, null);
            uiContext.Send(d => progressBar.Maximum = 230, null);
            uiContext.Send(d => progressBar.Value = 0, null);

            while (true)
            {
                if (stopEvent.WaitOne(0)) break;

                if (suspendEvent.WaitOne(0))
                {
                    int randomValue = random.Next(0, 231);
                    uiContext.Send(d => progressBar.Value = randomValue, null);
                }
                Thread.Sleep(100);
            }
            uiContext.Send(d => progressBar.Value = 0, null);
        }

        private void StartThread(ref Thread thread, ProgressBar progressBar, ManualResetEvent suspendEvent, ManualResetEvent stopEvent)
        {
            stopEvent.Reset();
            if (thread == null || !thread.IsAlive)
            {
                thread = new Thread(() => ThreadFunc(progressBar, suspendEvent, stopEvent))
                {
                    IsBackground = true
                };
                thread.Start();
            }
        }

        private void StopThread(ManualResetEvent stopEvent, ManualResetEvent suspendEvent)
        {
            stopEvent.Set();
            suspendEvent.Set();
        }

        private void ToggleThread(CheckBox startCheckBox, CheckBox suspendCheckBox, ref Thread thread, ProgressBar progressBar, ManualResetEvent suspendEvent, ManualResetEvent stopEvent)
        {
            if (startCheckBox.Checked)
            {
                StartThread(ref thread, progressBar, suspendEvent, stopEvent);
                startCheckBox.Text = "Остановить";
                suspendCheckBox.Enabled = true;
            }
            else
            {
                StopThread(stopEvent, suspendEvent);
                startCheckBox.Text = "Запустить";
                suspendCheckBox.Checked = false;
                suspendCheckBox.Enabled = false;
            }
        }

        private void ToggleSuspend(CheckBox suspendCheckBox, ManualResetEvent suspendEvent)
        {
            if (suspendCheckBox.Checked)
            {
                suspendEvent.Reset();
                suspendCheckBox.Text = "Возобновить";
            }
            else
            {
                suspendEvent.Set();
                suspendCheckBox.Text = "Приостановить";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) => ToggleThread(checkBox1, checkBox2, ref firstThread, progressBar1, event_for_suspend1, event_for_stop1);
        private void checkBox2_CheckedChanged(object sender, EventArgs e) => ToggleSuspend(checkBox2, event_for_suspend1);
        private void checkBox4_CheckedChanged(object sender, EventArgs e) => ToggleThread(checkBox4, checkBox3, ref secondThread, progressBar2, event_for_suspend2, event_for_stop2);
        private void checkBox3_CheckedChanged(object sender, EventArgs e) => ToggleSuspend(checkBox3, event_for_suspend2);
        private void checkBox6_CheckedChanged(object sender, EventArgs e) => ToggleThread(checkBox6, checkBox5, ref thirdThread, progressBar3, event_for_suspend3, event_for_stop3);
        private void checkBox5_CheckedChanged(object sender, EventArgs e) => ToggleSuspend(checkBox5, event_for_suspend3);
    }
}
