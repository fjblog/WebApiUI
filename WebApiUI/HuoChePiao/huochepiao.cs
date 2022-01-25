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

namespace WebApiUI.HuoChePiao 
{
    public partial class huochepiao : UIForm
{
    public huochepiao()
    {
        InitializeComponent();
        dateTimePicker1.MinDate = DateTime.Now.Date;
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
        return root;
    }

    private void add_checkbox()
    {
        Root root = QueryTicket();
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

    private void uiButton1_Click(object sender, EventArgs e)
    {
        uiDataGridView1.DataSource = null;
        uiDataGridView1.Rows.Clear();
        if (checkedListBox1.Items.Count == 0)
        {
            add_checkbox();
        }
        Root root = QueryTicket();

        if (root.data.count == 0)
        {
            MessageBox.Show("无");
        }
        else
        {
            //不选CheckBox
            if (checkedListBox1.CheckedItems.Count == 0 && checkedListBox2.CheckedItems.Count == 0 && checkedListBox3.CheckedItems.Count == 0)
            {
                foreach (var v in root.data.list)
                {

                    uiDataGridView1.Rows.Add(v.trainNum, v.trainTypeName, v.departStationName, v.destStationName, v.departDepartTime,
                            v.destArriveTime, v.durationStr);
                }
            }
            //只选择车型
            if (checkedListBox1.CheckedItems.Count > 0 && checkedListBox2.CheckedItems.Count == 0 && checkedListBox3.CheckedItems.Count == 0)
            {
                foreach (var v in root.data.list)
                {
                    foreach (var v1 in checkedListBox1.CheckedItems)
                    {
                        if (v1.ToString().Substring(2) == v.trainTypeName)
                        {

                            uiDataGridView1.Rows.Add(v.trainNum, v.trainTypeName, v.departStationName, v.destStationName, v.departDepartTime,
                            v.destArriveTime, v.durationStr);
                        }
                    }
                }
            }

            //选择车型和出发车站
            if (checkedListBox1.CheckedItems.Count > 0 && checkedListBox2.CheckedItems.Count > 0 && checkedListBox3.CheckedItems.Count == 0)
            {
                foreach (var v in root.data.list)
                {
                    foreach (var v2 in checkedListBox2.CheckedItems)
                    {
                        if (v2.ToString() == v.departStationName)
                        {
                            foreach (var v1 in checkedListBox1.CheckedItems)
                            {
                                if (v1.ToString().Substring(2) == v.trainTypeName)
                                {
                                    uiDataGridView1.Rows.Add(v.trainNum, v.trainTypeName, v.departStationName, v.destStationName, v.departDepartTime,
                                    v.destArriveTime, v.durationStr);
                                }
                            }
                        }

                    }
                }
            }

            //全选
            if (checkedListBox1.CheckedItems.Count > 0 && checkedListBox2.CheckedItems.Count > 0 && checkedListBox3.CheckedItems.Count > 0)
            {
                foreach (var v in root.data.list)
                {
                    foreach (var v3 in checkedListBox3.CheckedItems)
                    {
                        if (v3.ToString() == v.destStationName)
                        {
                            foreach (var v2 in checkedListBox2.CheckedItems)
                            {
                                if (v2.ToString() == v.departStationName)
                                {
                                    foreach (var v1 in checkedListBox1.CheckedItems)
                                    {
                                        if (v1.ToString().Substring(2) == v.trainTypeName)
                                        {
                                            uiDataGridView1.Rows.Add(v.trainNum, v.trainTypeName, v.departStationName, v.destStationName, v.departDepartTime,
                                            v.destArriveTime, v.durationStr);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            //只选择出发车站
            if (checkedListBox1.CheckedItems.Count == 0 && checkedListBox2.CheckedItems.Count > 0 && checkedListBox3.CheckedItems.Count == 0)
            {
                foreach (var v in root.data.list)
                {
                    foreach (var v2 in checkedListBox2.CheckedItems)
                    {
                        if (v2.ToString() == v.departStationName)
                        {
                            uiDataGridView1.Rows.Add(v.trainNum, v.trainTypeName, v.departStationName, v.destStationName, v.departDepartTime,
                            v.destArriveTime, v.durationStr);
                        }
                    }
                }
            }

            //只选择到达车站
            if (checkedListBox1.CheckedItems.Count == 0 && checkedListBox2.CheckedItems.Count == 0 && checkedListBox3.CheckedItems.Count > 0)
            {
                foreach (var v in root.data.list)
                {
                    foreach (var v3 in checkedListBox3.CheckedItems)
                    {
                        if (v3.ToString() == v.destStationName)
                        {
                            uiDataGridView1.Rows.Add(v.trainNum, v.trainTypeName, v.departStationName, v.destStationName, v.departDepartTime,
                            v.destArriveTime, v.durationStr);
                        }
                    }
                }
            }

            //选择车型和到达车站
            if (checkedListBox1.CheckedItems.Count > 0 && checkedListBox2.CheckedItems.Count == 0 && checkedListBox3.CheckedItems.Count > 0)
            {
                foreach (var v in root.data.list)
                {
                    foreach (var v3 in checkedListBox3.CheckedItems)
                    {
                        if (v3.ToString() == v.destStationName)
                        {
                            foreach (var v1 in checkedListBox1.CheckedItems)
                            {
                                if (v1.ToString().Substring(2) == v.trainTypeName)
                                {
                                    uiDataGridView1.Rows.Add(v.trainNum, v.trainTypeName, v.departStationName, v.destStationName, v.departDepartTime,
                                    v.destArriveTime, v.durationStr);
                                }
                            }
                        }

                    }
                }
            }

            //选择出发车站和到达车站
            if (checkedListBox1.CheckedItems.Count == 0 && checkedListBox2.CheckedItems.Count > 0 && checkedListBox3.CheckedItems.Count > 0)
            {
                foreach (var v in root.data.list)
                {
                    foreach (var v3 in checkedListBox3.CheckedItems)
                    {
                        if (v3.ToString() == v.destStationName)
                        {
                            foreach (var v2 in checkedListBox2.CheckedItems)
                            {
                                if (v2.ToString() == v.departStationName)
                                {
                                    uiDataGridView1.Rows.Add(v.trainNum, v.trainTypeName, v.departStationName, v.destStationName, v.departDepartTime,
                                    v.destArriveTime, v.durationStr);
                                }
                            }
                        }

                    }
                }
            }
        }
        uiLabel1.Text = "共计" + uiDataGridView1.RowCount.ToString() + "个车次";
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
