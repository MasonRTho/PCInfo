using PCInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeatureUpgrade
{
    public partial class EnterSetupLocation : Form
    {
        public EnterSetupLocation()
        {
            InitializeComponent();
        }

         void button_setupLocation_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textbox_setupLocation.Text))
            {

                MessageBox.Show("You didn't enter anything", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (File.Exists(textbox_setupLocation.Text))
                {
                    MainForm.setupPath = textbox_setupLocation.Text;
                    MainForm.label_setupLocation.Text = textbox_setupLocation.Text;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("The file path is invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void textbox_setupLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_setupLocation_Click(this, new EventArgs());
            }
        }
    }
}

