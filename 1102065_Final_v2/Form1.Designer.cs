namespace _1102065_Final_v2
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.M3U8_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Format_cmb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SavePath_txt = new System.Windows.Forms.TextBox();
            this.SavePath_btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Status_lbl = new System.Windows.Forms.Label();
            this.Start_btn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.檔案FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DisplayLog_mns = new System.Windows.Forms.ToolStripMenuItem();
            this.Config_mns = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Exit_mns = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.Log_rtx = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DisplayLog_cms = new System.Windows.Forms.ToolStripMenuItem();
            this.Config_cms = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "M3U8 URL";
            // 
            // M3U8_txt
            // 
            this.M3U8_txt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.M3U8_txt.Location = new System.Drawing.Point(100, 33);
            this.M3U8_txt.Multiline = true;
            this.M3U8_txt.Name = "M3U8_txt";
            this.M3U8_txt.Size = new System.Drawing.Size(300, 85);
            this.M3U8_txt.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Format";
            // 
            // Format_cmb
            // 
            this.Format_cmb.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Format_cmb.FormattingEnabled = true;
            this.Format_cmb.Location = new System.Drawing.Point(100, 138);
            this.Format_cmb.Name = "Format_cmb";
            this.Format_cmb.Size = new System.Drawing.Size(121, 29);
            this.Format_cmb.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Save Path";
            // 
            // SavePath_txt
            // 
            this.SavePath_txt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SavePath_txt.Location = new System.Drawing.Point(100, 186);
            this.SavePath_txt.Multiline = true;
            this.SavePath_txt.Name = "SavePath_txt";
            this.SavePath_txt.Size = new System.Drawing.Size(250, 85);
            this.SavePath_txt.TabIndex = 5;
            // 
            // SavePath_btn
            // 
            this.SavePath_btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SavePath_btn.Location = new System.Drawing.Point(356, 186);
            this.SavePath_btn.Name = "SavePath_btn";
            this.SavePath_btn.Size = new System.Drawing.Size(56, 30);
            this.SavePath_btn.TabIndex = 7;
            this.SavePath_btn.Text = "Select";
            this.SavePath_btn.UseVisualStyleBackColor = true;
            this.SavePath_btn.Click += new System.EventHandler(this.SavePath_btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 296);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "Status";
            // 
            // Status_lbl
            // 
            this.Status_lbl.AutoSize = true;
            this.Status_lbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Status_lbl.Location = new System.Drawing.Point(99, 296);
            this.Status_lbl.Name = "Status_lbl";
            this.Status_lbl.Size = new System.Drawing.Size(117, 21);
            this.Status_lbl.TabIndex = 9;
            this.Status_lbl.Text = "Ready to Start";
            // 
            // Start_btn
            // 
            this.Start_btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start_btn.Location = new System.Drawing.Point(334, 361);
            this.Start_btn.Name = "Start_btn";
            this.Start_btn.Size = new System.Drawing.Size(80, 40);
            this.Start_btn.TabIndex = 11;
            this.Start_btn.Text = "Start";
            this.Start_btn.UseVisualStyleBackColor = true;
            this.Start_btn.Click += new System.EventHandler(this.Start_btn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.檔案FToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(435, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 檔案FToolStripMenuItem
            // 
            this.檔案FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DisplayLog_mns,
            this.Config_mns,
            this.toolStripSeparator2,
            this.Exit_mns});
            this.檔案FToolStripMenuItem.Name = "檔案FToolStripMenuItem";
            this.檔案FToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.檔案FToolStripMenuItem.Text = "程式(&O)";
            // 
            // DisplayLog_mns
            // 
            this.DisplayLog_mns.Name = "DisplayLog_mns";
            this.DisplayLog_mns.Size = new System.Drawing.Size(123, 22);
            this.DisplayLog_mns.Text = "顯示 Log";
            this.DisplayLog_mns.Click += new System.EventHandler(this.DisplayLog_mns_Click);
            // 
            // Config_mns
            // 
            this.Config_mns.Name = "Config_mns";
            this.Config_mns.Size = new System.Drawing.Size(123, 22);
            this.Config_mns.Text = "設定";
            this.Config_mns.Click += new System.EventHandler(this.Config_mns_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(120, 6);
            // 
            // Exit_mns
            // 
            this.Exit_mns.Name = "Exit_mns";
            this.Exit_mns.Size = new System.Drawing.Size(123, 22);
            this.Exit_mns.Text = "結束(&X)";
            this.Exit_mns.Click += new System.EventHandler(this.Exit_mns_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(14, 330);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(400, 25);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 13;
            // 
            // Log_rtx
            // 
            this.Log_rtx.Location = new System.Drawing.Point(438, 0);
            this.Log_rtx.Name = "Log_rtx";
            this.Log_rtx.ReadOnly = true;
            this.Log_rtx.Size = new System.Drawing.Size(534, 408);
            this.Log_rtx.TabIndex = 14;
            this.Log_rtx.Text = "";
            this.Log_rtx.TextChanged += new System.EventHandler(this.Log_rtx_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DisplayLog_cms,
            this.Config_cms});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(124, 48);
            // 
            // DisplayLog_cms
            // 
            this.DisplayLog_cms.Name = "DisplayLog_cms";
            this.DisplayLog_cms.Size = new System.Drawing.Size(123, 22);
            this.DisplayLog_cms.Text = "顯示 Log";
            this.DisplayLog_cms.Click += new System.EventHandler(this.DisplayLog_mns_Click);
            // 
            // Config_cms
            // 
            this.Config_cms.Name = "Config_cms";
            this.Config_cms.Size = new System.Drawing.Size(123, 22);
            this.Config_cms.Text = "設定";
            this.Config_cms.Click += new System.EventHandler(this.Config_mns_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 411);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.Log_rtx);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.Start_btn);
            this.Controls.Add(this.Status_lbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SavePath_btn);
            this.Controls.Add(this.SavePath_txt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Format_cmb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.M3U8_txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "M3U8 Downloader GUI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox M3U8_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Format_cmb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SavePath_txt;
        private System.Windows.Forms.Button SavePath_btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Start_btn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 檔案FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Config_mns;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem Exit_mns;
        private System.Windows.Forms.ToolStripMenuItem DisplayLog_mns;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem DisplayLog_cms;
        private System.Windows.Forms.ToolStripMenuItem Config_cms;
        private System.Windows.Forms.RichTextBox Log_rtx;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label Status_lbl;
    }
}

