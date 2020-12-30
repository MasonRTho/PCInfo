using PCInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
                //string setupPath = MainForm.setupPath;
                MainForm.setupPath = textbox_setupLocation.Text;
                MainForm.label_setupLocation.Text = textbox_setupLocation.Text;
                this.Close();
                //TODO: remove redundancy


            }
        }
    }
}

