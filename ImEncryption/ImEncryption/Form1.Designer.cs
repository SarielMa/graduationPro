namespace ImEncryption
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.功能ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加密ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.解密ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.测试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.直方图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.相关性ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.相关性系数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.相关性图示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.信息熵ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.扩散性测试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.像素改变率NPCRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.一致平均改变强度UACIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.垂直相关性图示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.对角相关性图示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 92);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(301, 92);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(256, 256);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.功能ToolStripMenuItem,
            this.测试ToolStripMenuItem,
            this.扩散性测试ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(585, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            this.文件ToolStripMenuItem.Click += new System.EventHandler(this.文件ToolStripMenuItem_Click);
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 功能ToolStripMenuItem
            // 
            this.功能ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.加密ToolStripMenuItem,
            this.解密ToolStripMenuItem});
            this.功能ToolStripMenuItem.Name = "功能ToolStripMenuItem";
            this.功能ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.功能ToolStripMenuItem.Text = "功能";
            // 
            // 加密ToolStripMenuItem
            // 
            this.加密ToolStripMenuItem.Name = "加密ToolStripMenuItem";
            this.加密ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.加密ToolStripMenuItem.Text = "加密";
            this.加密ToolStripMenuItem.Click += new System.EventHandler(this.加密ToolStripMenuItem_Click);
            // 
            // 解密ToolStripMenuItem
            // 
            this.解密ToolStripMenuItem.Name = "解密ToolStripMenuItem";
            this.解密ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.解密ToolStripMenuItem.Text = "解密";
            this.解密ToolStripMenuItem.Click += new System.EventHandler(this.解密ToolStripMenuItem_Click);
            // 
            // 测试ToolStripMenuItem
            // 
            this.测试ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.直方图ToolStripMenuItem,
            this.相关性ToolStripMenuItem,
            this.信息熵ToolStripMenuItem});
            this.测试ToolStripMenuItem.Name = "测试ToolStripMenuItem";
            this.测试ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.测试ToolStripMenuItem.Text = "统计分析";
            // 
            // 直方图ToolStripMenuItem
            // 
            this.直方图ToolStripMenuItem.Name = "直方图ToolStripMenuItem";
            this.直方图ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.直方图ToolStripMenuItem.Text = "直方图";
            this.直方图ToolStripMenuItem.Click += new System.EventHandler(this.直方图ToolStripMenuItem_Click);
            // 
            // 相关性ToolStripMenuItem
            // 
            this.相关性ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.相关性系数ToolStripMenuItem,
            this.相关性图示ToolStripMenuItem,
            this.垂直相关性图示ToolStripMenuItem,
            this.对角相关性图示ToolStripMenuItem});
            this.相关性ToolStripMenuItem.Name = "相关性ToolStripMenuItem";
            this.相关性ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.相关性ToolStripMenuItem.Text = "相关性";
            // 
            // 相关性系数ToolStripMenuItem
            // 
            this.相关性系数ToolStripMenuItem.Name = "相关性系数ToolStripMenuItem";
            this.相关性系数ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.相关性系数ToolStripMenuItem.Text = "相关性系数";
            this.相关性系数ToolStripMenuItem.Click += new System.EventHandler(this.相关性系数ToolStripMenuItem_Click);
            // 
            // 相关性图示ToolStripMenuItem
            // 
            this.相关性图示ToolStripMenuItem.Name = "相关性图示ToolStripMenuItem";
            this.相关性图示ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.相关性图示ToolStripMenuItem.Text = "水平相关性图示";
            this.相关性图示ToolStripMenuItem.Click += new System.EventHandler(this.相关性图示ToolStripMenuItem_Click);
            // 
            // 信息熵ToolStripMenuItem
            // 
            this.信息熵ToolStripMenuItem.Name = "信息熵ToolStripMenuItem";
            this.信息熵ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.信息熵ToolStripMenuItem.Text = "信息熵";
            this.信息熵ToolStripMenuItem.Click += new System.EventHandler(this.信息熵ToolStripMenuItem_Click);
            // 
            // 扩散性测试ToolStripMenuItem
            // 
            this.扩散性测试ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.像素改变率NPCRToolStripMenuItem,
            this.一致平均改变强度UACIToolStripMenuItem});
            this.扩散性测试ToolStripMenuItem.Name = "扩散性测试ToolStripMenuItem";
            this.扩散性测试ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.扩散性测试ToolStripMenuItem.Text = "扩散性测试";
            // 
            // 像素改变率NPCRToolStripMenuItem
            // 
            this.像素改变率NPCRToolStripMenuItem.Name = "像素改变率NPCRToolStripMenuItem";
            this.像素改变率NPCRToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.像素改变率NPCRToolStripMenuItem.Text = "像素改变率（NPCR）";
            this.像素改变率NPCRToolStripMenuItem.Click += new System.EventHandler(this.像素改变率NPCRToolStripMenuItem_Click);
            // 
            // 一致平均改变强度UACIToolStripMenuItem
            // 
            this.一致平均改变强度UACIToolStripMenuItem.Name = "一致平均改变强度UACIToolStripMenuItem";
            this.一致平均改变强度UACIToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.一致平均改变强度UACIToolStripMenuItem.Text = "一致平均改变强度（UACI）";
            this.一致平均改变强度UACIToolStripMenuItem.Click += new System.EventHandler(this.一致平均改变强度UACIToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(387, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            // 
            // 垂直相关性图示ToolStripMenuItem
            // 
            this.垂直相关性图示ToolStripMenuItem.Name = "垂直相关性图示ToolStripMenuItem";
            this.垂直相关性图示ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.垂直相关性图示ToolStripMenuItem.Text = "垂直相关性图示";
            this.垂直相关性图示ToolStripMenuItem.Click += new System.EventHandler(this.垂直相关性图示ToolStripMenuItem_Click);
            // 
            // 对角相关性图示ToolStripMenuItem
            // 
            this.对角相关性图示ToolStripMenuItem.Name = "对角相关性图示ToolStripMenuItem";
            this.对角相关性图示ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.对角相关性图示ToolStripMenuItem.Text = "对角相关性图示";
            this.对角相关性图示ToolStripMenuItem.Click += new System.EventHandler(this.对角相关性图示ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 360);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 功能ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 加密ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 解密ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 测试ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 直方图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 相关性ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 信息熵ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 相关性系数ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 相关性图示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 扩散性测试ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 像素改变率NPCRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 一致平均改变强度UACIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 垂直相关性图示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 对角相关性图示ToolStripMenuItem;
    }
}

