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
using OnBarcode.Barcode.BarcodeScanner;


namespace Win_InvApp
{
    public partial class MainWindow : Form
    {
        
        List<Item> incItems;
        List<Item> dbsItems;
        DataTable incDT;
        DataTable dbsDT;

        static uint lastId = 0;
        static public uint LastID { get { return lastId; } set { lastId = value; } }

        /// <summary>
        /// Index: 0 = _incId, 1 = _incName, 2 = _incType, 3 = _incAdded
        /// </summary>
        String[] TableColumns = { "_incId", "_incName", "_incType", "_incAdded" };

        String[] ComboBoxItems = { "ID", "Name", "Type", "Date Added" };
        int SearchIndex = 2;


        public MainWindow()
        {
            incDT = new DataTable();
            dbsDT = new DataTable();

            foreach (string s in TableColumns)
            {
                incDT.Columns.Add(s, typeof(String));
                dbsDT.Columns.Add(s, typeof(String));
            }


            incItems = new List<Item>();
            dbsItems = new List<Item>();
            InitializeComponent();

            foreach (string s in ComboBoxItems)
                cbSearchType.Items.Add(s);

            cbSearchType.SelectedIndex = 1;

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
            if(Form.ModifierKeys == Keys.Control)
            {
                Item i = new Item("Test Item 1", "Test Item");
                i.ID = lastId++;

                incItems.Add(i);
                PopulateTable();
                return;
            }
            AddDialog d = new AddDialog();
            d.ShowDialog();
            if(d.DialogResult == DialogResult.OK)
            {
                incItems.Add(d.newItem);
                PopulateTable();
                tbSearch.Text = string.Empty;
            }
           
        }

        private void btnRemoveNew_Click(object sender, EventArgs e)
        {
            Remove(incDT, incItems, GetChecked(dgvIncomming));
            PopulateTable();
        }

        private void Remove(DataTable grid, List<Item> items, List<int> delete)
        {
            for (int i = delete.Count - 1; i >= 0; i--)
            {
                items.RemoveAt(delete[i]);
                grid.Rows[delete[i]].Delete();
                grid.AcceptChanges();
            }
        }

        private List<int> GetChecked(DataGridView grid)
        {
            List<int> tmp = new List<int>();
            foreach (DataGridViewRow r in grid.Rows)
            {
                if (true == (bool)r.Cells[0].EditedFormattedValue)
                {
                    tmp.Add(r.Index);
                }
            }

            return tmp;
        }

        private void btnAddDatabase_Click(object sender, EventArgs e)
        {
            List<int> move = GetChecked(dgvIncomming);
            foreach(int i in move)
                dbsItems.Add(incItems[i]);

            Remove(incDT, incItems, move);
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

        private void btnRemoveDatabase_Click(object sender, EventArgs e)
        {
            List<int> move = GetChecked(dgvDatabase);

            if (move.Count == 0)
                return;

            DialogResult result = MessageBox.Show("Are you sure you would like to remove from the database?", String.Empty, MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                Remove(dbsDT, dbsItems, move);
                PopulateTable();
            }
            else if(result == DialogResult.No)
            {
                PopulateTable();
            }
        
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            try
            {
                if (tb.Text == string.Empty)
                {
                    PopulateTable();
                    return;
                }
                CurrencyManager cm = (CurrencyManager)BindingContext[dgvIncomming.DataSource];
                cm.SuspendBinding();
                foreach (DataGridViewRow r in dgvIncomming.Rows)
                {
                    string s = (string)r.Cells[SearchIndex].EditedFormattedValue;
                    if ( s.ToLower().Contains(tb.Text.ToLower()))
                        r.Visible = true;
                    else
                        r.Visible = false;
                }
                cm.ResumeBinding();


                CurrencyManager cm2 = (CurrencyManager)BindingContext[dgvDatabase.DataSource];
                cm2.SuspendBinding();
                foreach (DataGridViewRow r in dgvDatabase.Rows)
                {
                    string s = (string)r.Cells[SearchIndex].EditedFormattedValue;
                    if (s.ToLower().Contains(tb.Text.ToLower()))
                        r.Visible = true;
                    else
                        r.Visible = false;
                }
                cm2.ResumeBinding();
            }
            catch { }
        }

        private void cbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            SearchIndex = cb.SelectedIndex + 1;
            tbSearch_TextChanged(tbSearch, new EventArgs());
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            tbSearch.Clear();
            tbSearch_TextChanged(tbSearch, new EventArgs());
        }

        private void scanButton_Click(object sender, EventArgs e)
        {
            Barcode barcode = new Barcode();
            testBox_scan.Lines = barcode.Scan();
        }
    }
}
