using Microsoft.Win32;
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
        const string RegisterName = "ImagePasta";

        [STAThread]
        static void Main()
        {
            // Get args if -register or -unregister
            RegisterContextMenu();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }

        static public void RegisterContextMenu()
        {
            RegisterActionForPath(@"Software\Classes\directory\shell\");
            RegisterActionForPath(@"Software\Classes\directory\Background\shell");
        }

        static public void UnregisterContextMenu()
        {
            UnregisterActionForPath(@"Software\Classes\directory\shell\");
            UnregisterActionForPath(@"Software\Classes\directory\Background\shell");
        }

        static void RegisterActionForPath(string path)
        {
            string executablePath      = System.Reflection.Assembly.GetEntryAssembly().Location;
            string executableDirectory = Path.GetDirectoryName(executablePath);

            RegistryKey shellKey = Registry.CurrentUser.OpenSubKey(path, true);
            
            if (shellKey != null)
            {
                var mainKey = shellKey.OpenSubKey(RegisterName, true);
                if(mainKey == null)
                {
                    mainKey = shellKey.CreateSubKey(RegisterName, true);
                }

                if (mainKey != null)
                {
                    var commandKey = mainKey.CreateSubKey("command");
                    if (commandKey != null)
                    {
                        commandKey.SetValue("", $"\"{executablePath}\" \"%V\""); // "" is equals to "(default)"
                        commandKey.Close();
                    }
                    mainKey.SetValue("", "Paste Clipboard");
                    mainKey.SetValue("icon", Path.Combine(executableDirectory,"icon.ico"));
  
                    mainKey.Close();
                }
                shellKey.Close();
            }
        }

        static void UnregisterActionForPath(string path)
        {
            string registryPath = path + "\\" + RegisterName;

            Registry.CurrentUser.DeleteSubKeyTree(registryPath, false);
        }
    }
}
