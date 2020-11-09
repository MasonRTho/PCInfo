using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCInfo
{
    public partial class MainForm : Form
    {

        List<Computer> initialComputerList = new List<Computer>();
        List<Computer> onlineComputerList = new List<Computer>();
        List<Computer> offlineComputerList = new List<Computer>();

        private void setDataGrid(string text)
        {
            datagrid_pcList.Rows.Add(text);
        }

        public void getStatus(string pc)
        {
            label_statusLabel.Text = "Checking status of: " + pc;
        }

        public MainForm()
        {
            InitializeComponent();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_selectList_Click(object sender, EventArgs e)
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

            foreach (var pc in initialComputerList)
            {
                getStatus(pc.PCName);
                pc.getOnlineStatus();
                if (pc.OnlineStatus == "Online")
                {
                    onlineComputerList.Add(pc);
                }
                else
                {
                    offlineComputerList.Add(pc);
                }
            }

            foreach (var pc in onlineComputerList)
            {
                pc.getCurrentVersion();
            }

            datagrid_pcList.DataSource = onlineComputerList;
            label_statusLabel.Text = "";

            if (offlineComputerList.Count > 0)
            {
                string offlinePCS = "";

                foreach (var pc in offlineComputerList)
                {
                   offlinePCS = offlinePCS +  pc.PCName.ToString() + "`n";
                }

                MessageBox.Show("The following PCs are offline: " + offlinePCS);
               
            }
         
            
        }
    }
}
