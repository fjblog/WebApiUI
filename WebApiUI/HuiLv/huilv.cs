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

namespace WebApiUI.HuiLv
{
    public partial class huilv : UIForm
    {
        public huilv()
        {
            InitializeComponent();

            if (Directory.Exists(@"E:\huilv") == false)
            {
                Directory.CreateDirectory(@"E:\huilv");
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            string file = @"E:\huilv\{0}2{1}.txt";
            file = String.Format(file, uiComboboxEx1.Text.Substring(0, 3), uiComboboxEx2.Text.Substring(0, 3));

            DateTime dt = System.DateTime.Now.Date;

            FileInfo fi = new FileInfo(file);
            DateTime ft = fi.LastWriteTime.Date;
            //相隔天数 = 当前时间-文件修改时间
            int mt = (dt - ft).Days;

            double num = (double)numericUpDown1.Value;

            //如果文件最近写入时间大于1天，更新文件内容
            if (System.IO.File.Exists(file) == false || mt > 0)
            {
                string Url = "https://api.it120.cc/gooking/forex/rate?fromCode={0}&toCode={1}";
                Url = string.Format(Url, uiComboboxEx2.Text.Substring(0, 3), uiComboboxEx1.Text.Substring(0, 3));
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string json = reader.ReadToEnd();
                huilvroot h = JsonConvert.DeserializeObject<huilvroot>(json);
                if (h.data != null)
                {
                    FileStream fs = new FileStream(file, FileMode.Create);
                    StreamWriter wr = null;
                    wr = new StreamWriter(fs);
                    wr.WriteLine(h.data.rate);
                    wr.Close();
                }

                if (h.code == 0)
                {
                    double rate = h.data.rate;
                    uiRichTextBox1.Text = "1" + uiComboboxEx1.Text.Substring(4) + " = " + h.data.rate + uiComboboxEx2.Text.Substring(4) + "\n"
                        + num + uiComboboxEx1.Text.Substring(4) + " = " + (double)num * rate + uiComboboxEx2.Text.Substring(4);
                }
                else if (h.code == 20000)
                {
                    uiRichTextBox1.Text = "请重试";
                }
            }
            else
            {
                string text = System.IO.File.ReadAllText(file);
                //MessageBox.Show(text);
                double rate = Convert.ToDouble(text);

                uiRichTextBox1.Text = "1" + uiComboboxEx1.Text.Substring(4) + " = " + rate + uiComboboxEx2.Text.Substring(4) + "\n"
                        + num + uiComboboxEx1.Text.Substring(4) + " = " + (double)num * rate + uiComboboxEx2.Text.Substring(4);
            }
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            string str = uiComboboxEx1.Text;
            uiComboboxEx1.Text = uiComboboxEx2.Text;
            uiComboboxEx2.Text = str;
        }
    }
}
