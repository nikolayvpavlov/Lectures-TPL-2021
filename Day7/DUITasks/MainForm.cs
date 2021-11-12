using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DUITasks
{
    public partial class MainForm : Form
    {
        const string qotdUrl = "https://nvp-functions.azurewebsites.net/api/qotd?slow=true";

        HttpClient httpClient = new HttpClient();

        public MainForm()
        {
            InitializeComponent();
        }

        private void bGetQotDBlocking_Click(object sender, EventArgs e)
        {
            System.Net.WebClient webClient = new System.Net.WebClient();
            lQotD.Text = webClient.DownloadString(qotdUrl);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                System.Net.WebClient webClient = new System.Net.WebClient();
                string qotd = webClient.DownloadString(qotdUrl);
                Invoke(new Action(() => lQotD.Text = qotd));
            });
        }

        private async void bGetQotDAsync_Click(object sender, EventArgs e)
        {
            var task = Task.Run(() =>
            {
                System.Net.WebClient webClient = new System.Net.WebClient();
                string s = webClient.DownloadString(qotdUrl);
                return s;
            });
            await task;
            lQotD.Text = task.Result;
        }

        private async void button2GetQotDAsyncAwait2_Click(object sender, EventArgs e)
        {
            //NEVER, EVER TO THAT!
            //var t = httpClient.GetStringAsync(qotdUrl);
            //t.Wait();
            //lQotD.Text = t.Result;

            lQotD.Text = await httpClient.GetStringAsync(qotdUrl);
        }
    }
}
