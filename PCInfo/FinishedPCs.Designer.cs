namespace PCInfo
{
    partial class FinishedPCs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinishedPCs));
            this.dataGridView_finishedPcs = new System.Windows.Forms.DataGridView();
            this.button_finishedPcsExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_finishedPcs)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_finishedPcs
            // 
            this.dataGridView_finishedPcs.AllowUserToDeleteRows = false;
            this.dataGridView_finishedPcs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_finishedPcs.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_finishedPcs.Name = "dataGridView_finishedPcs";
            this.dataGridView_finishedPcs.ReadOnly = true;
            this.dataGridView_finishedPcs.Size = new System.Drawing.Size(348, 270);
            this.dataGridView_finishedPcs.TabIndex = 0;
            // 
            // button_finishedPcsExport
            // 
            this.button_finishedPcsExport.Location = new System.Drawing.Point(98, 289);
            this.button_finishedPcsExport.Name = "button_finishedPcsExport";
            this.button_finishedPcsExport.Size = new System.Drawing.Size(163, 41);
            this.button_finishedPcsExport.TabIndex = 1;
            this.button_finishedPcsExport.Text = "Export to Excel";
            this.button_finishedPcsExport.UseVisualStyleBackColor = true;
            this.button_finishedPcsExport.Click += new System.EventHandler(this.button_finishedPcsExport_Click);
            // 
            // FinishedPCs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 342);
            this.Controls.Add(this.button_finishedPcsExport);
            this.Controls.Add(this.dataGridView_finishedPcs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FinishedPCs";
            this.Text = "FinishedPCs";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_finishedPcs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_finishedPcs;
        private System.Windows.Forms.Button button_finishedPcsExport;
    }
}