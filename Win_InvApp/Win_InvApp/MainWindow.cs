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
        DataTable dbsDT;

        /// <summary>
        /// Index: 0 = _incId, 1 = _incName, 2 = _incType, 3 = _incId
        /// </summary>
        static String[] TableColumns = {"_incId", "_incName", "_incType", "_incAdded" };

        public MainWindow()
        {
            incDT = new DataTable();
            dbsDT = new DataTable();

            incDT.Columns.Add(TableColumns[0], typeof(String));
            incDT.Columns.Add(TableColumns[1], typeof(String));
            incDT.Columns.Add(TableColumns[2], typeof(String));
            incDT.Columns.Add(TableColumns[3], typeof(String));

            dbsDT.Columns.Add(TableColumns[0], typeof(String));
            dbsDT.Columns.Add(TableColumns[1], typeof(String));
            dbsDT.Columns.Add(TableColumns[2], typeof(String));
            dbsDT.Columns.Add(TableColumns[3], typeof(String));


            items = new List<Item>();
            InitializeComponent();

            dgvIncomming.DataSource = incDT;
        }

        private void AddItem()
        {
            Item i = new Item("Test Item 1", "Test Item");
            if (items.Count != 0)
                i.ID = items[items.Count - 1].ID + 1;
            else
                i.ID = 0;

            items.Add(i);
            PopulateTable();
        }

        private void PopulateTable()
        {
            incDT.Clear();
            foreach (Item item in items)
            {
                DataRow r = incDT.NewRow();
                for (int i = 0; i < TableColumns.Length; i++)
                {
                    r[i] = item[i];
                }
                incDT.Rows.Add(r);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            AddItem();
        }

        private void dgvIncomming_DataSourceChanged(object sender, EventArgs e)
        {

        }
    }
}
