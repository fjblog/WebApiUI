using HuoChePiao.entity;
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

namespace WebApiUI.LINQ
{
    public partial class HcpLinq : UIForm
    {
        List<list> linq_list = new List<list>();
        List<list> result_list = new List<list>();
        public HcpLinq()
        {
            InitializeComponent();
            dateTimePicker1.MinDate = DateTime.Now.Date.AddDays(1);
            dateTimePicker1.MaxDate = DateTime.Now.Date.AddMonths(1);

            uiDataGridView1.Font = new Font("微软雅黑", 10);
            uiDataGridView2.Font = new Font("微软雅黑", 10);

        }

        private Root QueryTicket()
        {
            string Url = "https://huoche.tuniu.com/yii.php?r=train/trainTicket/getTickets&primary[departureDate]={0}&primary[departureCityName]={1}&primary[arrivalCityName]={2}";
            Url = string.Format(Url, dateTimePicker1.Text, uiTextBox1.Text, uiTextBox2.Text);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string json = reader.ReadToEnd();
            Root root = JsonConvert.DeserializeObject<Root>(json);
            if (root.data.count == 0)
            {
                return null;
            }
            return root;
        }

        private List<list> get_list()
        {
            List<list> list = new List<list>();
            Root root = QueryTicket();
            if (root != null)
            { 
                foreach (var v in root.data.list)
                {
                    list.Add(new list()
                    {
                        trainNum = v.trainNum,
                        trainTypeName = v.trainTypeName,
                        departStationName = v.departStationName,
                        destStationName = v.destStationName,
                        departDepartTime = v.departDepartTime,
                        destArriveTime = v.destArriveTime,
                        durationStr = v.durationStr
                    });
                }
            }
            return list;
        }

        private void dgv_Header()
        {
            uiDataGridView1.Columns[0].HeaderText = "车次";
            uiDataGridView1.Columns[1].HeaderText = "车型";
            uiDataGridView1.Columns[2].HeaderText = "出发站";
            uiDataGridView1.Columns[3].HeaderText = "到达站";
            uiDataGridView1.Columns[4].HeaderText = "出发时间";
            uiDataGridView1.Columns[5].HeaderText = "到达时间";
            uiDataGridView1.Columns[6].HeaderText = "历时";
        }

