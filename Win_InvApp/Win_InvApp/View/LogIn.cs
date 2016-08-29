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
    public partial class LogIn : Form
    {
        bool _dragging = false;
        Point startPoint;
        Thread th;

        public LogIn()
        {
            InitializeComponent();

            btnLogin.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1c50a7");
            btnLogin.ForeColor = Color.Black;
            btnLogin.FlatAppearance.BorderColor = Color.DimGray;
            btnExit.ImageAlign = ContentAlignment.BottomLeft;
            btnExit.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#4979c8");
            btnExit.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#c3d9ff");

            this.CenterToScreen();
            this.Text = Strings.ProgramName + " - Log In";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Log())
            {
                this.Close();
                th = new Thread(OpenCompany);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();

            }
            else
                MessageBox.Show("Incorrect Username or Password");
        }
        delegate void AsyncMethodCaller(String uName, String uPas);

        private bool Log()
        {
            //TOTO (cris): Add company chooser


            //return true;

            var task = Task.Run(async () => await ServerUpDown.LogIn(tbUserName.Text, tbPassword.Text));
            try
            {
                task.Wait();
                var asyncfunctionresult = task.Result;
            }
            catch { }

            if (CB.CloudUser.Current != null)
                return true;
            else
                return false;

        }
        private void OpenCompany()
        {
            Application.Run(new CompanyChooser(this.Location));
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