using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCInfo
{
    public partial class AddPCForm : Form
    {
        public AddPCForm()
        {
            InitializeComponent();
        }

        private void label_pcName_Click(object sender, EventArgs e)
        {

        }

        private void button_addPC_Click(object sender, EventArgs e)
        {
            string pcName = textbox_pcName.Text;
            Computer textboxPC = new Computer(pcName);
            textboxPC.getOnlineStatus();

            if (textboxPC.OnlineStatus == "Online")
            {
                textboxPC.getCurrentVersion();
                MainForm.onlineComputerList.Add(textboxPC);
            }
            else
            {
                MainForm.offlineComputerList.Add(textboxPC);
            }

            
            this.Close();
        }
    }
}
