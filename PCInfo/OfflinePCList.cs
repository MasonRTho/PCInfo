using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace PCInfo
{
    public partial class OfflinePCList : Form
    {

        public static BindingSource offlineSource = new BindingSource();
        public OfflinePCList()
        {
            InitializeComponent();
            
            offlineSource.DataSource = MainForm.offlineComputerList;
            datagridview_offlinePCs.DataSource = offlineSource;
            datagridview_offlinePCs.Columns[1].Width = 250;
            offlineSource.ResetBindings(false);
            
        }

        private void copyAlltoClipboard()
        {
            datagridview_offlinePCs.SelectAll();
            datagridview_offlinePCs.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            DataObject dataObj = datagridview_offlinePCs.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void button_exportList_Click(object sender, EventArgs e)
        {
            copyAlltoClipboard();
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Microsoft.Office.Interop.Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }

        private void button_refreshOfflinePCs_Click(object sender, EventArgs e)
        {
            offlineSource.ResetBindings(false);
        }
    }
}
