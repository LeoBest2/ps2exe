namespace ps2exe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.checkBoxHidden = new System.Windows.Forms.CheckBox();
            this.radioBoxDoNet3_5 = new System.Windows.Forms.RadioButton();
            this.radioBoxDoNet4_0 = new System.Windows.Forms.RadioButton();
            this.checkBoxRunAsAdmin = new System.Windows.Forms.CheckBox();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.labelLog = new System.Windows.Forms.Label();
            this.btnIcon = new System.Windows.Forms.Button();
            this.textBoxIco = new System.Windows.Forms.TextBox();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUsage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "ps脚本|*.ps1|所有文件|*.*";
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Enabled = false;
            this.textBoxFilePath.Location = new System.Drawing.Point(12, 40);
            this.textBoxFilePath.Multiline = true;
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.Size = new System.Drawing.Size(461, 35);
            this.textBoxFilePath.TabIndex = 0;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(477, 52);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(93, 23);
            this.btnOpenFile.TabIndex = 1;
            this.btnOpenFile.Text = "选择源文件";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(479, 148);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(91, 23);
            this.btnConvert.TabIndex = 2;
            this.btnConvert.Text = "开始生成";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // checkBoxHidden
            // 
            this.checkBoxHidden.AutoSize = true;
            this.checkBoxHidden.Location = new System.Drawing.Point(215, 148);
            this.checkBoxHidden.Name = "checkBoxHidden";
            this.checkBoxHidden.Size = new System.Drawing.Size(96, 16);
            this.checkBoxHidden.TabIndex = 4;
            this.checkBoxHidden.Text = "是否隐藏执行";
            this.checkBoxHidden.UseVisualStyleBackColor = true;
            // 
            // radioBoxDoNet3_5
            // 
            this.radioBoxDoNet3_5.AutoSize = true;
            this.radioBoxDoNet3_5.Location = new System.Drawing.Point(10, 148);
            this.radioBoxDoNet3_5.Name = "radioBoxDoNet3_5";
            this.radioBoxDoNet3_5.Size = new System.Drawing.Size(77, 16);
            this.radioBoxDoNet3_5.TabIndex = 5;
            this.radioBoxDoNet3_5.TabStop = true;
            this.radioBoxDoNet3_5.Text = ".Net v3.5";
            this.radioBoxDoNet3_5.UseVisualStyleBackColor = true;
            // 
            // radioBoxDoNet4_0
            // 
            this.radioBoxDoNet4_0.AutoSize = true;
            this.radioBoxDoNet4_0.Location = new System.Drawing.Point(102, 148);
            this.radioBoxDoNet4_0.Name = "radioBoxDoNet4_0";
            this.radioBoxDoNet4_0.Size = new System.Drawing.Size(77, 16);
            this.radioBoxDoNet4_0.TabIndex = 6;
            this.radioBoxDoNet4_0.TabStop = true;
            this.radioBoxDoNet4_0.Text = ".Net v4.0";
            this.radioBoxDoNet4_0.UseVisualStyleBackColor = true;
            // 
            // checkBoxRunAsAdmin
            // 
            this.checkBoxRunAsAdmin.AutoSize = true;
            this.checkBoxRunAsAdmin.Location = new System.Drawing.Point(327, 148);
            this.checkBoxRunAsAdmin.Name = "checkBoxRunAsAdmin";
            this.checkBoxRunAsAdmin.Size = new System.Drawing.Size(144, 16);
            this.checkBoxRunAsAdmin.TabIndex = 7;
            this.checkBoxRunAsAdmin.Text = "右键以管理员身份运行";
            this.checkBoxRunAsAdmin.UseVisualStyleBackColor = true;
            // 
            // textBoxLog
            // 
            this.textBoxLog.BackColor = System.Drawing.Color.Black;
            this.textBoxLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.textBoxLog.Location = new System.Drawing.Point(12, 202);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(560, 142);
            this.textBoxLog.TabIndex = 8;
            // 
            // labelLog
            // 
            this.labelLog.AutoSize = true;
            this.labelLog.Location = new System.Drawing.Point(10, 179);
            this.labelLog.Name = "labelLog";
            this.labelLog.Size = new System.Drawing.Size(65, 12);
            this.labelLog.TabIndex = 9;
            this.labelLog.Text = "日志消息：";
            // 
            // btnIcon
            // 
            this.btnIcon.Location = new System.Drawing.Point(477, 103);
            this.btnIcon.Name = "btnIcon";
            this.btnIcon.Size = new System.Drawing.Size(93, 23);
            this.btnIcon.TabIndex = 11;
            this.btnIcon.Text = "选择图标文件";
            this.btnIcon.UseVisualStyleBackColor = true;
            this.btnIcon.Click += new System.EventHandler(this.btnIcon_Click);
            // 
            // textBoxIco
            // 
            this.textBoxIco.Enabled = false;
            this.textBoxIco.Location = new System.Drawing.Point(12, 91);
            this.textBoxIco.Multiline = true;
            this.textBoxIco.Name = "textBoxIco";
            this.textBoxIco.Size = new System.Drawing.Size(461, 35);
            this.textBoxIco.TabIndex = 10;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.Filter = "ico图标|*.ico|所有文件|*.*";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帮助HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 25);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUsage,
            this.menuAbout});
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助HToolStripMenuItem.Text = "帮助(&H)";
            // 
            // menuUsage
            // 
            this.menuUsage.Name = "menuUsage";
            this.menuUsage.Size = new System.Drawing.Size(141, 22);
            this.menuUsage.Text = "使用说明(&U)";
            this.menuUsage.Click += new System.EventHandler(this.menuUsage_Click);
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(141, 22);
            this.menuAbout.Text = "关于(&A)";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.btnIcon);
            this.Controls.Add(this.textBoxIco);
            this.Controls.Add(this.labelLog);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.checkBoxRunAsAdmin);
            this.Controls.Add(this.radioBoxDoNet4_0);
            this.Controls.Add(this.radioBoxDoNet3_5);
            this.Controls.Add(this.checkBoxHidden);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.textBoxFilePath);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 400);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PowerShell2Exe";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.CheckBox checkBoxHidden;
        private System.Windows.Forms.RadioButton radioBoxDoNet3_5;
        private System.Windows.Forms.RadioButton radioBoxDoNet4_0;
        private System.Windows.Forms.CheckBox checkBoxRunAsAdmin;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Label labelLog;
        private System.Windows.Forms.Button btnIcon;
        private System.Windows.Forms.TextBox textBoxIco;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuUsage;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
    }
}

