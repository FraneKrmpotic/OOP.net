using DataLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFApp.Forms;

namespace WFApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!File.Exists(Repository.SETTINGS_PATH) || !File.Exists(Repository.FAVOURITES_PATH))
            {
                File.WriteAllText(Repository.SETTINGS_PATH, Repository.DEFAULT_SETTINGS);
                File.Create(Repository.FAVOURITES_PATH);
                Application.Run(new Settings());
            }
            else
            {
                Application.Run(new Main());
            }
        }
    }
}
