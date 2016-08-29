using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Win_InvApp.View;

namespace Win_InvApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SetStrings();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogIn());
        }

        static void SetStrings()
        {
            Strings.Copyright = "Copyright © 2016 Brandon Bigelow, Cristobal Hall-Ramos, Gabriel Leo, Ole Haruksha";
        }
    }
}
