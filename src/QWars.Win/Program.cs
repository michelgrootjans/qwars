using System;
using System.Windows.Forms;
using HibernatingRhinos.Profiler.Appender.NHibernate;

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
            NHibernateProfiler.Initialize();
            Application.Run(new AdministratorView());
        }
    }
}
