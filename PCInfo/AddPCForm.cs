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

        // does basically the same as the main form version 
        private void button_addPC_Click(object sender, EventArgs e)
        {
            string pcName = textbox_pcName.Text;
            Computer textboxPC = new Computer(pcName);
            textboxPC.getOnlineStatus();

            if (textboxPC.OnlineStatus == "Online")
            {
                if (!MainForm.CheckIfPCExistsinOnlineComputerList(textboxPC))
                {
                    textboxPC.getCurrentVersion();
                    MainForm.onlineComputerList.Add(textboxPC);
                    MainForm.source.ResetBindings(false);
                }
                else
                {
                    MessageBox.Show($"{textboxPC.PCName} is already in the list!");
                }
               
            }
            else
            {
                MainForm.offlineComputerList.Add(textboxPC);
                MessageBox.Show(textboxPC.PCName + " is offline!");
            }

            //refreshes the data source to update the dgv
            
            this.Close();
        }
    }
}
