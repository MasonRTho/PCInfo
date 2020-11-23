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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.datagrid_pcList = new System.Windows.Forms.DataGridView();
            this.button_selectList = new System.Windows.Forms.Button();
            this.openSelectPCDialog = new System.Windows.Forms.OpenFileDialog();
            this.label_statusLabel = new System.Windows.Forms.Label();
            this.label_StaticCurrentlyScanning = new System.Windows.Forms.Label();
            this.button_clearList = new System.Windows.Forms.Button();
            this.button_addPC = new System.Windows.Forms.Button();
            this.button_showOfflinePCs = new System.Windows.Forms.Button();
            this.button_startProcess = new System.Windows.Forms.Button();
            this.button_RemovePC = new System.Windows.Forms.Button();
            this.groupbox_settings = new System.Windows.Forms.GroupBox();
            this.label_featureUpgrade = new System.Windows.Forms.Label();
            this.label_osUpgrade = new System.Windows.Forms.Label();
            this.radioButton_fuRestart = new System.Windows.Forms.RadioButton();
            this.radioButton_fuNoRestart = new System.Windows.Forms.RadioButton();
            this.radioButton_fuRestartSkip = new System.Windows.Forms.RadioButton();
            this.radioButton_fuNoRestartSkip = new System.Windows.Forms.RadioButton();
            this.radioButton_osNoRestartSkip = new System.Windows.Forms.RadioButton();
            this.radioButton_osRestartSkip = new System.Windows.Forms.RadioButton();
            this.radioButton_osNoRestart = new System.Windows.Forms.RadioButton();
            this.radioButton_osRestart = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_pcList)).BeginInit();
            this.groupbox_settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // datagrid_pcList
            // 
            this.datagrid_pcList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagrid_pcList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagrid_pcList.DefaultCellStyle = dataGridViewCellStyle5;
            this.datagrid_pcList.Location = new System.Drawing.Point(12, 76);
            this.datagrid_pcList.Name = "datagrid_pcList";
            this.datagrid_pcList.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagrid_pcList.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.datagrid_pcList.RowHeadersVisible = false;
            this.datagrid_pcList.Size = new System.Drawing.Size(605, 404);
            this.datagrid_pcList.TabIndex = 0;
            this.datagrid_pcList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button_selectList
            // 
            this.button_selectList.Location = new System.Drawing.Point(11, 486);
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
            // label_statusLabel
            // 
            this.label_statusLabel.Location = new System.Drawing.Point(128, 45);
            this.label_statusLabel.Name = "label_statusLabel";
            this.label_statusLabel.Size = new System.Drawing.Size(131, 25);
            this.label_statusLabel.TabIndex = 2;
            this.label_statusLabel.Click += new System.EventHandler(this.label_statusLabel_Click);
            // 
            // label_StaticCurrentlyScanning
            // 
            this.label_StaticCurrentlyScanning.Location = new System.Drawing.Point(12, 45);
            this.label_StaticCurrentlyScanning.Name = "label_StaticCurrentlyScanning";
            this.label_StaticCurrentlyScanning.Size = new System.Drawing.Size(115, 25);
            this.label_StaticCurrentlyScanning.TabIndex = 3;
            this.label_StaticCurrentlyScanning.Text = "Currently scanning PC: ";
            // 
            // button_clearList
            // 
            this.button_clearList.Location = new System.Drawing.Point(510, 486);
            this.button_clearList.Name = "button_clearList";
            this.button_clearList.Size = new System.Drawing.Size(107, 36);
            this.button_clearList.TabIndex = 4;
            this.button_clearList.Text = "Clear List";
            this.button_clearList.UseVisualStyleBackColor = true;
            this.button_clearList.Click += new System.EventHandler(this.button_clearList_Click);
            // 
            // button_addPC
            // 
            this.button_addPC.Location = new System.Drawing.Point(126, 486);
            this.button_addPC.Name = "button_addPC";
            this.button_addPC.Size = new System.Drawing.Size(107, 36);
            this.button_addPC.TabIndex = 5;
            this.button_addPC.Text = "Add PC";
            this.button_addPC.UseVisualStyleBackColor = true;
            this.button_addPC.Click += new System.EventHandler(this.button_addPC_Click);
            // 
            // button_showOfflinePCs
            // 
            this.button_showOfflinePCs.Location = new System.Drawing.Point(490, 33);
            this.button_showOfflinePCs.Name = "button_showOfflinePCs";
            this.button_showOfflinePCs.Size = new System.Drawing.Size(127, 37);
            this.button_showOfflinePCs.TabIndex = 6;
            this.button_showOfflinePCs.Text = "Show Offline PCs";
            this.button_showOfflinePCs.UseVisualStyleBackColor = true;
            this.button_showOfflinePCs.Click += new System.EventHandler(this.button_showOfflinePCs_Click);
            // 
            // button_startProcess
            // 
            this.button_startProcess.Location = new System.Drawing.Point(139, 176);
            this.button_startProcess.Name = "button_startProcess";
            this.button_startProcess.Size = new System.Drawing.Size(88, 32);
            this.button_startProcess.TabIndex = 7;
            this.button_startProcess.Text = "Start";
            this.button_startProcess.UseVisualStyleBackColor = true;
            this.button_startProcess.Click += new System.EventHandler(this.button_startProcess_Click);
            // 
            // button_RemovePC
            // 
            this.button_RemovePC.Location = new System.Drawing.Point(387, 486);
            this.button_RemovePC.Name = "button_RemovePC";
            this.button_RemovePC.Size = new System.Drawing.Size(107, 36);
            this.button_RemovePC.TabIndex = 8;
            this.button_RemovePC.Text = "Remove PC";
            this.button_RemovePC.UseVisualStyleBackColor = true;
            this.button_RemovePC.Click += new System.EventHandler(this.button_RemovePC_Click);
            // 
            // groupbox_settings
            // 
            this.groupbox_settings.Controls.Add(this.radioButton_osNoRestartSkip);
            this.groupbox_settings.Controls.Add(this.radioButton_osRestartSkip);
            this.groupbox_settings.Controls.Add(this.radioButton_osNoRestart);
            this.groupbox_settings.Controls.Add(this.radioButton_osRestart);
            this.groupbox_settings.Controls.Add(this.radioButton_fuNoRestartSkip);
            this.groupbox_settings.Controls.Add(this.radioButton_fuRestartSkip);
            this.groupbox_settings.Controls.Add(this.radioButton_fuNoRestart);
            this.groupbox_settings.Controls.Add(this.radioButton_fuRestart);
            this.groupbox_settings.Controls.Add(this.label_osUpgrade);
            this.groupbox_settings.Controls.Add(this.label_featureUpgrade);
            this.groupbox_settings.Controls.Add(this.button_startProcess);
            this.groupbox_settings.Location = new System.Drawing.Point(623, 76);
            this.groupbox_settings.Name = "groupbox_settings";
            this.groupbox_settings.Size = new System.Drawing.Size(395, 234);
            this.groupbox_settings.TabIndex = 9;
            this.groupbox_settings.TabStop = false;
            this.groupbox_settings.Text = "Settings";
            // 
            // label_featureUpgrade
            // 
            this.label_featureUpgrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_featureUpgrade.Location = new System.Drawing.Point(16, 46);
            this.label_featureUpgrade.Name = "label_featureUpgrade";
            this.label_featureUpgrade.Size = new System.Drawing.Size(100, 23);
            this.label_featureUpgrade.TabIndex = 8;
            this.label_featureUpgrade.Text = "Feature Upgrade";
            // 
            // label_osUpgrade
            // 
            this.label_osUpgrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_osUpgrade.Location = new System.Drawing.Point(225, 46);
            this.label_osUpgrade.Name = "label_osUpgrade";
            this.label_osUpgrade.Size = new System.Drawing.Size(138, 23);
            this.label_osUpgrade.TabIndex = 9;
            this.label_osUpgrade.Text = "Windows 7 -> 10";
            // 
            // radioButton_fuRestart
            // 
            this.radioButton_fuRestart.AutoSize = true;
            this.radioButton_fuRestart.Location = new System.Drawing.Point(19, 73);
            this.radioButton_fuRestart.Name = "radioButton_fuRestart";
            this.radioButton_fuRestart.Size = new System.Drawing.Size(59, 17);
            this.radioButton_fuRestart.TabIndex = 10;
            this.radioButton_fuRestart.TabStop = true;
            this.radioButton_fuRestart.Text = "Restart";
            this.radioButton_fuRestart.UseVisualStyleBackColor = true;
            // 
            // radioButton_fuNoRestart
            // 
            this.radioButton_fuNoRestart.AutoSize = true;
            this.radioButton_fuNoRestart.Location = new System.Drawing.Point(19, 96);
            this.radioButton_fuNoRestart.Name = "radioButton_fuNoRestart";
            this.radioButton_fuNoRestart.Size = new System.Drawing.Size(76, 17);
            this.radioButton_fuNoRestart.TabIndex = 11;
            this.radioButton_fuNoRestart.TabStop = true;
            this.radioButton_fuNoRestart.Text = "No Restart";
            this.radioButton_fuNoRestart.UseVisualStyleBackColor = true;
            // 
            // radioButton_fuRestartSkip
            // 
            this.radioButton_fuRestartSkip.AutoSize = true;
            this.radioButton_fuRestartSkip.Location = new System.Drawing.Point(19, 119);
            this.radioButton_fuRestartSkip.Name = "radioButton_fuRestartSkip";
            this.radioButton_fuRestartSkip.Size = new System.Drawing.Size(135, 17);
            this.radioButton_fuRestartSkip.TabIndex = 12;
            this.radioButton_fuRestartSkip.TabStop = true;
            this.radioButton_fuRestartSkip.Text = "Restart && Skip Updates";
            this.radioButton_fuRestartSkip.UseVisualStyleBackColor = true;
            // 
            // radioButton_fuNoRestartSkip
            // 
            this.radioButton_fuNoRestartSkip.AutoSize = true;
            this.radioButton_fuNoRestartSkip.Location = new System.Drawing.Point(19, 142);
            this.radioButton_fuNoRestartSkip.Name = "radioButton_fuNoRestartSkip";
            this.radioButton_fuNoRestartSkip.Size = new System.Drawing.Size(152, 17);
            this.radioButton_fuNoRestartSkip.TabIndex = 13;
            this.radioButton_fuNoRestartSkip.TabStop = true;
            this.radioButton_fuNoRestartSkip.Text = "No Restart && Skip Updates";
            this.radioButton_fuNoRestartSkip.UseVisualStyleBackColor = true;
            // 
            // radioButton_osNoRestartSkip
            // 
            this.radioButton_osNoRestartSkip.AutoSize = true;
            this.radioButton_osNoRestartSkip.Location = new System.Drawing.Point(228, 142);
            this.radioButton_osNoRestartSkip.Name = "radioButton_osNoRestartSkip";
            this.radioButton_osNoRestartSkip.Size = new System.Drawing.Size(152, 17);
            this.radioButton_osNoRestartSkip.TabIndex = 17;
            this.radioButton_osNoRestartSkip.TabStop = true;
            this.radioButton_osNoRestartSkip.Text = "No Restart && Skip Updates";
            this.radioButton_osNoRestartSkip.UseVisualStyleBackColor = true;
            // 
            // radioButton_osRestartSkip
            // 
            this.radioButton_osRestartSkip.AutoSize = true;
            this.radioButton_osRestartSkip.Location = new System.Drawing.Point(228, 119);
            this.radioButton_osRestartSkip.Name = "radioButton_osRestartSkip";
            this.radioButton_osRestartSkip.Size = new System.Drawing.Size(135, 17);
            this.radioButton_osRestartSkip.TabIndex = 16;
            this.radioButton_osRestartSkip.TabStop = true;
            this.radioButton_osRestartSkip.Text = "Restart && Skip Updates";
            this.radioButton_osRestartSkip.UseVisualStyleBackColor = true;
            // 
            // radioButton_osNoRestart
            // 
            this.radioButton_osNoRestart.AutoSize = true;
            this.radioButton_osNoRestart.Location = new System.Drawing.Point(228, 96);
            this.radioButton_osNoRestart.Name = "radioButton_osNoRestart";
            this.radioButton_osNoRestart.Size = new System.Drawing.Size(76, 17);
            this.radioButton_osNoRestart.TabIndex = 15;
            this.radioButton_osNoRestart.TabStop = true;
            this.radioButton_osNoRestart.Text = "No Restart";
            this.radioButton_osNoRestart.UseVisualStyleBackColor = true;
            // 
            // radioButton_osRestart
            // 
            this.radioButton_osRestart.AutoSize = true;
            this.radioButton_osRestart.Location = new System.Drawing.Point(228, 73);
            this.radioButton_osRestart.Name = "radioButton_osRestart";
            this.radioButton_osRestart.Size = new System.Drawing.Size(59, 17);
            this.radioButton_osRestart.TabIndex = 14;
            this.radioButton_osRestart.TabStop = true;
            this.radioButton_osRestart.Text = "Restart";
            this.radioButton_osRestart.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 607);
            this.Controls.Add(this.groupbox_settings);
            this.Controls.Add(this.button_RemovePC);
            this.Controls.Add(this.button_showOfflinePCs);
            this.Controls.Add(this.button_addPC);
            this.Controls.Add(this.button_clearList);
            this.Controls.Add(this.label_StaticCurrentlyScanning);
            this.Controls.Add(this.label_statusLabel);
            this.Controls.Add(this.button_selectList);
            this.Controls.Add(this.datagrid_pcList);
            this.Name = "MainForm";
            this.Text = "Feature Upgrade";
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_pcList)).EndInit();
            this.groupbox_settings.ResumeLayout(false);
            this.groupbox_settings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView datagrid_pcList;
        private System.Windows.Forms.Button button_selectList;
        private System.Windows.Forms.OpenFileDialog openSelectPCDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label_statusLabel;
        private System.Windows.Forms.Label label_StaticCurrentlyScanning;
        private System.Windows.Forms.Button button_clearList;
        private System.Windows.Forms.Button button_addPC;
        private System.Windows.Forms.Button button_showOfflinePCs;
        private System.Windows.Forms.Button button_startProcess;
        private System.Windows.Forms.Button button_RemovePC;
        private System.Windows.Forms.GroupBox groupbox_settings;
        private System.Windows.Forms.RadioButton radioButton_osNoRestartSkip;
        private System.Windows.Forms.RadioButton radioButton_osRestartSkip;
        private System.Windows.Forms.RadioButton radioButton_osNoRestart;
        private System.Windows.Forms.RadioButton radioButton_osRestart;
        private System.Windows.Forms.RadioButton radioButton_fuNoRestartSkip;
        private System.Windows.Forms.RadioButton radioButton_fuRestartSkip;
        private System.Windows.Forms.RadioButton radioButton_fuNoRestart;
        private System.Windows.Forms.RadioButton radioButton_fuRestart;
        private System.Windows.Forms.Label label_osUpgrade;
        private System.Windows.Forms.Label label_featureUpgrade;
    }
}

