namespace FeatureUpgrade
{
    partial class EnterSetupLocation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnterSetupLocation));
            this.button_setupLocation = new System.Windows.Forms.Button();
            this.textbox_setupLocation = new System.Windows.Forms.TextBox();
            this.label_pcName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_setupLocation
            // 
            this.button_setupLocation.Location = new System.Drawing.Point(186, 86);
            this.button_setupLocation.Name = "button_setupLocation";
            this.button_setupLocation.Size = new System.Drawing.Size(114, 35);
            this.button_setupLocation.TabIndex = 5;
            this.button_setupLocation.Text = "Enter Setup";
            this.button_setupLocation.UseVisualStyleBackColor = true;
            this.button_setupLocation.Click += new System.EventHandler(this.button_setupLocation_Click);
            // 
            // textbox_setupLocation
            // 
            this.textbox_setupLocation.Location = new System.Drawing.Point(163, 34);
            this.textbox_setupLocation.Name = "textbox_setupLocation";
            this.textbox_setupLocation.Size = new System.Drawing.Size(356, 20);
            this.textbox_setupLocation.TabIndex = 4;
            // 
            // label_pcName
            // 
            this.label_pcName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_pcName.Location = new System.Drawing.Point(12, 29);
            this.label_pcName.Name = "label_pcName";
            this.label_pcName.Size = new System.Drawing.Size(145, 26);
            this.label_pcName.TabIndex = 3;
            this.label_pcName.Text = "Setup Location:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "For Example: \\\\fs1\\userapps\\2004\\setup.exe";
            // 
            // EnterSetupLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 150);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_setupLocation);
            this.Controls.Add(this.textbox_setupLocation);
            this.Controls.Add(this.label_pcName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "EnterSetupLocation";
            this.Text = "EnterSetupLocation";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textbox_setupLocation_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_setupLocation;
        private System.Windows.Forms.TextBox textbox_setupLocation;
        private System.Windows.Forms.Label label_pcName;
        private System.Windows.Forms.Label label1;
    }
}