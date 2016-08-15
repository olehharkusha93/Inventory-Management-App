using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OnBarcode.Barcode.BarcodeScanner;
using System.Diagnostics;
using System.Collections;
using CB;


namespace Win_InvApp
{
    public partial class MainWindow : Form
    {
        delegate void AsyncMethodCaller(out ArrayList list);
        System.Windows.Forms.Timer time;
        Dictionary<String, Item> incItems;
        Dictionary<String, Item> dbsItems;
        List<Item> newItems;
        DataTable incDT;
        DataTable dbsDT;

        static uint lastId = 0;
        public static String[] TableColumns = { "_incId", "_incQuant", "_incName", "_incType", "_incAdded" };
        String[] ComboBoxItems = { "ID", "Quantity", "Name", "Type", "Date Added" };
        string CurrentUser;
        int SearchIndex = 2;
        float fadeTime = 30.0f;
        static public uint LastID { get { return lastId; } set { lastId = value; } }

        public MainWindow()
        {
            CurrentUser = "DefaultUser";
            Init();
        }

        public MainWindow(string _user)
        {
            CurrentUser = _user;
            Init();
        }

        private void Time_Tick(object sender, EventArgs e)
        {
            
        }

        private void Init()
        {
            time = new System.Windows.Forms.Timer();
            time.Tick += Time_Tick;
            incDT = new DataTable();
            dbsDT = new DataTable();
            newItems = new List<Item>();
            incItems = new Dictionary<string, Item>();
            dbsItems = new Dictionary<string, Item>();

            foreach (string s in TableColumns)
            {
                incDT.Columns.Add(s, typeof(String));
                dbsDT.Columns.Add(s, typeof(String));
            }


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
            tbSearch.Clear();
            foreach (Item item in incItems.Values)
            {
                DataRow r = incDT.NewRow();
                for (int i = 0; i < TableColumns.Length; i++)
                {
                    r[i] = item[i];
                }
                incDT.Rows.Add(r);
            }

            foreach (Item item in dbsItems.Values)
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
                i.CloudID = "TestItem" + i.ID;
                i.OnServer = false;
                i.Quantity = 1;
                i.User = CurrentUser;

                incItems.Add(i.CloudID, i);
                newItems.Add(i);
            }
            else
            {
                AddDialog d = new AddDialog();
                d.ShowDialog();
                if (d.DialogResult == DialogResult.OK)
                {
                    d.newItem.OnServer = false;
                    d.newItem.CloudID = "Item" + d.newItem.ID;

                    if (incItems.ContainsKey(d.newItem.CloudID))
                    {
                        incItems[d.newItem.CloudID].Quantity += d.newItem.Quantity;
                        PopulateTable();
                        newItems.Add(d.newItem);
                        return;
                    }
                    newItems.Add(d.newItem);
                    incItems.Add(d.newItem.CloudID, d.newItem);
                }
            }
            
            PopulateTable();

        }

        private void btnRemoveNew_Click(object sender, EventArgs e)
        {
            Remove(incDT, incItems, GetChecked(dgvIncomming));
            PopulateTable();
        }

        private void Remove(DataTable grid, Dictionary<String, Item> items, List<int> delete, bool fromServer = false)
        {
            List<string> remKey = new List<string>();

            foreach (var i in delete)
            {
                remKey.Add(items.ToList()[i].Key);
            }

            if(fromServer)
                ServerUpDown.Remove(remKey);

            for(int i = 0; i < remKey.Count; i++)
            {
                items.Remove(remKey[i]);
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
            foreach (int i in move)
            {
                if (dbsItems.ContainsKey(incItems.ToList()[i].Value.CloudID))
                    dbsItems[incItems.ToList()[i].Value.CloudID].Quantity += incItems.ToList()[i].Value.Quantity;
                else
                    dbsItems.Add(incItems.ToList()[i].Value.CloudID, incItems.ToList()[i].Value);
            }
            Remove(incDT, incItems, move);
            PopulateTable();

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileStream save = new FileStream();
            save.Save(incItems.Values.ToList());
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileStream open = new FileStream();
            Dictionary<string, Item> tmp = open.Open();
            foreach (var item in tmp)
            {
                if (incItems.ContainsKey(item.Key))
                    incItems[item.Key].Quantity += item.Value.Quantity;
                else
                    incItems.Add(item.Key, item.Value);
            }
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
                Remove(dbsDT, dbsItems, move, true);
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
                CurrencyManager cm = (CurrencyManager)BindingContext[dgvIncomming.DataSource];
                CurrencyManager cm2 = (CurrencyManager)BindingContext[dgvDatabase.DataSource];
                if (tb.Text == string.Empty)
                {
                    PopulateTable();
                    return;
                }
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

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServerUpDown.Save(dbsItems);
        }


        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArrayList res;

            AsyncMethodCaller caller = new AsyncMethodCaller(ServerUpDown.Load);
            IAsyncResult result = caller.BeginInvoke(out res, null, null);
            Thread.Sleep(0);
            Debug.WriteLine("Thread #{0} is calling Load...", Thread.CurrentThread.ManagedThreadId);
            caller.EndInvoke(out res, result);
            Debug.WriteLine("Load has finished...");

            foreach (CloudObject item in res)
            {
                Debug.WriteLine("Loaded Item ID: " + item.ID);
                if (!dbsItems.ContainsKey(item.ID))
                {
                    Debug.WriteLine("Added Item ID: " + item.ID);
                    Item temp = new Item(item.Get<string>("Name"), item.Get<string>("Type"));
                    temp.CloudID = item.ID;
                    if (item.Get("User") != null)
                        temp.User = item.Get<string>("User");
                    if(item.Get("Quantity") != null)
                        temp.Quantity = item.Get<uint>("Quantity");
                    temp.OnServer = true;

                    dbsItems.Add(temp.CloudID, temp);
                }
                else
                    Debug.WriteLine("Skipped Item ID: " + item.ID);
            }

            PopulateTable();
        }
    }
}
