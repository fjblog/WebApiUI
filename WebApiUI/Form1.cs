using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebApiUI.jinshanciba;
using WebApiUI.FanYi;
using WebApiUI.BiYing;
using WebApiUI.TianQi;
using WebApiUI.BaiDu;
using WebApiUI.HuiLv;
using WebApiUI.Jiqiren;
using WebApiUI.HuoChePiao;
using WebApiUI.LINQ;
using System.Net.NetworkInformation;
using System.Threading;

namespace WebApiUI
{
    public partial class Form1 : UIForm
    {
        static string path = Environment.CurrentDirectory;
        IniFile ini = new IniFile(path + @"\setup.ini");
        long lastSendCount = 0;
        long lastRevCount = 0;
       

        public Form1()
        {
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;

            Thread thread = new Thread(new ThreadStart(timer));
            thread.Start();
            thread.IsBackground = true;
            #region 读取ini文件获取主题颜色
            string color = ini.ReadString("Style", "UIStyle", "");
            if (color == "Blue")
            {
                this.Style = UIStyle.Blue;
            }
            else if (color == "Green")
            {
                this.Style = UIStyle.Green;
            }
            else if (color == "Orange")
            {
                this.Style = UIStyle.Orange;
            }
            else if (color == "Black")
            {
                this.Style = UIStyle.Black;
            }
            else if (color == "Gray")
            {
                this.Style = UIStyle.Gray;
            }
            else if (color == "White")
            {
                this.Style = UIStyle.White;
            }
            else if (color == "Office2010Blue")
            {
                this.Style = UIStyle.Office2010Blue;
            }
            else if (color == "Office2010Silver")
            {
                this.Style = UIStyle.Office2010Silver;
            }
            #endregion

        }

        private void timer()
        {
            uiLabel1.Text = DateTime.Now.ToString();
            pingbaidu();
            wangsu();
        }

        private void pingbaidu()
        {
            var ping = new Ping();
            var reply = ping.Send("www.baidu.com");
            uiLabel2.Text = "延迟：" + reply.RoundtripTime + "ms";
        }

        private void wangsu()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            if (nics == null || nics.Length < 1)
            {
                return;
            }

            long sendCount = 0;
            long revCount = 0;
            foreach (NetworkInterface adapter in nics)
            {
                IPv4InterfaceStatistics ipv4Statistics = adapter.GetIPv4Statistics();
                sendCount += ipv4Statistics.BytesSent;
                revCount += ipv4Statistics.BytesReceived;
            }
            string SendSpeed = ((sendCount - lastSendCount) / 1024).ToString();
            string RevSpeed = ((revCount - lastRevCount) / 1024).ToString();
            string SendCount = (sendCount / 1024 / 1024).ToString();
            string RevCount = (revCount / 1024 / 1024).ToString();
            lastRevCount = revCount;
            lastSendCount = sendCount;
            uiLabel3.Text = "上传速度：" + SendSpeed + " k/s";
            uiLabel4.Text = "下载速度：" + RevSpeed + " k/s";

        }

        private void ShowForm()
        {
            biying biying = new biying();
            Form1 form1 = new Form1();
            biying.MdiParent = this;
            biying.Style = form1.Style;
            TabPage tb = new TabPage();
            tb.Controls.Add(biying); //将窗体添加到form中
            tb.Text = biying.Text + "   "; //设定tabpage标签
            tb.Name = biying.Name; //设定tabpage的name属性，为了之后的新增和销毁处理
            uiTabControl1.TabPages.Add(tb);
            biying.Dock = DockStyle.Fill; //填充整个tabpage
            biying.Show();
            uiTabControl1.SelectedTab = uiTabControl1.TabPages[uiTabControl1.TabPages.Count - 1];
        }

        private void ThreadFunc()
        {
            MethodInvoker mi = new MethodInvoker(ShowForm);
            this.BeginInvoke(mi);
        }

