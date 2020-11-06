namespace PCInfo
{
    partial class MainForm
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
            this.datagrid_pcList = new System.Windows.Forms.DataGridView();
            this.pcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.onlineStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.upgradeStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeStamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_selectList = new System.Windows.Forms.Button();
            this.openSelectPCDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_pcList)).BeginInit();
            this.SuspendLayout();
            // 
            // datagrid_pcList
            // 
            this.datagrid_pcList.AllowUserToDeleteRows = false;
            this.datagrid_pcList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pcName,
            this.onlineStatus,
            this.currentVersion,
            this.upgradeStatus,
            this.logResult,
            this.timeStamp});
            this.datagrid_pcList.Location = new System.Drawing.Point(12, 27);
            this.datagrid_pcList.Name = "datagrid_pcList";
            this.datagrid_pcList.ReadOnly = true;
            this.datagrid_pcList.RowHeadersVisible = false;
            this.datagrid_pcList.Size = new System.Drawing.Size(605, 404);
            this.datagrid_pcList.TabIndex = 0;
            this.datagrid_pcList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // pcName
            // 
            this.pcName.HeaderText = "PC Name";
            this.pcName.Name = "pcName";
            this.pcName.ReadOnly = true;
            // 
            // onlineStatus
            // 
            this.onlineStatus.HeaderText = "Online Status";
            this.onlineStatus.Name = "onlineStatus";
            this.onlineStatus.ReadOnly = true;
            // 
            // currentVersion
            // 
            this.currentVersion.HeaderText = "CurrentVersion";
            this.currentVersion.Name = "currentVersion";
            this.currentVersion.ReadOnly = true;
            // 
            // upgradeStatus
            // 
            this.upgradeStatus.HeaderText = "Upgrade Status";
            this.upgradeStatus.Name = "upgradeStatus";
            this.upgradeStatus.ReadOnly = true;
            // 
            // logResult
            // 
            this.logResult.HeaderText = "Log Result";
            this.logResult.Name = "logResult";
            this.logResult.ReadOnly = true;
            // 
            // timeStamp
            // 
            this.timeStamp.HeaderText = "Time Stamp";
            this.timeStamp.Name = "timeStamp";
            this.timeStamp.ReadOnly = true;
            // 
            // button_selectList
            // 
            this.button_selectList.Location = new System.Drawing.Point(12, 447);
            this.button_selectList.Name = "button_selectList";
            this.button_selectList.Size = new System.Drawing.Size(107, 36);
            this.button_selectList.TabIndex = 1;
            this.button_selectList.Text = "Select PC List";
            this.button_selectList.UseVisualStyleBackColor = true;
            this.button_selectList.Click += new System.EventHandler(this.button_selectList_Click);
            // 
            // openSelectPCDialog
            // 
            this.openSelectPCDialog.FileName = "Select a text file";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 607);
            this.Controls.Add(this.button_selectList);
            this.Controls.Add(this.datagrid_pcList);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_pcList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView datagrid_pcList;
        private System.Windows.Forms.Button button_selectList;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcName;
        private System.Windows.Forms.DataGridViewTextBoxColumn onlineStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn upgradeStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn logResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeStamp;
        private System.Windows.Forms.OpenFileDialog openSelectPCDialog;
    }
}

