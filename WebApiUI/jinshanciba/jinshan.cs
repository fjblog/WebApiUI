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

namespace WebApiUI.jinshanciba
{
    public partial class jinshan : UIForm
    {
        public jinshan()
        {
            InitializeComponent();
            uiDataGridView1.Visible = false;
        }

        private void jinshan_chaxun()
        {
            uiDataGridView1.Rows.Clear();
            string Url = "https://dict-mobile.iciba.com/interface/index.php?c=word&m=getsuggest&nums={0}&is_need_mean=1&word={1}";
            Url = string.Format(Url, uiComboBox1.Text, uiTextBox1.Text);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string json = reader.ReadToEnd();
            JinShanRoot js = JsonConvert.DeserializeObject<JinShanRoot>(json);
            uiDataGridView1.Visible = true;
            uiDataGridView1.Font = new Font("微软雅黑", 10);
            foreach (var v in js.message)
            {
                uiDataGridView1.Rows.Add(v.key, v.paraphrase);
            }
        }
        private void uiButton1_Click(object sender, EventArgs e)
        {
            if(uiTextBox1.Text == "")
            {
                UIMessageTip.Show("不能为空");
            }
            else
            {
                jinshan_chaxun();
            }
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            uiTextBox1.Clear();
            uiComboBox1.Text = "10";
        }

        private void uiComboBox1_Load(object sender, EventArgs e)
        {
            uiComboBox1.Items.Add("5");
            uiComboBox1.Items.Add("10");
            uiComboBox1.Items.Add("20");
            uiComboBox1.Items.Add("50");
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uiSymbolButton1_Click(sender,e);
            uiTextBox1.Text = uiDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            jinshan_chaxun();
        }

        private void uiDataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            //避免选择表头和行号报错
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                uiDataGridView1.CurrentCell = uiDataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }
    }
}
