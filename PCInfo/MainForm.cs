using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCInfo
{
    public partial class MainForm : Form
    {
        // used later for getting the path of the setup.exe file
        public static string filePath = "";
        private delegate void SafeCallDelegate(string text);
        List<Computer> initialComputerList = new List<Computer>();
        public static List<Computer> onlineComputerList = new  List<Computer>();
        public static List<OfflineComputer> offlineComputerList = new List<OfflineComputer>();
        public static BindingSource source = new BindingSource();

        private void setDataGrid(string text)
        {
            datagrid_pcList.Rows.Add(text);
        }

        public void updateStatusLabelSafe(string pcName)
        {
            
            if (label_statusLabel.InvokeRequired)
            {
                var d = new SafeCallDelegate(updateStatusLabelSafe);
                //label_StaticCurrentlyScanning.Invoke(d, new object[] { label_StaticCurrentlyScanning.Show = true });
                label_statusLabel.Invoke(d, new object[] { pcName });
                
            }
            else
            {
                label_StaticCurrentlyScanning.Visible = true;
                label_statusLabel.Text = pcName;
            }
            
        }

        private static void CopyPsExec(List<Computer> computers)
        {
            foreach (var pc in onlineComputerList)
            {

                try
                {
                    if (!System.IO.File.Exists($@"\\{pc.PCName}\c$\windows\temp\psexec.exe"))
                    {
                        File.Copy(
                        @"\\fs1\userapps\1909\psexec.exe",
                        $@"\\{pc.PCName}\c$\windows\temp\psexec.exe"
                        );
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show($"There was an error copying PSExec to {pc.PCName}.\n" + ex.ToString());

                }
            }
        }

        public static bool IsThereEnoughFreeSpace(Computer pc)
        {
            // var tempName = pc.FreeSpace;
            var tempFreespace = decimal.Parse(pc.FreeSpace.Substring(0, pc.FreeSpace.Length - 2));
            if (tempFreespace < 20)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool CheckIfPCExistsinOnlineComputerList(Computer pc)
        {

            bool exists;
            int index = onlineComputerList.FindIndex(Computer => Computer.PCName == pc.PCName);
            if (index >= 0)
            {
                exists = true;
                return exists;
            }
            else
            {
                exists = false;
                return exists;
            }


        }

        public string GetInstallStringFromRadioButton(RadioButton rb)
        {
            string rbName = "";
            string installString = "";

                    rbName = rb.Name;

                    switch (rbName)
                    {
                        case "radioButton_fuRestart":
                            installString = "/auto upgrade /quiet";
                            break;
                        case "radioButton_fuNoRestart":
                            installString = "/auto upgrade /quiet /noreboot";
                            break;
                        case "radioButton_fuRestartSkip":
                            installString = "/auto upgrade /quiet /DynamicUpdate Disable";
                            break;
                        case "radioButton_fuNoRestartSkip":
                            installString = "/auto upgrade /quiet /DynamicUpdate Disable /noreboot";
                            break;
                        case "radioButton_osRestart":
                            installString = "/auto upgrade /quiet /compat ignorewarning";
                            break;
                        case "radioButton_osNoRestart":
                            installString = "/auto upgrade /quiet /compat ignorewarning /noreboot";
                            break;
                        case "radioButton_osRestartSkip":
                            installString = "/auto upgrade /quiet /compat ignorewarning /DynamicUpdate disable";
                            break;
                        case "radioButton_osNoRestartSkip":
                            installString = "/auto upgrade /quiet /compat ignorewarning /DynamicUpdate disable /noreboot";
                            break;
                    }


            return installString;

        }
        public MainForm()
        {
            InitializeComponent();
            label_StaticCurrentlyScanning.Visible = false;
            // Assign data source. Probably not great to have this chilling in the middle of nowhere
            source.DataSource = onlineComputerList;
            datagrid_pcList.DataSource = source;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // button gets text list of computers and puts them in an array of strings then into a list of computer objects. async method to not freeze UI thread
        private async void button_selectList_Click(object sender, EventArgs e)
        {
           
            if (openSelectPCDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = openSelectPCDialog.FileName;
                    string[] pcNames = File.ReadAllLines(filePath);

                    foreach (var pc in pcNames)
                    {
                        initialComputerList.Add(new Computer(pc));
                    }

                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError Message: {ex.Message}\n\n" + $"Details:\n\n{ex.StackTrace}");
                }

            }

            
            //online,version, free space check, using await task to update label and not freeze UI thread.
            await Task.Run(() =>
            {
                
                foreach (var pc in initialComputerList)
                {
                    updateStatusLabelSafe(pc.PCName);

                    pc.getOnlineStatus();
                    if (pc.OnlineStatus == "Online")
                    {
                       
                        pc.getFreeSpace();

                        // free space check
                        if (IsThereEnoughFreeSpace(pc))
                        {
                            if (!CheckIfPCExistsinOnlineComputerList(pc))
                            {
                                pc.getCurrentVersion();
                                onlineComputerList.Add(pc);
                            };

                        }
                        else
                        {
                            OfflineComputer offlinePCNoSpace = new OfflineComputer(pc.PCName);
                            if (!offlineComputerList.Contains(offlinePCNoSpace))
                            {
                                offlinePCNoSpace.Reason = "Less than 20GB avail";
                                offlineComputerList.Add(offlinePCNoSpace);
                            }
                        }
                        
                    }
                    else
                    {
                        OfflineComputer offlinePC = new OfflineComputer(pc.PCName);

                        if (!offlineComputerList.Contains(offlinePC))
                        {
                            offlineComputerList.Add(offlinePC);
                        }
                        
                    }
                }
                initialComputerList.Clear();

            });

            label_StaticCurrentlyScanning.Visible = false;
            label_statusLabel.Visible = false;
            source.ResetBindings(false);
            

            // temp to test offline computer tracking
            if (offlineComputerList.Count > 0)
            {
                string offlinePCS = "";

                foreach (var pc in offlineComputerList)
                {
                   offlinePCS = offlinePCS +  pc.PCName.ToString() + "\n";
                }

                MessageBox.Show("The following PCs will be skipped: " + offlinePCS);
               
            }
         
            
        }

        //removes GB from freespace and converts to decimal for comparison
        

        //checks if PC object is already in online computer list based on pc name, used linq
        

        private void button_addPC_Click(object sender, EventArgs e)
        {
            var addPCForm = new AddPCForm();

            addPCForm.Show();
            
        }

        private void button_showOfflinePCs_Click(object sender, EventArgs e)
        {
            var offlinePCForm = new OfflinePCList();
            offlinePCForm.Show();
        }

        private void button_clearList_Click(object sender, EventArgs e)
        {
            onlineComputerList.Clear();
            source.ResetBindings(false);
        }

        private void button_startProcess_Click(object sender, EventArgs e)
        {
            bool isAnyRadioButtonChecked = false;
            bool goodToGo = false;
            //default string
            string installString = "/auto upgrade /quiet";
            foreach (RadioButton rb in groupbox_settings.Controls.OfType<RadioButton>())
            {
                if (rb.Checked)
                {
                    isAnyRadioButtonChecked = true;
                    goodToGo = true;
                    installString = GetInstallStringFromRadioButton(rb);
                   // MessageBox.Show(installString);
                    break;
                }
            }
            if (!isAnyRadioButtonChecked)
            {
                MessageBox.Show("You didn't select anything!");
            }

            if (goodToGo)
            {
                CopyPsExec(onlineComputerList);
                
                foreach (var pc in onlineComputerList)
                {


                }
            }
        }

        

        private void button_RemovePC_Click(object sender, EventArgs e)
        {
            if (onlineComputerList.Count > 0)
            {
                onlineComputerList.RemoveAt(datagrid_pcList.CurrentRow.Index);
                source.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Nothing to remove","Info",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            
        }

        private void label_statusLabel_Click(object sender, EventArgs e)
        {

        }

        private void button_chooseSetup_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog chooseSetupDialog = new OpenFileDialog())
            {
                string localPath = "";
                string finalPath = "";
                chooseSetupDialog.InitialDirectory = "c:\\";
                chooseSetupDialog.Filter = "Executable File (*.exe)|*.exe";
                chooseSetupDialog.FilterIndex = 1;
                chooseSetupDialog.RestoreDirectory = true;

                if (chooseSetupDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = chooseSetupDialog.FileName;
                    FileInfo f = new FileInfo(filePath);
                    localPath = f.FullName.ToString();

                    if (localPath.Contains("C:") || localPath.Contains("D:"))
                    {
                        
                        finalPath = localPath;
                        label_waiting.Text = "Setup Location: ";
                        label_choseSetupLocation.Text = finalPath;
                    }
                    else
                    {
                        finalPath = GetUNC.LocalToUNC(localPath, 200);
                        label_waiting.Text = "Setup Location: ";
                        label_choseSetupLocation.Text = finalPath;
                    }
                }
            }
            
            
            
            
           // MessageBox.Show(test2);

            
        }
    }
}
