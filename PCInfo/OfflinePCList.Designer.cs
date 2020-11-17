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
            this.listview_offlinePCs = new System.Windows.Forms.ListView();
            this.button_exportList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listview_offlinePCs
            // 
            this.listview_offlinePCs.HideSelection = false;
            this.listview_offlinePCs.Location = new System.Drawing.Point(12, 12);
            this.listview_offlinePCs.Name = "listview_offlinePCs";
            this.listview_offlinePCs.Size = new System.Drawing.Size(251, 244);
            this.listview_offlinePCs.TabIndex = 0;
            this.listview_offlinePCs.UseCompatibleStateImageBehavior = false;
            this.listview_offlinePCs.View = System.Windows.Forms.View.List;
            // 
            // button_exportList
            // 
            this.button_exportList.Location = new System.Drawing.Point(12, 262);
            this.button_exportList.Name = "button_exportList";
            this.button_exportList.Size = new System.Drawing.Size(251, 36);
            this.button_exportList.TabIndex = 1;
            this.button_exportList.Text = "Export List";
            this.button_exportList.UseVisualStyleBackColor = true;
            this.button_exportList.Click += new System.EventHandler(this.button_exportList_Click);
            // 
            // OfflinePCList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 308);
            this.Controls.Add(this.button_exportList);
            this.Controls.Add(this.listview_offlinePCs);
            this.Name = "OfflinePCList";
            this.Text = "OfflinePCList";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listview_offlinePCs;
        private System.Windows.Forms.Button button_exportList;
    }
}