        //菜单栏，关闭，主题
        private void uiNavBar1_MenuItemClick(string itemText, int menuIndex, int pageIndex)
        {
            if (menuIndex == 1)
            {
                if (itemText == "Blue")
                {
                    this.Style = UIStyle.Blue;
                    ini.Write("Style", "UIStyle", "Blue");
                    ini.UpdateFile();
                }
                else if (itemText == "Green")
                {
                    this.Style = UIStyle.Green;
                    ini.Write("Style", "UIStyle", "Green");
                    ini.UpdateFile();
                }
                else if (itemText == "Orange")
                {
                    this.Style = UIStyle.Orange;
                    ini.Write("Style", "UIStyle", "Orange");
                    ini.UpdateFile();
                }
                else if (itemText == "Black")
                {
                    this.Style = UIStyle.Black;
                    ini.Write("Style", "UIStyle", "Black");
                    ini.UpdateFile();
                }
                else if (itemText == "Gray")
                {
                    this.Style = UIStyle.Gray;
                    ini.Write("Style", "UIStyle", "Gray");
                    ini.UpdateFile();
                }
                else if (itemText == "White")
                {
                    this.Style = UIStyle.White;
                    ini.Write("Style", "UIStyle", "White");
                    ini.UpdateFile();
                }
                else if (itemText == "Office2010Blue")
                {
                    this.Style = UIStyle.Office2010Blue;
                    ini.Write("Style", "UIStyle", "Office2010Blue");
                    ini.UpdateFile();
                }
                else if (itemText == "Office2010Silver")
                {
                    this.Style = UIStyle.Office2010Silver;
                    ini.Write("Style", "UIStyle", "Office2010Silver");
                    ini.UpdateFile();
                }
            }
            else if (menuIndex == 0)
            {
                if (itemText == "关闭所有")
                {
                    int count = uiTabControl1.TabPages.Count;
                    for (int i = 0; i < count; i++)
                    {
                        uiTabControl1.TabPages.Remove(uiTabControl1.TabPages[0]);
                    }
                }
                else if (itemText == "关闭其他")
                {
                    int count = uiTabControl1.TabPages.Count;
                    for (int i = 0; i < count; i++)
                    {
                        if (uiTabControl1.SelectedTab == uiTabControl1.TabPages[0] && uiTabControl1.TabPages.Count > 1)
                        {
                            uiTabControl1.TabPages.Remove(uiTabControl1.TabPages[1]);
                        }
                        else if (uiTabControl1.TabPages.Count > 1)
                        {
                            uiTabControl1.TabPages.Remove(uiTabControl1.TabPages[0]);
                        }
                    }
                }
            }
        }

