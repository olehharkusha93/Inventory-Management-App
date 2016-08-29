using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using CB;
using System.Diagnostics;

namespace Win_InvApp.View
{
    public partial class CompanyChooser : Form
    {
        Thread th;
        Dictionary<string, string> dictOrg;
        

        public CompanyChooser(Point p)
        {
            this.Location = p;
            dictOrg = new Dictionary<string, string>();
            InitializeComponent();

            string user = (CloudUser.Current != null) ? CloudUser.Current.Username : "";
            lblWelcome.Text = "Welcome, " + user;
            var org = CloudUser.Current.Get("Organizations");
            if (org != null)
            {
                foreach (var obj in (ArrayList)org)
                {
                    string s = obj.ToString();
                    dictOrg.Add(s, string.Join("", s.Split(' ')));
                    lbOrganizations.Items.Add(s);
                }
            }
            Debug.WriteLine("loaded organizations");


        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(dictOrg.Count != 0)
                ServerUpDown.Table = dictOrg[lbOrganizations.SelectedItem.ToString()];
            this.Close();
            th = new Thread(OpenMain);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(OpenLogin);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void OpenLogin()
        {
            Application.Run(new LogIn());
        }

        private void OpenMain()
        {
            Application.Run(new MainWindow());
        }
    }
}
