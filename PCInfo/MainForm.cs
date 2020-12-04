﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCInfo
{
    public partial class MainForm : Form
    {
        // used later for getting the path of the setup.exe file
        public static string filePath = "";
        public string setupPath = "";

        private delegate void SafeCallDelegate(string text);

        /// <summary>
        /// 3 Object lists for the initial computer list, the online list, and the offline list. The initial list is abandoned early on. Online list is vital
        /// </summary>
        List<Computer> initialComputerList = new List<Computer>();
        public static List<Computer> onlineComputerList = new List<Computer>();
        public static List<OfflineComputer> offlineComputerList = new List<OfflineComputer>();

        public static BindingSource source = new BindingSource();


        static Timer processTimer = new Timer();

        static bool exitProcessTimer = false;
        //static exitProcessTimer = new Timer();

        //initializing messagebox for confirmation on starting setup
        const string message = "Are you sure you want to start setup?";
        const string caption = "Point of no return";
        DialogResult goodToGoMessageBox;

        private void StartTimers()
        {
            processTimer.Tick += new EventHandler(GetProcessActive);
            processTimer.Interval = 3000;
            processTimer.Start();
        }
        private static void GetProcessActive(object sender, EventArgs e)
        {

            for (var i = 0; i < onlineComputerList.Count; i++)
            {
                var tempPC = onlineComputerList[i];
                tempPC.getProcessStatus();
                tempPC.getTimeStamp();
                tempPC.getLogStatus();
                source.ResetBindings(false);
            }

        }

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

        //TODO: Test this more
        private static bool CopyPsExec(Computer computer)
        {
            bool success = false;
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
                    success = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"There was an error copying PSExec to {pc.PCName}.\n" + ex.ToString() + "\n" + "The PC will be removed");

                    success = false;
                }

            }
            if (success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //use psexec to change the startup type of remote registry. Not very many options to change the startup type if it is disabled. There is spotty WMI, reg edit, or a winfunction
        //figured I would just use psexec if it's already being used anyway.
        private bool EnableRemoteRegistry(string psExecLocation, Computer pc)
        {
            bool success = false;
            try
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.FileName = psExecLocation;
                p.StartInfo.Arguments = "\\\\" + pc.PCName + " -s sc config remoteregistry start=auto";
                p.Start();
                var error = p.StandardError.ReadToEnd();
                var output = p.StandardOutput;

                if (error.Contains("error code 0"))
                {
                    success = true;
                }
                else
                {
                    success = false;
                }

            }
            catch (Exception ex)
            {
                success = false;
            }
            if (success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //start the setup with a new process. using psexec, start a process on a remote computer. might use "using" eventually

        private bool StartSetup(string psExecLocation, string argumentList, string pcName)
        {
            bool success = false;
            try
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.FileName = psExecLocation;
                p.StartInfo.Arguments = argumentList;
                p.Start();
                var error = p.StandardError.ReadToEnd();
                var output = p.StandardOutput;


                if (error.Contains("setup.exe started on"))
                {
                    success = true;
                }
                else
                {
                    success = false;
                }

            }
            catch (Exception ex)
            {
               // MessageBox.Show("Error starting PsExec on " + pcName + "\n" + ex);
                success = false;
            }

            if (success)
            {
                return true;
            }
            else
            {
                return false;
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
            //used to hide properties from the computer class from showing in the DG
            datagrid_pcList.Columns[6].Visible = false;


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
            //TODO: fix offline computer tracking
            if (offlineComputerList.Count > 0)
            {
                string offlinePCS = "";

                foreach (var pc in offlineComputerList)
                {
                    offlinePCS = offlinePCS + pc.PCName.ToString() + "\n";
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
            //todo: if the start button can be clicked again, reset bool values
            bool isAnyRadioButtonChecked = false;
            bool goodToGoRadio = false;
            bool goodToGoSetupPath = false;
            bool goodToGoSetup = false;
            //default string
            string installString = "/auto upgrade /quiet";

            string noPcPsexecLocation = "\\c$\\windows\\temp\\psexec.exe";
            string noPcArgumentList = " -s -i -d " + setupPath + " " + installString;
            string finalPcPsexeclocation = "";
            string finalPcArgumentList = "";


            //do a final online status check
            for (var i = 0; i < onlineComputerList.Count; i++)
            {
                var tempComputer = onlineComputerList.ElementAt<Computer>(i);
                tempComputer.getOnlineStatus();
                if (tempComputer.OnlineStatus == "Offline")
                {
                    onlineComputerList.Remove(tempComputer);
                    source.ResetBindings(false);
                    OfflineComputer offlinePCfinalCheck = new OfflineComputer(tempComputer.PCName, "Failed final offline check");
                    offlineComputerList.Add(offlinePCfinalCheck);
                    MessageBox.Show(tempComputer.PCName.ToUpper() + " has gone offline, removing from list");
                }
            }

            //check if any radio button is selected
            foreach (RadioButton rb in groupbox_settings.Controls.OfType<RadioButton>())
            {
                if (rb.Checked)
                {
                    isAnyRadioButtonChecked = true;
                    goodToGoRadio = true;
                    installString = GetInstallStringFromRadioButton(rb);
                    // MessageBox.Show(installString);
                    break;
                }
            }
            if (!isAnyRadioButtonChecked)
            {
                MessageBox.Show("You didn't select anything!");
                goodToGoRadio = false;
            }
            //if something is checked, make sure a setup.exe file is selected
            if (goodToGoRadio)
            {
                if (setupPath.Length > 0)
                {
                    goodToGoSetupPath = true;
                }
                else
                {
                    MessageBox.Show("You didn't choose the setup file");
                    goodToGoSetupPath = false;
                }
            }
            // if a setup path is selected, attempt to copy psexec
            if (goodToGoSetupPath)
            {
                for (var i = 0; i < onlineComputerList.Count; i++)
                {
                    var tempComputer = onlineComputerList.ElementAt<Computer>(i);
                    if (!CopyPsExec(tempComputer))
                    {
                        onlineComputerList.Remove(tempComputer);
                        source.ResetBindings(false);
                        OfflineComputer offlinePCfinalCheck = new OfflineComputer(tempComputer.PCName, "Failed to copy PSExec");
                        offlineComputerList.Add(offlinePCfinalCheck);
                        MessageBox.Show("Failed to copy PsExec to " + tempComputer.PCName.ToUpper() + " removing from list");
                    }

                }

            }
            if(goodToGoRadio && goodToGoSetupPath)
            {
                if (onlineComputerList.Count > 0)
                {

                    for (var i = 0; i < onlineComputerList.Count; i++)
                    {
                        var tempComputer = onlineComputerList.ElementAt<Computer>(i);
                        //get start type of remoteregistry
                        ServiceController sc = new ServiceController("RemoteRegistry", tempComputer.PCName);
                        var startType = sc.StartType.ToString();

                        finalPcPsexeclocation = "\\\\" + tempComputer.PCName + noPcPsexecLocation;
                        finalPcArgumentList = "\\\\" + tempComputer.PCName + noPcArgumentList;
                        if (startType.Contains("Disabled") || startType.Contains("Manual"))
                        {
                            if (!EnableRemoteRegistry(finalPcPsexeclocation, tempComputer))
                            {
                                onlineComputerList.Remove(tempComputer);
                                source.ResetBindings(false);
                                OfflineComputer offlinePCfinalCheck = new OfflineComputer(tempComputer.PCName, "Failed to enable remote registry");
                                offlineComputerList.Add(offlinePCfinalCheck);
                                MessageBox.Show("Failed to enabled Remote Registry on " + tempComputer.PCName.ToUpper() + ": Removing from list.");
                            }
                            source.ResetBindings(false);
                        }
                        else
                        {
                            goodToGoSetup = true;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("There are no computers in the list");
                }
            }


            if (goodToGoSetup)
            {
                goodToGoMessageBox = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }

           
            if (goodToGoMessageBox == DialogResult.Yes)
            {
                for (var i = 0; i < onlineComputerList.Count; i++)
                {
                    var tempComputer = onlineComputerList.ElementAt<Computer>(i);
                    if (StartSetup(finalPcPsexeclocation, finalPcArgumentList, tempComputer.PCName))
                    {
                        button_addPC.Enabled = false;
                        button_clearList.Enabled = false;
                        button_RemovePC.Enabled = false;
                        button_selectList.Enabled = false;
                        StartTimers();
                    }
                    else
                    {
                        onlineComputerList.Remove(tempComputer);
                        source.ResetBindings(false);
                        OfflineComputer offlinePCfinalCheck = new OfflineComputer(tempComputer.PCName, "Failed to start setup (tell Mason)");
                        offlineComputerList.Add(offlinePCfinalCheck);
                        MessageBox.Show("Failed to start setup on " + tempComputer.PCName.ToUpper() + ": Removing from list.");
                    }
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
                MessageBox.Show("Nothing to remove", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void label_statusLabel_Click(object sender, EventArgs e)
        {

        }

        // button for choosing the location of the setupfile. uses a windows function to convert the network path to UNC. little touchy with pointers, but seems to work. see GetUNC.cs for more info
        private void button_chooseSetup_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog chooseSetupDialog = new OpenFileDialog())
            {
                string localPath = "";
                chooseSetupDialog.InitialDirectory = "c:\\";
                chooseSetupDialog.Filter = "Setup File|setup.exe";
                chooseSetupDialog.FilterIndex = 1;
                chooseSetupDialog.RestoreDirectory = true;

                if (chooseSetupDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = chooseSetupDialog.FileName;
                    FileInfo f = new FileInfo(filePath);
                    localPath = f.FullName.ToString();

                    if (localPath.Contains("C:") || localPath.Contains("D:"))
                    {

                        setupPath = localPath;
                        label_waiting.Text = "Setup Location: ";
                        label_choseSetupLocation.Text = setupPath;
                    }
                    else
                    {
                        setupPath = GetUNC.LocalToUNC(localPath, 200);
                        label_waiting.Text = "Setup Location: ";
                        label_choseSetupLocation.Text = setupPath;
                    }
                }
            }






        }
    }
}
