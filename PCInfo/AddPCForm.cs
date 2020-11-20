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
            if (String.IsNullOrEmpty(textbox_pcName.Text))
            {
                MessageBox.Show("You didn't enter anything");
              
            }
            else
            {

            string pcName = textbox_pcName.Text;
            Computer textboxPC = new Computer(pcName);
            textboxPC.getOnlineStatus();

            if (textboxPC.OnlineStatus == "Online")
            {
                if (!MainForm.CheckIfPCExistsinOnlineComputerList(textboxPC))
                {
                    textboxPC.getCurrentVersion();
                    textboxPC.getFreeSpace();
                    if (MainForm.IsThereEnoughFreeSpace(textboxPC))
                    {
                        MainForm.onlineComputerList.Add(textboxPC);
                        MainForm.source.ResetBindings(false);
                    }
                    else
                    {
                        OfflineComputer noSpacePC = new OfflineComputer(textboxPC.PCName);
                        noSpacePC.Reason = "Less than 20GB avail";
                        MainForm.offlineComputerList.Add(noSpacePC);
                        MessageBox.Show(noSpacePC.PCName.ToString() + " does not have enough disk space");
                    }
                    
                }
                else
                {
                    MessageBox.Show($"{textboxPC.PCName} is already in the list!");
                }
               
            }
            else
            {
                OfflineComputer offlinePC = new OfflineComputer(textboxPC.PCName);
                offlinePC.Reason = "Offline";
                MainForm.offlineComputerList.Add(offlinePC);
                MessageBox.Show(textboxPC.PCName + " is offline!");
            }

            //refreshes the data source to update the dgv
            
            this.Close();
            }
        }
    }
}
