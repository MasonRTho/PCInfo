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
    public partial class FinishedPCs : Form
    {
        public static BindingSource finishedSource = new BindingSource();
        public FinishedPCs()
        {
            InitializeComponent();
            finishedSource.DataSource = MainForm.finishedComputerList;
            dataGridView_finishedPcs.DataSource = finishedSource;
            finishedSource.ResetBindings(false);
        }

        private void button_finishedPcsExport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not working yet");
        }
    }
}
