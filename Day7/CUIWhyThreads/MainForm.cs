using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CUIWhyThreads
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void bBlocking_Click(object sender, EventArgs e)
        {
            int answer;
            try
            {
                progressBar.Style = ProgressBarStyle.Marquee;
                var dt = new DeepThought();
                answer = dt.ComputeTheUltimateAnswer();
            }
            finally
            {
                progressBar.Style = ProgressBarStyle.Blocks;
            }
            MessageBox.Show("The answer is: " + answer);
        }

        private void Worker()
        {
            int answer;
            try
            {
                //Invoke is a must. Without it, we will get an exception for a cross-thread operation.
                //Sends the lambda to be executed by the thread in which the Form is created (a.k.a. the UI thread)
                Invoke(new Action(() => progressBar.Style = ProgressBarStyle.Marquee));

                var dt = new DeepThought();
                answer = dt.ComputeTheUltimateAnswer();
            }
            finally 
            {
                Invoke(new Action(() => progressBar.Style = ProgressBarStyle.Blocks));
            }
            MessageBox.Show("The answer is: " + answer);
        }

        private void bThread_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(Worker);
            t.Start();
        }

    }
}
