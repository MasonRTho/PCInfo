namespace PCInfo
{
    partial class OfflinePCList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OfflinePCList));
            this.button_exportList = new System.Windows.Forms.Button();
            this.datagridview_offlinePCs = new System.Windows.Forms.DataGridView();
            this.button_refreshOfflinePCs = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_offlinePCs)).BeginInit();
            this.SuspendLayout();
            // 
            // button_exportList
            // 
            this.button_exportList.Location = new System.Drawing.Point(12, 262);
            this.button_exportList.Name = "button_exportList";
            this.button_exportList.Size = new System.Drawing.Size(154, 38);
            this.button_exportList.TabIndex = 1;
            this.button_exportList.Text = "Export to Excel";
            this.button_exportList.UseVisualStyleBackColor = true;
            this.button_exportList.Click += new System.EventHandler(this.button_exportList_Click);
            // 
            // datagridview_offlinePCs
            // 
            this.datagridview_offlinePCs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridview_offlinePCs.Location = new System.Drawing.Point(12, 12);
            this.datagridview_offlinePCs.Name = "datagridview_offlinePCs";
            this.datagridview_offlinePCs.RowHeadersVisible = false;
            this.datagridview_offlinePCs.Size = new System.Drawing.Size(508, 244);
            this.datagridview_offlinePCs.TabIndex = 2;
            // 
            // button_refreshOfflinePCs
            // 
            this.button_refreshOfflinePCs.Location = new System.Drawing.Point(366, 262);
            this.button_refreshOfflinePCs.Name = "button_refreshOfflinePCs";
            this.button_refreshOfflinePCs.Size = new System.Drawing.Size(154, 38);
            this.button_refreshOfflinePCs.TabIndex = 3;
            this.button_refreshOfflinePCs.Text = "Refresh";
            this.button_refreshOfflinePCs.UseVisualStyleBackColor = true;
            this.button_refreshOfflinePCs.Click += new System.EventHandler(this.button_refreshOfflinePCs_Click);
            // 
            // OfflinePCList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 312);
            this.Controls.Add(this.button_refreshOfflinePCs);
            this.Controls.Add(this.datagridview_offlinePCs);
            this.Controls.Add(this.button_exportList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OfflinePCList";
            this.Text = "OfflinePCList";
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_offlinePCs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_exportList;
        private System.Windows.Forms.DataGridView datagridview_offlinePCs;
        private System.Windows.Forms.Button button_refreshOfflinePCs;
    }
}