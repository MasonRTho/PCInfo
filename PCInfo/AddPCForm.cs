using System;
using System.ComponentModel;
using System.Linq;
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

            //TODO: Make it multithreaded

            if (String.IsNullOrEmpty(textbox_pcName.Text))
            {

                MessageBox.Show("You didn't enter anything", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {


                string pcName = textbox_pcName.Text;
                Computer textboxPC = new Computer(pcName);


                if (!(MainForm.onlineComputerList.Any(a => a.PCName == textboxPC.PCName)) && !(MainForm.offlineComputerList.Any(b => b.PCName == textboxPC.PCName)))
                {
                    textboxPC.getOnlineStatus();
                    if (textboxPC.OnlineStatus == "Online")
                    {
                        if (!MainForm.CheckIfPCExistsinOnlineComputerList(textboxPC))
                        {

                            textboxPC.getFreeSpace();
                            MainForm.CheckIfPCHasMoreThan20GbAndPassesWMI(textboxPC);
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
                        MessageBox.Show(textboxPC.PCName + " is offline");
                    }

                    MainForm.source.ResetBindings(false);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("You've already added that PC");
                }
   
            }

        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void textbox_pcName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_addPC_Click(this, new EventArgs());
            }
        }
    }
}
