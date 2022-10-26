using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImagePaste
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Get args if -register or -unregister
            RegistryUtils.RegisterContextMenu();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