        private void add_checkbox()
        {
            Root root = QueryTicket();
            if (root != null)
            {
                foreach (var v in root.data.filter.filter)
                {
                    if (v.id == "trainTypes")
                    {
                        foreach (var v1 in v.pros)
                        {
                            checkedListBox1.Items.Add(v1.name);
                        }
                    }
                    if (v.id == "departureStations")
                    {
                        foreach (var v1 in v.pros)
                        {
                            checkedListBox2.Items.Add(v1.name);
                        }
                    }
                    if (v.id == "arrivalStations")
                    {
                        foreach (var v1 in v.pros)
                        {
                            checkedListBox3.Items.Add(v1.name);
                        }
                    }
                }
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            DateTime before = System.DateTime.Now;

            List<list> list = get_list();
            linq_list.Clear();
            result_list.Clear();
            uiDataGridView1.DataSource = null;
            uiDataGridView1.Rows.Clear();
            if (checkedListBox1.Items.Count == 0)
            {
                add_checkbox();
            }
            Root root = QueryTicket();

            if (root != null)
            {
                //不选CheckBox
                if (checkedListBox1.CheckedItems.Count == 0 && checkedListBox2.CheckedItems.Count == 0 && checkedListBox3.CheckedItems.Count == 0)
                {
                    uiDataGridView1.DataSource = get_list();
                    dgv_Header();
                }
                //只选择车型
                if (checkedListBox1.CheckedItems.Count > 0 && checkedListBox2.CheckedItems.Count == 0 && checkedListBox3.CheckedItems.Count == 0)
                {
                    foreach (var v1 in checkedListBox1.CheckedItems)
                    {
                        //使用linq查询集合,Union取两个集合的并集
                        linq_list = (from c in list where c.trainTypeName == v1.ToString().Substring(2) select c).ToList();
                        result_list = result_list.Union(linq_list).ToList();
                    }
                    uiDataGridView1.DataSource = result_list;
                    dgv_Header();
                }

                //选择车型和出发车站
                if (checkedListBox1.CheckedItems.Count > 0 && checkedListBox2.CheckedItems.Count > 0 && checkedListBox3.CheckedItems.Count == 0)
                {
                    foreach (var v2 in checkedListBox2.CheckedItems)
                    {
                        foreach (var v1 in checkedListBox1.CheckedItems)
                        {
                            linq_list = (from c in list
                                         where c.trainTypeName == v1.ToString().Substring(2) &&
                          c.departStationName == v2.ToString()
                                         select c).ToList();
                            result_list = result_list.Union(linq_list).ToList();
                        }
                    }
                    uiDataGridView1.DataSource = result_list;
                    dgv_Header();
                }

                //全选
                if (checkedListBox1.CheckedItems.Count > 0 && checkedListBox2.CheckedItems.Count > 0 && checkedListBox3.CheckedItems.Count > 0)
                {
                    foreach (var v3 in checkedListBox3.CheckedItems)
                    {
                        foreach (var v2 in checkedListBox2.CheckedItems)
                        {
                            foreach (var v1 in checkedListBox1.CheckedItems)
                            {
                                linq_list = (from c in list
                                             where c.trainTypeName == v1.ToString().Substring(2) &&
                              c.departStationName == v2.ToString() &&
                              c.destStationName == v3.ToString()
                                             select c).ToList();
                                result_list = result_list.Union(linq_list).ToList();
                            }
                        }
                    }
                    uiDataGridView1.DataSource = result_list;
                    dgv_Header();
                }

                //只选择出发车站
                if (checkedListBox1.CheckedItems.Count == 0 && checkedListBox2.CheckedItems.Count > 0 && checkedListBox3.CheckedItems.Count == 0)
                {
                    foreach (var v2 in checkedListBox2.CheckedItems)
                    {
                        linq_list = (from c in list where c.departStationName == v2.ToString() select c).ToList();
                        result_list = result_list.Union(linq_list).ToList();
                    }
                    uiDataGridView1.DataSource = result_list;
                    dgv_Header();
                }

                //只选择到达车站
                if (checkedListBox1.CheckedItems.Count == 0 && checkedListBox2.CheckedItems.Count == 0 && checkedListBox3.CheckedItems.Count > 0)
                {
                    foreach (var v3 in checkedListBox3.CheckedItems)
                    {
                        linq_list = (from c in list where c.destStationName == v3.ToString() select c).ToList();
                        result_list = result_list.Union(linq_list).ToList();
                    }
                    uiDataGridView1.DataSource = result_list;
                    dgv_Header();
                }

                //选择车型和到达车站
                if (checkedListBox1.CheckedItems.Count > 0 && checkedListBox2.CheckedItems.Count == 0 && checkedListBox3.CheckedItems.Count > 0)
                {
                    foreach (var v3 in checkedListBox3.CheckedItems)
                    {
                        foreach (var v1 in checkedListBox1.CheckedItems)
                        {
                            linq_list = (from c in list
                                         where c.trainTypeName == v1.ToString().Substring(2) &&
                          c.destStationName == v3.ToString()
                                         select c).ToList();
                            result_list = result_list.Union(linq_list).ToList();
                        }
                    }
                    uiDataGridView1.DataSource = result_list;
                    dgv_Header();
                }

                //选择出发车站和到达车站
                if (checkedListBox1.CheckedItems.Count == 0 && checkedListBox2.CheckedItems.Count > 0 && checkedListBox3.CheckedItems.Count > 0)
                {
                    foreach (var v3 in checkedListBox3.CheckedItems)
                    {
                        foreach (var v2 in checkedListBox2.CheckedItems)
                        {
                            linq_list = (from c in list
                                         where c.departStationName == v2.ToString() &&
                          c.destStationName == v3.ToString()
                                         select c).ToList();
                            result_list = result_list.Union(linq_list).ToList();
                        }
                    }
                    uiDataGridView1.DataSource = result_list;
                    dgv_Header();
                }
            }
            else
            {
                MessageBox.Show("未找到从 " + uiTextBox1.Text + " 到 " + uiTextBox2.Text + " 的列车");
            }
            uiLabel1.Text = "共计" + uiDataGridView1.RowCount.ToString() + "个车次";
            DateTime after = System.DateTime.Now;
            TimeSpan ts = after.Subtract(before);
            MessageBox.Show("用时：" + ts.ToString());
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            string str = uiTextBox1.Text;
            uiTextBox1.Text = uiTextBox2.Text;
            uiTextBox2.Text = str;
        }

        private void uiDataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            uiDataGridView2.ClearAll();
            DataGridViewTextBoxColumn dgc = new DataGridViewTextBoxColumn();
            dgc.HeaderText = "车次";
            uiDataGridView2.Columns.Add(dgc);
            uiDataGridView2.Rows.Add();
            uiDataGridView2.Rows.Add();

            Root root = QueryTicket();
            int i = 1;
            foreach (var v in root.data.list)
            {
                if (v.trainNum == uiDataGridView1.SelectedRows[0].Cells[0].Value.ToString())
                {
                    foreach (var v1 in v.prices)
                    {
                        DataGridViewTextBoxColumn dgc1 = new DataGridViewTextBoxColumn();
                        dgc1.HeaderText = v1.seatName;
                        uiDataGridView2.Columns.Add(dgc1);
                        uiDataGridView2.Rows[0].Cells[0].Value = uiDataGridView1.SelectedRows[0].Cells[0].Value;
                        uiDataGridView2.Rows[0].Cells[i].Value = v1.leftNumber;
                        uiDataGridView2.Rows[1].Cells[i].Value = v1.price;
                        i++;
                    }
                }
            }

            uiDataGridView2.Rows[0].HeaderCell.Value = "票数";
            uiDataGridView2.Rows[1].HeaderCell.Value = "价格";
        }

        private void uiTextBox1_TextChanged(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            checkedListBox2.Items.Clear();
            checkedListBox3.Items.Clear();
        }

        private void uiTextBox2_TextChanged(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            checkedListBox2.Items.Clear();
            checkedListBox3.Items.Clear();
        }

    }
}