        private void uiNavMenu1_MenuItemClick(TreeNode node, NavMenuItem item, int pageIndex)
        {
            if (node.Text == "金山词霸")
            {
                jinshan js = new jinshan();
                Form1 form1 = new Form1();
                js.MdiParent = this;
                js.Style = form1.Style;
                TabPage tb = new TabPage();
                tb.Controls.Add(js); //将窗体添加到form中
                tb.Text = js.Text + "   "; //设定tabpage标签
                tb.Name = js.Name; //设定tabpage的name属性，为了之后的新增和销毁处理
                uiTabControl1.TabPages.Add(tb);
                js.Dock = DockStyle.Fill; //填充整个tabpage
                js.Show();
                uiTabControl1.SelectedTab = uiTabControl1.TabPages[uiTabControl1.TabPages.Count - 1];
            }
            else if (node.Text == "文本翻译")
            {
                fanyi fanyi = new fanyi();
                Form1 form1 = new Form1();
                fanyi.MdiParent = this;
                fanyi.Style = form1.Style;
                TabPage tb = new TabPage();
                tb.Controls.Add(fanyi); //将窗体添加到form中
                tb.Text = fanyi.Text + "   "; //设定tabpage标签
                tb.Name = fanyi.Name; //设定tabpage的name属性，为了之后的新增和销毁处理
                uiTabControl1.TabPages.Add(tb);
                fanyi.Dock = DockStyle.Fill; //填充整个tabpage
                fanyi.Show();
                uiTabControl1.SelectedTab = uiTabControl1.TabPages[uiTabControl1.TabPages.Count - 1];
            }
            else if (node.Text == "每日壁纸")
            {
                Thread thread = new Thread(new ThreadStart(ThreadFunc));
                thread.Start();
                //biying biying = new biying();
                //Form1 form1 = new Form1();
                //biying.MdiParent = this;
                //biying.Style = form1.Style;
                //TabPage tb = new TabPage();
                //tb.Controls.Add(biying); //将窗体添加到form中
                //tb.Text = biying.Text + "   "; //设定tabpage标签
                //tb.Name = biying.Name; //设定tabpage的name属性，为了之后的新增和销毁处理
                //uiTabControl1.TabPages.Add(tb);
                //biying.Dock = DockStyle.Fill; //填充整个tabpage
                //biying.Show();
                //uiTabControl1.SelectedTab = uiTabControl1.TabPages[uiTabControl1.TabPages.Count - 1];
            }
            else if (node.Text == "七天天气")
            {
                tianqi tianqi = new tianqi();
                Form1 form1 = new Form1();
                tianqi.MdiParent = this;
                tianqi.Style = form1.Style;
                TabPage tb = new TabPage();
                tb.Controls.Add(tianqi); //将窗体添加到form中
                tb.Text = tianqi.Text + "   "; //设定tabpage标签
                tb.Name = tianqi.Name; //设定tabpage的name属性，为了之后的新增和销毁处理
                uiTabControl1.TabPages.Add(tb);
                tianqi.Dock = DockStyle.Fill; //填充整个tabpage
                tianqi.Show();
                uiTabControl1.SelectedTab = uiTabControl1.TabPages[uiTabControl1.TabPages.Count - 1];
            }
            else if (node.Text == "百度天气")
            {
                baidu baidu = new baidu();
                Form1 form1 = new Form1();
                baidu.MdiParent = this;
                baidu.Style = form1.Style;
                TabPage tb = new TabPage();
                tb.Controls.Add(baidu); //将窗体添加到form中
                tb.Text = baidu.Text + "   "; //设定tabpage标签
                tb.Name = baidu.Name; //设定tabpage的name属性，为了之后的新增和销毁处理
                uiTabControl1.TabPages.Add(tb);
                baidu.Dock = DockStyle.Fill; //填充整个tabpage
                baidu.Show();
                uiTabControl1.SelectedTab = uiTabControl1.TabPages[uiTabControl1.TabPages.Count - 1];
            }
            else if (node.Text == "汇率")
            {
                huilv huilv = new huilv();
                Form1 form1 = new Form1();
                huilv.MdiParent = this;
                huilv.Style = form1.Style;
                TabPage tb = new TabPage();
                tb.Controls.Add(huilv); //将窗体添加到form中
                tb.Text = huilv.Text + "   "; //设定tabpage标签
                tb.Name = huilv.Name; //设定tabpage的name属性，为了之后的新增和销毁处理
                uiTabControl1.TabPages.Add(tb);
                huilv.Dock = DockStyle.Fill; //填充整个tabpage
                huilv.Show();
                uiTabControl1.SelectedTab = uiTabControl1.TabPages[uiTabControl1.TabPages.Count - 1];
            }
            else if (node.Text == "机器人")
            {
                jiqiren jiqiren = new jiqiren();
                Form1 form1 = new Form1();
                jiqiren.MdiParent = this;
                jiqiren.Style = form1.Style;
                TabPage tb = new TabPage();
                tb.Controls.Add(jiqiren); //将窗体添加到form中
                tb.Text = jiqiren.Text + "   "; //设定tabpage标签
                tb.Name = jiqiren.Name; //设定tabpage的name属性，为了之后的新增和销毁处理
                uiTabControl1.TabPages.Add(tb);
                jiqiren.Dock = DockStyle.Fill; //填充整个tabpage
                jiqiren.Show();
                uiTabControl1.SelectedTab = uiTabControl1.TabPages[uiTabControl1.TabPages.Count - 1];
            }
            else if (node.Text == "火车票")
            {
                huochepiao huochepiao = new huochepiao();
                Form1 form1 = new Form1();
                huochepiao.MdiParent = this;
                huochepiao.Style = form1.Style;
                TabPage tb = new TabPage();
                tb.Controls.Add(huochepiao); //将窗体添加到form中
                tb.Text = huochepiao.Text + "   "; //设定tabpage标签
                tb.Name = huochepiao.Name; //设定tabpage的name属性，为了之后的新增和销毁处理
                uiTabControl1.TabPages.Add(tb);
                huochepiao.Dock = DockStyle.Fill; //填充整个tabpage
                huochepiao.Show();
                uiTabControl1.SelectedTab = uiTabControl1.TabPages[uiTabControl1.TabPages.Count - 1];
            }
            else if (node.Text == "火车票LINQ")
            {
                HcpLinq HcpLinq = new HcpLinq();
                Form1 form1 = new Form1();
                HcpLinq.MdiParent = this;
                HcpLinq.Style = form1.Style;
                TabPage tb = new TabPage();
                tb.Controls.Add(HcpLinq); //将窗体添加到form中
                tb.Text = HcpLinq.Text + "   "; //设定tabpage标签
                tb.Name = HcpLinq.Name; //设定tabpage的name属性，为了之后的新增和销毁处理
                uiTabControl1.TabPages.Add(tb);
                HcpLinq.Dock = DockStyle.Fill; //填充整个tabpage
                HcpLinq.Show();
                uiTabControl1.SelectedTab = uiTabControl1.TabPages[uiTabControl1.TabPages.Count - 1];
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //uiLabel1.Text = DateTime.Now.ToString();
            //pingbaidu();
            //wangsu();

            timer();
        }
    }
}
