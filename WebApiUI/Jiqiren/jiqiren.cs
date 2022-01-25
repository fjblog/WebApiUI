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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebApiUI.Jiqiren
{
    public partial class jiqiren : UIForm
    {
        public jiqiren()
        {
            InitializeComponent();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            uiRichTextBox1.AppendText("我 ：" + uiTextBox1.Text + "\n");
            
            string Url = "http://api.qingyunke.com/api.php?key=free&appid=0&msg={0}";
            Url = string.Format(Url, uiTextBox1.Text);
            uiTextBox1.Clear();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string json = reader.ReadToEnd();
            JiqirenRoot jqr = JsonConvert.DeserializeObject<JiqirenRoot>(json);
            if (jqr.content.Contains("{br}"))
            {
                string br = "{br}";
                string n = "\n";
                jqr.content = jqr.content.Replace(br, n);
            }
            uiRichTextBox1.AppendText("机器人菲菲：" + jqr.content + "\n");

        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            uiTextBox1.Clear();
        }

        private void uiRichTextBox1_TextChanged(object sender, EventArgs e)
        {
            uiRichTextBox1.ScrollToCaret();
        }
    }
}
