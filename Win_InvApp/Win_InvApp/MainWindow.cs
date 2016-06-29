using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win_InvApp
{
    public partial class MainWindow : Form
    {
        List<Item> items;
        DataTable incDT;
        public MainWindow()
        {
            incDT = new DataTable();
            items = new List<Item>();
            InitializeComponent();
            dgvIncomming.VirtualMode = true;
        }

        private void AddItem()
        {
            Item i = new Item("Test Item 1", "Test Item");
            if (items.Count != 0)
                i.ID = items[items.Count - 1].ID + 1;
            else
                i.ID = 0;

            items.Add(i);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void dgvIncomming_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex >= items.Count)
                return;

            //DataGridViewRow row = this.dgvIncomming.Rows[e.RowIndex];
            //row.Cells[1].Value = items[e.RowIndex].ID;
            //row.Cells[2].Value = items[e.RowIndex].Name;
            //row.Cells[3].Value = items[e.RowIndex].Type;
            //row.Cells[4].Value = items[e.RowIndex].Added;
            //DataGridViewTextBoxCell tbs = new DataGridViewTextBoxCell();


        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            AddItem();
            dgvIncomming.RowCount++;
            dgvIncomming.Invalidate();
        }
    }
}
