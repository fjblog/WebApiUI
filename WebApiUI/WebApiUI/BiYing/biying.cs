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

namespace WebApiUI.BiYing
{
    public partial class biying : UIForm
    {
        public biying()
        {
            InitializeComponent();

        }


        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PictureBox pb = uiContextMenuStrip1.SourceControl as PictureBox;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "jpg图片|*.JPG|png图片|Bmp 图片|*.bmp|*.PNG|jpeg图片|*.JPEG";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = pb.Name;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string pictureName = saveFileDialog.FileName;
                using (MemoryStream mem = new MemoryStream())
                {
                    Bitmap bmp = new Bitmap(pb.Image);
                    bmp.Save(@pictureName, pb.Image.RawFormat);
                    bmp.Dispose();
                    UIMessageBox.Show("图片保存成功！");
                }
            }

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            foreach (Control c in uiPanel2.Controls)
            {
                c.Dispose();
                GC.Collect();
            }
            
            uiPanel2.Controls.Clear();
               
            string ApiUrl = @"https://www.bing.com/HPImageArchive.aspx?format=js&idx={0}&n={1}&mkt=ZH-CN";
            ApiUrl = string.Format(ApiUrl, uiIntegerUpDown1.Value, uiIntegerUpDown2.Value);
            string PicUrl;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ApiUrl);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string json = reader.ReadToEnd();
            BiYingRoot by = JsonConvert.DeserializeObject<BiYingRoot>(json);

            int x = 120, y = 50;
            int lx = 120, ly = 0;
            int i = 1;
            foreach (var v in by.images)
            {
                PicUrl = @"https://cn.bing.com" + v.url;

                //创建Label
                UILabel lbl = new UILabel();
                lbl.Name = "uilabel" + i;
                i++;
                lbl.Width = 920;
                lbl.Height = 30;
                lbl.Font = new Font("微软雅黑", 10);
                lbl.Location = new Point(lx, ly);
                lbl.Text = v.startdate + "  " + v.copyright;
                ly = ly + 550;
                uiPanel2.Controls.Add(lbl);


                //创建pictureBox
                PictureBox pictureBox = new PictureBox();
                string name = v.copyright.Substring(0, v.copyright.IndexOf("("));
                pictureBox.Name = name;
                pictureBox.Width = 720;
                pictureBox.Height = 480;
                pictureBox.Location = new Point(x, y);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                uiPanel2.Controls.Add(pictureBox);
                pictureBox.ContextMenuStrip = uiContextMenuStrip1;
                y = y + 550;
                pictureBox.Image = Image.FromStream(WebRequest.Create(PicUrl).GetResponse().GetResponseStream());
            }
        }

        private void 设为壁纸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(@"E:\wallpaper")== false)
            {
                Directory.CreateDirectory(@"E:\wallpaper");
            }
            PictureBox pb = uiContextMenuStrip1.SourceControl as PictureBox;
            //保存图片为bmp格式
            pb.Image.Save(@"E:\wallpaper\Wallpaper1.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            string filePath = @"E:\wallpaper\Wallpaper1.bmp";
            Wallpaper wallpaper = new Wallpaper();  
            wallpaper.ChangeWallPaper(filePath);    
             
        }
    }
}
