namespace WPCraker
{
    partial class WPCreaker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lvw_result = new System.Windows.Forms.ListView();
            this.clm_Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clm_Url = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clm_UserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clm_UserPass = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开URLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_log = new System.Windows.Forms.TextBox();
            this.grb_status = new System.Windows.Forms.GroupBox();
            this.chk_useDefaultPassDic = new System.Windows.Forms.CheckBox();
            this.cmb_timeout = new System.Windows.Forms.ComboBox();
            this.cmb_threadCount = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_import_passdic = new System.Windows.Forms.Button();
            this.btn_import = new System.Windows.Forms.Button();
            this.btn_export = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.lbl_CurrentTestDomain = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.prb_status = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_threadStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_taskStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_useTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_crackerSuccessCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_domainCountlbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_domainCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_info = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grb_status.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvw_result
            // 
            this.lvw_result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvw_result.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clm_Id,
            this.clm_Url,
            this.clm_UserName,
            this.clm_UserPass});
            this.lvw_result.ContextMenuStrip = this.contextMenuStrip1;
            this.lvw_result.FullRowSelect = true;
            this.lvw_result.GridLines = true;
            this.lvw_result.HideSelection = false;
            this.lvw_result.Location = new System.Drawing.Point(9, 17);
            this.lvw_result.Name = "lvw_result";
            this.lvw_result.Size = new System.Drawing.Size(759, 340);
            this.lvw_result.TabIndex = 5;
            this.lvw_result.UseCompatibleStateImageBehavior = false;
            this.lvw_result.View = System.Windows.Forms.View.Details;
            // 
            // clm_Id
            // 
            this.clm_Id.Text = "序 号";
            this.clm_Id.Width = 55;
            // 
            // clm_Url
            // 
            this.clm_Url.Text = "域名或URL";
            this.clm_Url.Width = 289;
            // 
            // clm_UserName
            // 
            this.clm_UserName.Text = "帐户名";
            this.clm_UserName.Width = 196;
            // 
            // clm_UserPass
            // 
            this.clm_UserPass.Text = "密 码";
            this.clm_UserPass.Width = 193;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开URLToolStripMenuItem,
            this.复制ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(124, 48);
            // 
            // 打开URLToolStripMenuItem
            // 
            this.打开URLToolStripMenuItem.Name = "打开URLToolStripMenuItem";
            this.打开URLToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.打开URLToolStripMenuItem.Text = "打开URL";
            this.打开URLToolStripMenuItem.Click += new System.EventHandler(this.打开URLToolStripMenuItem_Click);
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.复制ToolStripMenuItem.Text = "复制";
            this.复制ToolStripMenuItem.Click += new System.EventHandler(this.复制ToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txt_log);
            this.groupBox2.Location = new System.Drawing.Point(6, 363);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(777, 122);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "日 志";
            // 
            // txt_log
            // 
            this.txt_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_log.Location = new System.Drawing.Point(3, 17);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_log.Size = new System.Drawing.Size(771, 102);
            this.txt_log.TabIndex = 0;
            // 
            // grb_status
            // 
            this.grb_status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grb_status.Controls.Add(this.chk_useDefaultPassDic);
            this.grb_status.Controls.Add(this.cmb_timeout);
            this.grb_status.Controls.Add(this.cmb_threadCount);
            this.grb_status.Controls.Add(this.label8);
            this.grb_status.Controls.Add(this.label6);
            this.grb_status.Controls.Add(this.btn_import_passdic);
            this.grb_status.Controls.Add(this.btn_import);
            this.grb_status.Controls.Add(this.btn_export);
            this.grb_status.Controls.Add(this.btn_stop);
            this.grb_status.Controls.Add(this.btn_start);
            this.grb_status.Controls.Add(this.lbl_CurrentTestDomain);
            this.grb_status.Location = new System.Drawing.Point(12, 12);
            this.grb_status.Name = "grb_status";
            this.grb_status.Size = new System.Drawing.Size(777, 59);
            this.grb_status.TabIndex = 3;
            this.grb_status.TabStop = false;
            this.grb_status.Text = "状 态";
            // 
            // chk_useDefaultPassDic
            // 
            this.chk_useDefaultPassDic.AutoSize = true;
            this.chk_useDefaultPassDic.Checked = true;
            this.chk_useDefaultPassDic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_useDefaultPassDic.Location = new System.Drawing.Point(109, 23);
            this.chk_useDefaultPassDic.Name = "chk_useDefaultPassDic";
            this.chk_useDefaultPassDic.Size = new System.Drawing.Size(72, 16);
            this.chk_useDefaultPassDic.TabIndex = 21;
            this.chk_useDefaultPassDic.Text = "默认字典";
            this.chk_useDefaultPassDic.UseVisualStyleBackColor = true;
            this.chk_useDefaultPassDic.CheckedChanged += new System.EventHandler(this.chk_useDefaultPassDic_CheckedChanged);
            // 
            // cmb_timeout
            // 
            this.cmb_timeout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_timeout.FormattingEnabled = true;
            this.cmb_timeout.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "40",
            "50",
            "60"});
            this.cmb_timeout.Location = new System.Drawing.Point(464, 20);
            this.cmb_timeout.Name = "cmb_timeout";
            this.cmb_timeout.Size = new System.Drawing.Size(60, 20);
            this.cmb_timeout.TabIndex = 20;
            this.cmb_timeout.TextChanged += new System.EventHandler(this.cmb_timeout_TextChanged);
            // 
            // cmb_threadCount
            // 
            this.cmb_threadCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_threadCount.FormattingEnabled = true;
            this.cmb_threadCount.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "20",
            "30",
            "40",
            "50",
            "60",
            "70",
            "80",
            "90",
            "100",
            "200",
            "300",
            "400",
            "500",
            "600",
            "700",
            "800",
            "900",
            "1000"});
            this.cmb_threadCount.Location = new System.Drawing.Point(330, 21);
            this.cmb_threadCount.Name = "cmb_threadCount";
            this.cmb_threadCount.Size = new System.Drawing.Size(60, 20);
            this.cmb_threadCount.TabIndex = 20;
            this.cmb_threadCount.TextChanged += new System.EventHandler(this.cmb_threadCount_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(411, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "超 时：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(277, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "线 程：";
            // 
            // btn_import_passdic
            // 
            this.btn_import_passdic.Enabled = false;
            this.btn_import_passdic.Location = new System.Drawing.Point(187, 19);
            this.btn_import_passdic.Name = "btn_import_passdic";
            this.btn_import_passdic.Size = new System.Drawing.Size(68, 23);
            this.btn_import_passdic.TabIndex = 18;
            this.btn_import_passdic.Text = "导入字典";
            this.btn_import_passdic.UseVisualStyleBackColor = true;
            this.btn_import_passdic.Click += new System.EventHandler(this.btn_import_passdic_Click);
            // 
            // btn_import
            // 
            this.btn_import.Location = new System.Drawing.Point(9, 20);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(88, 23);
            this.btn_import.TabIndex = 18;
            this.btn_import.Text = "导入目标";
            this.btn_import.UseVisualStyleBackColor = true;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // btn_export
            // 
            this.btn_export.Location = new System.Drawing.Point(698, 19);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(70, 23);
            this.btn_export.TabIndex = 13;
            this.btn_export.Text = "导出结果";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(619, 18);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(70, 23);
            this.btn_stop.TabIndex = 12;
            this.btn_stop.Text = "停止任务";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(536, 19);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(70, 23);
            this.btn_start.TabIndex = 12;
            this.btn_start.Text = "开始任务";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // lbl_CurrentTestDomain
            // 
            this.lbl_CurrentTestDomain.AutoSize = true;
            this.lbl_CurrentTestDomain.Location = new System.Drawing.Point(118, 45);
            this.lbl_CurrentTestDomain.Name = "lbl_CurrentTestDomain";
            this.lbl_CurrentTestDomain.Size = new System.Drawing.Size(0, 12);
            this.lbl_CurrentTestDomain.TabIndex = 9;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lvw_result);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(774, 502);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.prb_status,
            this.toolStripStatusLabel2,
            this.lbl_threadStatus,
            this.toolStripStatusLabel3,
            this.lbl_taskStatus,
            this.toolStripStatusLabel4,
            this.lbl_useTime,
            this.toolStripStatusLabel5,
            this.lbl_crackerSuccessCount,
            this.lbl_domainCountlbl,
            this.lbl_domainCount,
            this.lbl_info});
            this.statusStrip1.Location = new System.Drawing.Point(0, 577);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(801, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel1.Text = "进度：";
            // 
            // prb_status
            // 
            this.prb_status.Name = "prb_status";
            this.prb_status.Size = new System.Drawing.Size(150, 16);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel2.Text = "线程：";
            // 
            // lbl_threadStatus
            // 
            this.lbl_threadStatus.Name = "lbl_threadStatus";
            this.lbl_threadStatus.Size = new System.Drawing.Size(27, 17);
            this.lbl_threadStatus.Text = "0/0";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(92, 17);
            this.toolStripStatusLabel3.Text = "任务队列情况：";
            // 
            // lbl_taskStatus
            // 
            this.lbl_taskStatus.Name = "lbl_taskStatus";
            this.lbl_taskStatus.Size = new System.Drawing.Size(27, 17);
            this.lbl_taskStatus.Text = "0/0";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel4.Text = "用时：";
            // 
            // lbl_useTime
            // 
            this.lbl_useTime.Name = "lbl_useTime";
            this.lbl_useTime.Size = new System.Drawing.Size(15, 17);
            this.lbl_useTime.Text = "0";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel5.Text = "破解成功：";
            // 
            // lbl_crackerSuccessCount
            // 
            this.lbl_crackerSuccessCount.Name = "lbl_crackerSuccessCount";
            this.lbl_crackerSuccessCount.Size = new System.Drawing.Size(15, 17);
            this.lbl_crackerSuccessCount.Text = "0";
            // 
            // lbl_domainCountlbl
            // 
            this.lbl_domainCountlbl.Name = "lbl_domainCountlbl";
            this.lbl_domainCountlbl.Size = new System.Drawing.Size(68, 17);
            this.lbl_domainCountlbl.Text = "域名总数：";
            // 
            // lbl_domainCount
            // 
            this.lbl_domainCount.Name = "lbl_domainCount";
            this.lbl_domainCount.Size = new System.Drawing.Size(15, 17);
            this.lbl_domainCount.Text = "0";
            // 
            // lbl_info
            // 
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(0, 17);
            // 
            // WPCreaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 599);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grb_status);
            this.Name = "WPCreaker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WPCreaker V2.1[2019/05/09] by shack2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WPCreaker_FormClosing);
            this.Shown += new System.EventHandler(this.WPCreaker_Shown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grb_status.ResumeLayout(false);
            this.grb_status.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvw_result;
        private System.Windows.Forms.ColumnHeader clm_Id;
        private System.Windows.Forms.ColumnHeader clm_Url;
        private System.Windows.Forms.ColumnHeader clm_UserName;
        private System.Windows.Forms.ColumnHeader clm_UserPass;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_log;
        private System.Windows.Forms.GroupBox grb_status;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Label lbl_CurrentTestDomain;
        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_threadCount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.ComboBox cmb_timeout;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 打开URLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar prb_status;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lbl_threadStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel lbl_useTime;
        private System.Windows.Forms.ToolStripStatusLabel lbl_taskStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel lbl_crackerSuccessCount;
        private System.Windows.Forms.ToolStripStatusLabel lbl_domainCountlbl;
        private System.Windows.Forms.ToolStripStatusLabel lbl_domainCount;
        private System.Windows.Forms.CheckBox chk_useDefaultPassDic;
        private System.Windows.Forms.Button btn_import_passdic;
        private System.Windows.Forms.ToolStripStatusLabel lbl_info;
    }
}