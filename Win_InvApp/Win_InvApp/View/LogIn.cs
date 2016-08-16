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
        bool _dragging = false;
        Point startPoint;

        public LogIn()
        {
            InitializeComponent();
            //btnLogin.BackColor = ColorTranslator.FromHtml("#0043b2");
            btnLogin.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1c50a7");
            btnLogin.ForeColor = Color.Black;
            btnLogin.FlatAppearance.BorderColor = Color.DimGray;
            this.CenterToScreen();
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

        private void btn_OnHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void LogIn_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void LogIn_MouseMove(object sender, MouseEventArgs e)
        {
            if(_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void LogIn_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }
    }
}