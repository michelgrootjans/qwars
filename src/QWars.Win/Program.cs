using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QWars.Win
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var logon = new Logon();
            logon.ShowDialog();
            Application.Run(new PlayerView{PlayerId = logon.PlayerId});
        }
    }
}
