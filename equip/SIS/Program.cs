using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TIS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            bool result;
            var mutex = new System.Threading.Mutex(true, "TIS", out result);
            if (result)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MenuForm());
            }
        }
    }
}
