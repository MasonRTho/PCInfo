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
    public partial class OfflinePCList : Form
    {
        public OfflinePCList()
        {
            InitializeComponent();
            
           foreach(var pc in MainForm.offlineComputerList)
            {
               listview_offlinePCs.Items.Add(pc.PCName);
            }
        }

        private void button_exportList_Click(object sender, EventArgs e)
        {
            //TODO: Export offline PCs
            MessageBox.Show("Not working yet!");
        }
    }
}
