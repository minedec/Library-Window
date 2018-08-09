namespace WindowsFormsApp2
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出登录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.切换账户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.读者管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加读者信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图书管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加单本ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.批量添加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.修改单本ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.批量修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除单本ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.批量删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.流通管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图书借阅ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图书归还ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.黑名单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.记录管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.使用手册ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.用户ToolStripMenuItem,
            this.读者管理ToolStripMenuItem,
            this.图书管理ToolStripMenuItem,
            this.流通管理ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1015, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 用户ToolStripMenuItem
            // 
            this.用户ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出登录ToolStripMenuItem,
            this.切换账户ToolStripMenuItem});
            this.用户ToolStripMenuItem.Name = "用户ToolStripMenuItem";
            this.用户ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.用户ToolStripMenuItem.Text = "用户";
            // 
            // 退出登录ToolStripMenuItem
            // 
            this.退出登录ToolStripMenuItem.Name = "退出登录ToolStripMenuItem";
            this.退出登录ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.退出登录ToolStripMenuItem.Text = "切换账户";
            this.退出登录ToolStripMenuItem.Click += new System.EventHandler(this.退出登录ToolStripMenuItem_Click);
            // 
            // 切换账户ToolStripMenuItem
            // 
            this.切换账户ToolStripMenuItem.Name = "切换账户ToolStripMenuItem";
            this.切换账户ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.切换账户ToolStripMenuItem.Text = "退出登录";
            this.切换账户ToolStripMenuItem.Click += new System.EventHandler(this.切换账户ToolStripMenuItem_Click);
            // 
            // 读者管理ToolStripMenuItem
            // 
            this.读者管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加读者信息ToolStripMenuItem});
            this.读者管理ToolStripMenuItem.Name = "读者管理ToolStripMenuItem";
            this.读者管理ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.读者管理ToolStripMenuItem.Text = "读者管理";
            this.读者管理ToolStripMenuItem.Click += new System.EventHandler(this.读者管理ToolStripMenuItem_Click);
            // 
            // 添加读者信息ToolStripMenuItem
            // 
            this.添加读者信息ToolStripMenuItem.Name = "添加读者信息ToolStripMenuItem";
            this.添加读者信息ToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.添加读者信息ToolStripMenuItem.Text = "添加";
            this.添加读者信息ToolStripMenuItem.Click += new System.EventHandler(this.添加读者信息ToolStripMenuItem_Click);
            // 
            // 图书管理ToolStripMenuItem
            // 
            this.图书管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加ToolStripMenuItem,
            this.修改ToolStripMenuItem1,
            this.删除ToolStripMenuItem});
            this.图书管理ToolStripMenuItem.Name = "图书管理ToolStripMenuItem";
            this.图书管理ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.图书管理ToolStripMenuItem.Text = "图书管理";
            this.图书管理ToolStripMenuItem.Click += new System.EventHandler(this.图书管理ToolStripMenuItem_Click);
            // 
            // 添加ToolStripMenuItem
            // 
            this.添加ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加单本ToolStripMenuItem,
            this.批量添加ToolStripMenuItem});
            this.添加ToolStripMenuItem.Name = "添加ToolStripMenuItem";
            this.添加ToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.添加ToolStripMenuItem.Text = "添加";
            // 
            // 添加单本ToolStripMenuItem
            // 
            this.添加单本ToolStripMenuItem.Name = "添加单本ToolStripMenuItem";
            this.添加单本ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.添加单本ToolStripMenuItem.Text = "添加单本";
            this.添加单本ToolStripMenuItem.Click += new System.EventHandler(this.添加单本ToolStripMenuItem_Click);
            // 
            // 批量添加ToolStripMenuItem
            // 
            this.批量添加ToolStripMenuItem.Name = "批量添加ToolStripMenuItem";
            this.批量添加ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.批量添加ToolStripMenuItem.Text = "批量添加";
            this.批量添加ToolStripMenuItem.Click += new System.EventHandler(this.批量添加ToolStripMenuItem_Click);
            // 
            // 修改ToolStripMenuItem1
            // 
            this.修改ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改单本ToolStripMenuItem,
            this.批量修改ToolStripMenuItem});
            this.修改ToolStripMenuItem1.Name = "修改ToolStripMenuItem1";
            this.修改ToolStripMenuItem1.Size = new System.Drawing.Size(114, 26);
            this.修改ToolStripMenuItem1.Text = "修改";
            // 
            // 修改单本ToolStripMenuItem
            // 
            this.修改单本ToolStripMenuItem.Name = "修改单本ToolStripMenuItem";
            this.修改单本ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.修改单本ToolStripMenuItem.Text = "修改单本";
            this.修改单本ToolStripMenuItem.Click += new System.EventHandler(this.修改单本ToolStripMenuItem_Click);
            // 
            // 批量修改ToolStripMenuItem
            // 
            this.批量修改ToolStripMenuItem.Name = "批量修改ToolStripMenuItem";
            this.批量修改ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.批量修改ToolStripMenuItem.Text = "批量修改";
            this.批量修改ToolStripMenuItem.Click += new System.EventHandler(this.批量修改ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除单本ToolStripMenuItem,
            this.批量删除ToolStripMenuItem});
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.删除ToolStripMenuItem.Text = "删除";
            // 
            // 删除单本ToolStripMenuItem
            // 
            this.删除单本ToolStripMenuItem.Name = "删除单本ToolStripMenuItem";
            this.删除单本ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.删除单本ToolStripMenuItem.Text = "删除单本";
            this.删除单本ToolStripMenuItem.Click += new System.EventHandler(this.删除单本ToolStripMenuItem_Click);
            // 
            // 批量删除ToolStripMenuItem
            // 
            this.批量删除ToolStripMenuItem.Name = "批量删除ToolStripMenuItem";
            this.批量删除ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.批量删除ToolStripMenuItem.Text = "批量删除";
            this.批量删除ToolStripMenuItem.Click += new System.EventHandler(this.批量删除ToolStripMenuItem_Click);
            // 
            // 流通管理ToolStripMenuItem
            // 
            this.流通管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.图书借阅ToolStripMenuItem,
            this.图书归还ToolStripMenuItem,
            this.黑名单ToolStripMenuItem,
            this.记录管理ToolStripMenuItem});
            this.流通管理ToolStripMenuItem.Name = "流通管理ToolStripMenuItem";
            this.流通管理ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.流通管理ToolStripMenuItem.Text = "流通管理";
            // 
            // 图书借阅ToolStripMenuItem
            // 
            this.图书借阅ToolStripMenuItem.Name = "图书借阅ToolStripMenuItem";
            this.图书借阅ToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.图书借阅ToolStripMenuItem.Text = "图书借阅";
            this.图书借阅ToolStripMenuItem.Click += new System.EventHandler(this.图书借阅ToolStripMenuItem_Click);
            // 
            // 图书归还ToolStripMenuItem
            // 
            this.图书归还ToolStripMenuItem.Name = "图书归还ToolStripMenuItem";
            this.图书归还ToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.图书归还ToolStripMenuItem.Text = "图书归还";
            this.图书归还ToolStripMenuItem.Click += new System.EventHandler(this.图书归还ToolStripMenuItem_Click);
            // 
            // 黑名单ToolStripMenuItem
            // 
            this.黑名单ToolStripMenuItem.Name = "黑名单ToolStripMenuItem";
            this.黑名单ToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.黑名单ToolStripMenuItem.Text = "黑名单设置";
            this.黑名单ToolStripMenuItem.Click += new System.EventHandler(this.黑名单ToolStripMenuItem_Click);
            // 
            // 记录管理ToolStripMenuItem
            // 
            this.记录管理ToolStripMenuItem.Name = "记录管理ToolStripMenuItem";
            this.记录管理ToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.记录管理ToolStripMenuItem.Text = "记录管理";
            this.记录管理ToolStripMenuItem.Click += new System.EventHandler(this.记录管理ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.使用手册ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 使用手册ToolStripMenuItem
            // 
            this.使用手册ToolStripMenuItem.Name = "使用手册ToolStripMenuItem";
            this.使用手册ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.使用手册ToolStripMenuItem.Text = "使用手册";
            this.使用手册ToolStripMenuItem.Click += new System.EventHandler(this.使用手册ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(84, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(154, 25);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(244, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "搜索";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(19, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(300, 381);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1015, 472);
            this.splitContainer1.SplitterDistance = 661;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(655, 466);
            this.panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(344, 469);
            this.tabControl1.TabIndex = 7;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(336, 440);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "读者详情";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(336, 440);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "图书详情";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(19, 51);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 27;
            this.dataGridView2.Size = new System.Drawing.Size(300, 381);
            this.dataGridView2.TabIndex = 4;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(84, 20);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(154, 25);
            this.textBox2.TabIndex = 2;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(244, 20);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 25);
            this.button4.TabIndex = 3;
            this.button4.Text = "搜索";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 500);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图书管理系统";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 用户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出登录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 切换账户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 读者管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图书管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加读者信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem 修改ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 批量修改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 批量删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 使用手册ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加单本ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 批量添加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改单本ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除单本ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 流通管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图书借阅ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图书归还ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 黑名单ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripMenuItem 记录管理ToolStripMenuItem;
    }
}

