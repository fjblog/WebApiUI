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

namespace WebApiUI.BaiDu
{
    public partial class baidu : UIForm
    {
        static string path = Environment.CurrentDirectory;
        IniFile ini = new IniFile(path + @"\setup.ini");

        public baidu()
        {
            InitializeComponent();
            load_tianqi();
            string city = ini.ReadString("BaiduTianQi", "City", "");
            uiLabel3.Text = "默认城市：" + city;
        }

        private void load_tianqi()
        {
            string Url = "https://query.asilu.com/weather/baidu/?city={0}";
            string city = ini.ReadString("BaiduTianQi", "City", "");
            uiLabel2.Text = city;
            Url = string.Format(Url, uiLabel2.Text);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string json = reader.ReadToEnd();
            baiduRoot bd = JsonConvert.DeserializeObject<baiduRoot>(json);
            uiLabel4.Text = "更新时间："+ bd.date + bd.update_time;
            foreach (var v in bd.weather)
            {
                uiDataGridView1.Rows.Add(v.date, v.weather, v.temp, v.wind);
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            uiDataGridView1.Rows.Clear();
            string Url = "https://query.asilu.com/weather/baidu/?city={0}";
            Url = string.Format(Url, uiTextBox1.Text);
            uiLabel2.Text = uiTextBox1.Text;
            Url = string.Format(Url, uiLabel2.Text);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string json = reader.ReadToEnd();
            baiduRoot bd = JsonConvert.DeserializeObject<baiduRoot>(json);
            foreach (var v in bd.weather)
            {
                uiDataGridView1.Rows.Add(v.date, v.weather, v.temp, v.wind);
            }
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            string city = uiLabel2.Text;
            ini.Write("BaiduTianQi", "City", city);
            ini.UpdateFile();
            uiLabel3.Text = "默认城市：" + city;
        }
    }
}
