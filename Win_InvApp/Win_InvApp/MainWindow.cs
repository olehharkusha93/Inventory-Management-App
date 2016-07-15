#define DEBUG
//#undef DEBUG

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Win_InvApp
{
    public partial class MainWindow : Form
    {
        
        List<Item> incItems;
        List<Item> dbsItems;
        DataTable incDT;
        DataTable dbsDT;

        uint lastId = 0;

        /// <summary>
        /// Index: 0 = _incId, 1 = _incName, 2 = _incType, 3 = _incAdded
        /// </summary>
        static String[] TableColumns = { "_incId", "_incName", "_incType", "_incAdded" };

        public MainWindow()
        {
            incDT = new DataTable();
            dbsDT = new DataTable();

            foreach (string s in TableColumns)
            {
                incDT.Columns.Add(s, typeof(String));
                dbsDT.Columns.Add(s, typeof(String));
            }
            incDT.Columns.Add("_incAddRmv", typeof(String));


            incItems = new List<Item>();
            dbsItems = new List<Item>();
            InitializeComponent();

            dgvIncomming.DataSource = incDT;
            dgvDatabase.DataSource = dbsDT;
        }

        private void PopulateTable()
        {
            incDT.Clear();
            dbsDT.Clear();
            foreach (Item item in incItems)
            {
                DataRow r = incDT.NewRow();
                for (int i = 0; i < TableColumns.Length; i++)
                {
                    r[i] = item[i];
                }
                incDT.Rows.Add(r);
            }
            foreach (Item item in dbsItems)
            {
                DataRow r = dbsDT.NewRow();
                for (int i = 0; i < TableColumns.Length; i++)
                {
                    r[i] = item[i];
                }
                dbsDT.Rows.Add(r);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
#if DEBUG
            Item i = new Item("Test Item 1", "Test Item");
            i.ID = lastId++;

            incItems.Add(i);
            PopulateTable();
#else
            AddDialog d = new AddDialog();
            d.ShowDialog();
#endif
        }

        private void btnRemoveNew_Click(object sender, EventArgs e)
        {
            IncRemove();
        }

        private void IncRemove()
        {
            List<int> delete = GetIncChecked();
            for (int i = delete.Count - 1; i >= 0; i--)
            {
                incItems.RemoveAt(delete[i]);
                incDT.Rows[delete[i]].Delete();
                incDT.AcceptChanges();
            }
        }

        private List<int> GetIncChecked()
        {
            List<int> tmp = new List<int>();
            foreach (DataGridViewRow r in dgvIncomming.Rows)
            {
                if (true == (bool)r.Cells[0].FormattedValue)
                {
                    tmp.Add(r.Index);
                }
            }

            return tmp;
        }

        private void btnAddDatabase_Click(object sender, EventArgs e)
        {
            List<int> move = GetIncChecked();
            foreach(int i in move)
                dbsItems.Add(incItems[i]);

            IncRemove();
            PopulateTable();

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileStream save = new FileStream();
            save.Save(dbsItems);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileStream open = new FileStream();
            dbsItems = open.Open();
            PopulateTable();
        }
    }
}
