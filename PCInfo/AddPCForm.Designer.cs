namespace PCInfo
{
    partial class AddPCForm
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
            this.label_pcName = new System.Windows.Forms.Label();
            this.textbox_pcName = new System.Windows.Forms.TextBox();
            this.button_addPC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_pcName
            // 
            this.label_pcName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_pcName.Location = new System.Drawing.Point(51, 57);
            this.label_pcName.Name = "label_pcName";
            this.label_pcName.Size = new System.Drawing.Size(100, 26);
            this.label_pcName.TabIndex = 0;
            this.label_pcName.Text = "PC Name:";
            this.label_pcName.Click += new System.EventHandler(this.label_pcName_Click);
            // 
            // textbox_pcName
            // 
            this.textbox_pcName.Location = new System.Drawing.Point(148, 62);
            this.textbox_pcName.Name = "textbox_pcName";
            this.textbox_pcName.Size = new System.Drawing.Size(184, 20);
            this.textbox_pcName.TabIndex = 1;
            // 
            // button_addPC
            // 
            this.button_addPC.Location = new System.Drawing.Point(130, 105);
            this.button_addPC.Name = "button_addPC";
            this.button_addPC.Size = new System.Drawing.Size(114, 35);
            this.button_addPC.TabIndex = 2;
            this.button_addPC.Text = "Add PC";
            this.button_addPC.UseVisualStyleBackColor = true;
            this.button_addPC.Click += new System.EventHandler(this.button_addPC_Click);
            this.button_addPC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textbox_pcName_KeyDown);
            // 
            // AddPCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 173);
            this.Controls.Add(this.button_addPC);
            this.Controls.Add(this.textbox_pcName);
            this.Controls.Add(this.label_pcName);
            this.KeyPreview = true;
            this.Name = "AddPCForm";
            this.Text = "Add a new PC";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textbox_pcName_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_pcName;
        private System.Windows.Forms.TextBox textbox_pcName;
        private System.Windows.Forms.Button button_addPC;
    }
}