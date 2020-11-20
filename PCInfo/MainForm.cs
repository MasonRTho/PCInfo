﻿using System;
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

        //public void ShowStaticLabel(Label label)
        //{
        //    label.Visible = true;
        //    if (label_StaticCurrentlyScanning.InvokeRequired)
        //    {
        //        var d = new SafeCallDelegate(ShowStaticLabel);
        //        label_StaticCurrentlyScanning.Invoke(d, new object[] { })
        //    }
        //}

      

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

            
            // Initial online status check, using await task to update label and not freeze UI thread.
            // After online check, get version.
            await Task.Run(() =>
            {
                
                foreach (var pc in initialComputerList)
                {
                    updateStatusLabelSafe(pc.PCName);

                    pc.getOnlineStatus();
                    if (pc.OnlineStatus == "Online")
                    {
                        if (!CheckIfPCExistsinOnlineComputerList(pc))
                        {
                            onlineComputerList.Add(pc);
                        };
                        
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
                foreach (var pc in onlineComputerList)
                {
                    pc.getCurrentVersion();
                    pc.getFreeSpace();


                    if (!IsThereEnoughFreeSpace(pc))
                    {
                        OfflineComputer offlinePCNoSpace = new OfflineComputer(pc.PCName);
                        if (!offlineComputerList.Contains(offlinePCNoSpace))
                        {
                            offlinePCNoSpace.Reason = "Less than 20GB avail";
                            offlineComputerList.Add(offlinePCNoSpace);
                        }
                    }
          
                }
            });

            label_StaticCurrentlyScanning.Visible = false;
            source.ResetBindings(false);
            

            // temp to test offline computer tracking
            if (offlineComputerList.Count > 0)
            {
                string offlinePCS = "";

                foreach (var pc in offlineComputerList)
                {
                   offlinePCS = offlinePCS +  pc.PCName.ToString() + "\n";
                }

                MessageBox.Show("The following PCs are offline: " + offlinePCS);
               
            }
         
            
        }

        //removes GB from freespace and converts to decimal for comparison
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

        //checks if PC object is already in online computer list based on pc name, used linq
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
            foreach (var pc in onlineComputerList)
            {

                try
                {
                    if (!System.IO.File.Exists($@"\\{pc.PCName}\c$\windows\temp\psexec.exe")){
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
            foreach (var pc in onlineComputerList)
            {


            }
        }

        private void button_RemovePC_Click(object sender, EventArgs e)
        {
            onlineComputerList.RemoveAt(datagrid_pcList.CurrentRow.Index);
            source.ResetBindings(false);
        }

        private void label_statusLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
