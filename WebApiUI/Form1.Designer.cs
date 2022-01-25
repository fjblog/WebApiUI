namespace WebApiUI
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("关闭其他");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("关闭所有");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("关闭", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Blue");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Green");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Orange");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Black");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Gray");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("White");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Office2010Blue");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Office2010Silver");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("主题", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("金山词霸");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("文本翻译");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("翻译", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("每日壁纸");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("必应每日壁纸", new System.Windows.Forms.TreeNode[] {
            treeNode16});
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("七天天气");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("百度天气");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("天气预报", new System.Windows.Forms.TreeNode[] {
            treeNode18,
            treeNode19});
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("汇率");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("机器人");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("火车票");
            this.uiNavBar1 = new Sunny.UI.UINavBar();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiSplitContainer1 = new Sunny.UI.UISplitContainer();
            this.uiNavMenu1 = new Sunny.UI.UINavMenu();
            this.uiTabControl1 = new Sunny.UI.UITabControl();
            this.uiNavBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiSplitContainer1)).BeginInit();
            this.uiSplitContainer1.Panel1.SuspendLayout();
            this.uiSplitContainer1.Panel2.SuspendLayout();
            this.uiSplitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiNavBar1
            // 
            this.uiNavBar1.Controls.Add(this.uiLabel1);
            this.uiNavBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiNavBar1.DropMenuFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiNavBar1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiNavBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.uiNavBar1.Location = new System.Drawing.Point(2, 35);
            this.uiNavBar1.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uiNavBar1.Name = "uiNavBar1";
            treeNode1.Name = "节点0";
            treeNode1.Text = "关闭其他";
            treeNode2.Name = "节点1";
            treeNode2.Text = "关闭所有";
            treeNode3.Name = "节点0";
            treeNode3.Text = "关闭";
            treeNode4.Name = "节点0";
            treeNode4.Text = "Blue";
            treeNode5.Name = "节点1";
            treeNode5.Text = "Green";
            treeNode6.Name = "节点2";
            treeNode6.Text = "Orange";
            treeNode7.Name = "节点3";
            treeNode7.Text = "Black";
            treeNode8.Name = "节点4";
            treeNode8.Text = "Gray";
            treeNode9.Name = "节点5";
            treeNode9.Text = "White";
            treeNode10.Name = "节点0";
            treeNode10.Text = "Office2010Blue";
            treeNode11.Name = "节点1";
            treeNode11.Text = "Office2010Silver";
            treeNode12.Name = "节点1";
            treeNode12.Text = "主题";
            this.uiNavBar1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode12});
            this.uiNavBar1.Size = new System.Drawing.Size(1546, 43);
            this.uiNavBar1.TabIndex = 0;
            this.uiNavBar1.Text = "uiNavBar1";
            this.uiNavBar1.MenuItemClick += new Sunny.UI.UINavBar.OnMenuItemClick(this.uiNavBar1_MenuItemClick);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.ForeColor = System.Drawing.Color.White;
            this.uiLabel1.Location = new System.Drawing.Point(4, 0);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(320, 40);
            this.uiLabel1.StyleCustomMode = true;
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "uiLabel1";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiSplitContainer1
            // 
            this.uiSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.uiSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiSplitContainer1.Location = new System.Drawing.Point(2, 78);
            this.uiSplitContainer1.Name = "uiSplitContainer1";
            // 
            // uiSplitContainer1.Panel1
            // 
            this.uiSplitContainer1.Panel1.Controls.Add(this.uiNavMenu1);
            // 
            // uiSplitContainer1.Panel2
            // 
            this.uiSplitContainer1.Panel2.Controls.Add(this.uiTabControl1);
            this.uiSplitContainer1.Size = new System.Drawing.Size(1546, 820);
            this.uiSplitContainer1.SplitterDistance = 261;
            this.uiSplitContainer1.SplitterWidth = 11;
            this.uiSplitContainer1.TabIndex = 1;
            // 
            // uiNavMenu1
            // 
            this.uiNavMenu1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.uiNavMenu1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiNavMenu1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.uiNavMenu1.ExpandSelectFirst = false;
            this.uiNavMenu1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiNavMenu1.FullRowSelect = true;
            this.uiNavMenu1.ItemHeight = 50;
            this.uiNavMenu1.Location = new System.Drawing.Point(0, 0);
            this.uiNavMenu1.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uiNavMenu1.Name = "uiNavMenu1";
            treeNode13.Name = "节点1";
            treeNode13.Text = "金山词霸";
            treeNode14.Name = "节点2";
            treeNode14.Text = "文本翻译";
            treeNode15.Name = "节点0";
            treeNode15.Text = "翻译";
            treeNode16.Name = "节点1";
            treeNode16.Text = "每日壁纸";
            treeNode17.Name = "节点0";
            treeNode17.Text = "必应每日壁纸";
            treeNode18.Name = "节点1";
            treeNode18.Text = "七天天气";
            treeNode19.Name = "节点2";
            treeNode19.Text = "百度天气";
            treeNode20.Name = "节点0";
            treeNode20.Text = "天气预报";
            treeNode21.Name = "节点3";
            treeNode21.Text = "汇率";
            treeNode22.Name = "节点0";
            treeNode22.Text = "机器人";
            treeNode23.Name = "节点0";
            treeNode23.Text = "火车票";
            this.uiNavMenu1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode17,
            treeNode20,
            treeNode21,
            treeNode22,
            treeNode23});
            this.uiNavMenu1.ShowLines = false;
            this.uiNavMenu1.Size = new System.Drawing.Size(261, 820);
            this.uiNavMenu1.Style = Sunny.UI.UIStyle.Custom;
            this.uiNavMenu1.TabIndex = 0;
            this.uiNavMenu1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiNavMenu1.MenuItemClick += new Sunny.UI.UINavMenu.OnMenuItemClick(this.uiNavMenu1_MenuItemClick);
            // 
            // uiTabControl1
            // 
            this.uiTabControl1.DisposeTabPageAfterRemove = true;
            this.uiTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTabControl1.ItemSize = new System.Drawing.Size(180, 40);
            this.uiTabControl1.Location = new System.Drawing.Point(0, 0);
            this.uiTabControl1.MainPage = "";
            this.uiTabControl1.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uiTabControl1.Name = "uiTabControl1";
            this.uiTabControl1.SelectedIndex = 0;
            this.uiTabControl1.ShowCloseButton = true;
            this.uiTabControl1.Size = new System.Drawing.Size(1274, 820);
            this.uiTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl1.TabBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.uiTabControl1.TabIndex = 0;
            this.uiTabControl1.TabSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.uiTabControl1.TabUnSelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiTabControl1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1550, 900);
            this.Controls.Add(this.uiSplitContainer1);
            this.Controls.Add(this.uiNavBar1);
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(2, 35, 2, 2);
            this.ShowDragStretch = true;
            this.ShowRadius = false;
            this.Text = "API工具箱";
            this.uiNavBar1.ResumeLayout(false);
            this.uiSplitContainer1.Panel1.ResumeLayout(false);
            this.uiSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiSplitContainer1)).EndInit();
            this.uiSplitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UINavBar uiNavBar1;
        private Sunny.UI.UISplitContainer uiSplitContainer1;
        private Sunny.UI.UINavMenu uiNavMenu1;
        private Sunny.UI.UITabControl uiTabControl1;
        private Sunny.UI.UILabel uiLabel1;
    }
}

