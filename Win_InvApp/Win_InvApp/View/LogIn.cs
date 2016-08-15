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
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Log())
            {
                this.Hide();
                var mWin = new MainWindow();
                mWin.FormClosed += (s, args) => this.Close();
                mWin.Show();
            }
            else
                MessageBox.Show("Incorrect Username or Password");
        }
        delegate void AsyncMethodCaller(String uName, String uPas);

        private bool Log()
        {
            return true;
            AsyncMethodCaller caller = new AsyncMethodCaller(ServerUpDown.LogIn);
            IAsyncResult result = caller.BeginInvoke(tbUserName.Text, tbPassword.Text, null, null);
            Thread.Sleep(0);
            Debug.WriteLine("Thread #{0} is calling LogIn...", Thread.CurrentThread.ManagedThreadId);
            caller.EndInvoke(result);
            Debug.WriteLine("LogIn has finished...");
            if (CB.CloudUser.Current != null)
                return true;
            else
                return false;
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(this, new EventArgs());
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            var wind = new SignUp().ShowDialog();
        }
    }
}