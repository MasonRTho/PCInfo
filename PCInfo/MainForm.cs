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
        private delegate void SafeCallDelegate(string text);
        List<Computer> initialComputerList = new List<Computer>();
        public static List<Computer> onlineComputerList = new  List<Computer>();
        public static List<Computer> offlineComputerList = new List<Computer>();
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
                label_statusLabel.Invoke(d, new object[] { pcName });
            }
            else
            {
                
                label_statusLabel.Text = pcName;
            }
            
        }

      

        public MainForm()
        {
            InitializeComponent();
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
                        onlineComputerList.Add(pc);
                    }
                    else
                    {
                        if (!offlineComputerList.Contains(pc))
                        {
                            offlineComputerList.Add(pc);
                        }
                        
                    }
                }
                initialComputerList.Clear();
                foreach (var pc in onlineComputerList)
                {
                    pc.getCurrentVersion();
                    pc.getFreeSpace();
                }
            });

            

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
                    object[] theProcessToRun = { "\\\fs1\\userapps\\1909\\setup.exe \"/auto upgrade\" \"/quiet\"" };
                    ConnectionOptions theConnection = new ConnectionOptions();

                    //theConnection.Username = @"MyDomain\Admin";
                    //theConnection.Password = "mypassword";
                    ManagementScope theScope = new ManagementScope("\\\\" + pc.PCName + "\\root\\cimv2", theConnection);
                    ManagementClass theClass = new ManagementClass(theScope, new ManagementPath("Win32_Process"), new ObjectGetOptions());
                    theClass.InvokeMethod("Create", theProcessToRun);
                    MessageBox.Show("created");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }
            }
        }
    }
}
