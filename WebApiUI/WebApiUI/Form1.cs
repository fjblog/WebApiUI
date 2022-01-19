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

namespace WebApiUI
{
    public partial class Form1 : UIForm
    {

        static string path = Environment.CurrentDirectory;
        IniFile ini = new IniFile(path + @"\setup.ini");

        public Form1()
        {
            InitializeComponent();

            uiLabel1.Text = "日期：" + DateTime.Now.ToString().Substring(0, 11);

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
                //form2.FormBorderStyle = FormBorderStyle.None; //去除原form自带的边框
                js.Dock = DockStyle.Fill; //填充整个tabpage
                js.Show();
                uiTabControl1.SelectedTab = uiTabControl1.TabPages[uiTabControl1.TabPages.Count - 1];
            }
            else if(node.Text == "文本翻译")
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
                //form2.FormBorderStyle = FormBorderStyle.None; //去除原form自带的边框
                fanyi.Dock = DockStyle.Fill; //填充整个tabpage
                fanyi.Show();
                uiTabControl1.SelectedTab = uiTabControl1.TabPages[uiTabControl1.TabPages.Count - 1];
            }
            else if (node.Text == "每日壁纸")
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
                //form2.FormBorderStyle = FormBorderStyle.None; //去除原form自带的边框
                biying.Dock = DockStyle.Fill; //填充整个tabpage
                biying.Show();
                uiTabControl1.SelectedTab = uiTabControl1.TabPages[uiTabControl1.TabPages.Count - 1];
            }
        }

    }
}
