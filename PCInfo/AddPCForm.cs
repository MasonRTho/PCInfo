using System;
using System.ComponentModel;
using System.Linq;
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

        private delegate void SafeCallDelegateButton();
        private void UpdateAddPCButtonSafe()
        {

            if (button_addPC.InvokeRequired)
            {
                //var d = new SafeCallDelegateButton(button_addPC);
                //label_StaticCurrentlyScanning.Invoke(d, new object[] { label_StaticCurrentlyScanning.Show = true });
                button_addPC.Invoke(new Action(() => 
                { 
                    button_addPC.Text = "Checking...";
                    button_addPC.Enabled = false;
                    textbox_pcName.Enabled = false;

                }));

            }
            else
            {
                button_addPC.Text = "Checking...";
                button_addPC.Enabled = false;
                textbox_pcName.Enabled = false;
            }

        }

        private void CloseFormSafe()
        {

            if (button_addPC.InvokeRequired)
            {
                //var d = new SafeCallDelegateButton(button_addPC);
                //label_StaticCurrentlyScanning.Invoke(d, new object[] { label_StaticCurrentlyScanning.Show = true });
                button_addPC.Invoke(new Action(() =>
                {
                    MainForm.source.ResetBindings(false);
                    this.Close();

                }));

            }
            else
            {
                MainForm.source.ResetBindings(false);
                this.Close();
            }

        }


        //private void UpdateTextBoxSafe(string pcName)
        //{

        //    if (label_statusLabel.InvokeRequired)
        //    {
        //        var d = new SafeCallDelegate(updateStatusLabelSafe);
        //        //label_StaticCurrentlyScanning.Invoke(d, new object[] { label_StaticCurrentlyScanning.Show = true });
        //        label_statusLabel.Invoke(d, new object[] { pcName });

        //    }
        //    else
        //    {
        //        label_StaticCurrentlyScanning.Visible = true;
        //        label_statusLabel.Text = pcName;
        //    }

        //}


        private void GetPCInfo(Computer pc)
        {
            UpdateAddPCButtonSafe();
            pc.getOnlineStatus();

            if (pc.OnlineStatus == "Online")
            {
                if (!MainForm.CheckIfPCExistsinOnlineComputerList(pc))
                {
                    pc.getFreeSpace();

                    MainForm.CheckIfPCHasMoreThan20GbAndPassesWMI(pc);
                }
                else
                {
                    MessageBox.Show($"{pc.PCName} is already in the list!");
                }
            }
            else
            {
                MainForm.moveToOfflineList(pc, "Offline", "N/A");
                MessageBox.Show(pc.PCName + " is offline");
            }
            CloseFormSafe();
        }
        // does basically the same as the main form version 
        //TODO: Make the offline recheck multithreaded
        //TODO: This whole class is messy as hell, need to clean up.
        private async void button_addPC_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textbox_pcName.Text))
            {

                MessageBox.Show("You didn't enter anything", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {

                DialogResult doYouWantToReAddOfflinePCMessageBox;

                string pcName = textbox_pcName.Text;
                Computer textboxPC = new Computer(pcName);

                //TODO: remove redundancy
                if (!(MainForm.onlineComputerList.Any(a => a.PCName == textboxPC.PCName)) && !(MainForm.offlineComputerList.Any(b => b.PCName == textboxPC.PCName)))
                {
                    await Task.Run(() => GetPCInfo(textboxPC));
                }
                else
                {
                    if (MainForm.onlineComputerList.Any(a => a.PCName == textboxPC.PCName))
                    {
                        MessageBox.Show("You've already added that PC.");
                    }
                    if (MainForm.offlineComputerList.Any(b => b.PCName == textboxPC.PCName))
                    {
                        var messageString = textboxPC.PCName + " is already in the offline list. Do you want to try scanning it again?\n P.S. I haven't multithreaded this yet, so it'll be slow/freeze for a bit";
                        doYouWantToReAddOfflinePCMessageBox = MessageBox.Show(messageString, "Try Again?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (doYouWantToReAddOfflinePCMessageBox == DialogResult.Yes)
                        {
                            var pcToRemove = MainForm.offlineComputerList.Single(p => p.PCName == textboxPC.PCName);
                            MainForm.offlineComputerList.Remove(pcToRemove);

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
                                MainForm.source.ResetBindings(false);
                                this.Close();
                            }
                            else
                            {
                                MainForm.moveToOfflineList(textboxPC, "Offline", "N/A");
                                MessageBox.Show(textboxPC.PCName + " is still offline");
                                MainForm.source.ResetBindings(false);
                                this.Close();
                            }
                        }

                    }
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
