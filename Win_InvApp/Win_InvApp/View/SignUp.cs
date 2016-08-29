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

namespace Win_InvApp.View
{
    public partial class SignUp : Form
    {
        string _username;
        string _password;
        string _email;
        public SignUp()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            _username = tbUserName.Text;
            _password = tbPassword.Text;
            _email = tbEmail.Text;



            if (!CheckFields())
                return;

            try
            {
                CloudUser outuser; 
                Debug.WriteLine("Thread #{0} is calling Signup...", Thread.CurrentThread.ManagedThreadId);
                try
                {
                    var task = Task.Run(async () => await ServerUpDown.SignUp(_username, _password, _email));
                    task.Wait();
                    outuser = task.Result;
                }
                catch { outuser = new CloudUser(); outuser.Username = "Exception"; }

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

        private bool CheckFields()
        {
            if (String.IsNullOrEmpty(tbEmail.Text) ||
                String.IsNullOrEmpty(tbUserName.Text) ||
                String.IsNullOrEmpty(tbPassword.Text) ||
                String.IsNullOrEmpty(tbRePass.Text))
            {
                MessageBox.Show("Please fill in all fields");
                return false;
            }
            if (!tbPassword.Text.Equals(tbRePass.Text, StringComparison.Ordinal))
            {
                MessageBox.Show("Passwords do not match");
                return false;
            }

            return true;
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
