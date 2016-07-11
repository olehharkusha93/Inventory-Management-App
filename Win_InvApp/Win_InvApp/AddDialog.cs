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
    public partial class AddDialog : Form
    {
        bool fromDefault = false;
        uint id;

        Item nItem;
        public Item newItem { get { return nItem; } }

        public AddDialog()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        private void input_TextChanged(object sender, EventArgs e)
        {
            if (tbID.Text.Length > 0 &&
               tbType.Text.Length > 0 &&
               tbName.Text.Length > 0 &&
               UInt32.TryParse(tbID.Text, out id))
            {
                btnOk.Enabled = true;
            }
            else
                btnOk.Enabled = false;

            fromDefault = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nItem = new Item(tbName.Text, tbType.Text, id);
            if (fromDefault)
                MainWindow.LastID++;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            tbID.Text = MainWindow.LastID.ToString();
            tbType.Text = "Type Name";
            tbName.Text = "Name";
            fromDefault = true;
            btnOk.Enabled = true;

        }
    }
}
