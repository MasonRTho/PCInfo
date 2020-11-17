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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.datagrid_pcList = new System.Windows.Forms.DataGridView();
            this.button_selectList = new System.Windows.Forms.Button();
            this.openSelectPCDialog = new System.Windows.Forms.OpenFileDialog();
            this.label_statusLabel = new System.Windows.Forms.Label();
            this.label_StaticCurrentlyScanning = new System.Windows.Forms.Label();
            this.button_clearList = new System.Windows.Forms.Button();
            this.button_addPC = new System.Windows.Forms.Button();
            this.button_showOfflinePCs = new System.Windows.Forms.Button();
            this.button_startProcess = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_pcList)).BeginInit();
            this.SuspendLayout();
            // 
            // datagrid_pcList
            // 
            this.datagrid_pcList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagrid_pcList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagrid_pcList.DefaultCellStyle = dataGridViewCellStyle2;
            this.datagrid_pcList.Location = new System.Drawing.Point(12, 76);
            this.datagrid_pcList.Name = "datagrid_pcList";
            this.datagrid_pcList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagrid_pcList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.datagrid_pcList.RowHeadersVisible = false;
            this.datagrid_pcList.Size = new System.Drawing.Size(605, 404);
            this.datagrid_pcList.TabIndex = 0;
            this.datagrid_pcList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button_selectList
            // 
            this.button_selectList.Location = new System.Drawing.Point(12, 486);
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
            this.label_statusLabel.Location = new System.Drawing.Point(124, 33);
            this.label_statusLabel.Name = "label_statusLabel";
            this.label_statusLabel.Size = new System.Drawing.Size(131, 24);
            this.label_statusLabel.TabIndex = 2;
            // 
            // label_StaticCurrentlyScanning
            // 
            this.label_StaticCurrentlyScanning.Location = new System.Drawing.Point(12, 33);
            this.label_StaticCurrentlyScanning.Name = "label_StaticCurrentlyScanning";
            this.label_StaticCurrentlyScanning.Size = new System.Drawing.Size(115, 40);
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
            this.button_addPC.Location = new System.Drawing.Point(148, 486);
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
            this.button_startProcess.Location = new System.Drawing.Point(660, 175);
            this.button_startProcess.Name = "button_startProcess";
            this.button_startProcess.Size = new System.Drawing.Size(128, 48);
            this.button_startProcess.TabIndex = 7;
            this.button_startProcess.Text = "Start";
            this.button_startProcess.UseVisualStyleBackColor = true;
            this.button_startProcess.Click += new System.EventHandler(this.button_startProcess_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 607);
            this.Controls.Add(this.button_startProcess);
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
    }
}

