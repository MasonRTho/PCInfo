﻿namespace PCInfo
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
            this.button_exportList = new System.Windows.Forms.Button();
            this.datagridview_offlinePCs = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_offlinePCs)).BeginInit();
            this.SuspendLayout();
            // 
            // button_exportList
            // 
            this.button_exportList.Location = new System.Drawing.Point(118, 262);
            this.button_exportList.Name = "button_exportList";
            this.button_exportList.Size = new System.Drawing.Size(154, 38);
            this.button_exportList.TabIndex = 1;
            this.button_exportList.Text = "Export List";
            this.button_exportList.UseVisualStyleBackColor = true;
            this.button_exportList.Click += new System.EventHandler(this.button_exportList_Click);
            // 
            // datagridview_offlinePCs
            // 
            this.datagridview_offlinePCs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridview_offlinePCs.Location = new System.Drawing.Point(12, 12);
            this.datagridview_offlinePCs.Name = "datagridview_offlinePCs";
            this.datagridview_offlinePCs.RowHeadersVisible = false;
            this.datagridview_offlinePCs.Size = new System.Drawing.Size(383, 244);
            this.datagridview_offlinePCs.TabIndex = 2;
            // 
            // OfflinePCList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 312);
            this.Controls.Add(this.datagridview_offlinePCs);
            this.Controls.Add(this.button_exportList);
            this.Name = "OfflinePCList";
            this.Text = "OfflinePCList";
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_offlinePCs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_exportList;
        private System.Windows.Forms.DataGridView datagridview_offlinePCs;
    }
}