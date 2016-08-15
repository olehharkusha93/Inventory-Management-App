using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CB;
using System.Threading;
using System.Diagnostics;

namespace Win_InvApp
{
    public partial class SignUp : Form
    {
        string _username;
        string _password;
        string _email;
        private delegate void AsyncMethodCaller(String uName, String uPas, String uEmail, out CloudUser retUser);
        public SignUp()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            _username = tbUserName.Text;
            _password = tbPassword.Text;
            _email = tbEmail.Text;
            try
            {
                CloudUser outuser; 
                AsyncMethodCaller caller = new AsyncMethodCaller(ServerUpDown.SignUp);
                IAsyncResult result = caller.BeginInvoke(_username, _password, _email, out outuser, null, null);
                Thread.Sleep(0);
                Debug.WriteLine("Thread #{0} is calling Signup...", Thread.CurrentThread.ManagedThreadId);
                caller.EndInvoke(out outuser, result);
                Debug.WriteLine("Signup has finished...");

                if (outuser.Username == "Exception")
                    MessageBox.Show("Error has occured");
                else
                {
                    MessageBox.Show("User created Successfully!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unknonw Error has occured.");
                this.Close();
            }
        }

        private void tbUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnSignUp_Click(this, new EventArgs());
            }
        }

        private void btnCancel_KeyDown(object sender, KeyEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
