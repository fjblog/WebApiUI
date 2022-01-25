using Newtonsoft.Json;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WebApiUI.FanYi
{
    public partial class fanyi : UIForm
    {
        public fanyi()
        {
            InitializeComponent();
        }

        private void wenbenfanyi()
        {
            string Url = " https://api.66mz8.com/api/translation.php?info={0}";
            Url = string.Format(Url, uiRichTextBox1.Text.Trim());
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string json = reader.ReadToEnd();
            FanYiRoot fy = JsonConvert.DeserializeObject<FanYiRoot>(json);

            //uiRichTextBox1.Font = new Font("微软雅黑", 10);
            uiRichTextBox2.Text = fy.fanyi;

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            wenbenfanyi();
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            uiRichTextBox1.Clear();
        }
    }
}
