using Microsoft.Win32;
using System.IO;

namespace ImagePaste
{
    public class RegistryUtils
    {
        const string RegisterName = "ImagePasta";

        public static void RegisterContextMenu()
        {
            RegisterActionForPath(@"Software\Classes\directory\shell\");
            RegisterActionForPath(@"Software\Classes\directory\Background\shell");
        }

        public static void UnregisterContextMenu()
        {
            UnregisterActionForPath(@"Software\Classes\directory\shell\");
            UnregisterActionForPath(@"Software\Classes\directory\Background\shell");
        }

        public static void RegisterActionForPath(string path)
        {
            string executablePath = System.Reflection.Assembly.GetEntryAssembly().Location;
            string executableDirectory = Path.GetDirectoryName(executablePath);

            RegistryKey shellKey = Registry.CurrentUser.OpenSubKey(path, true);

            if (shellKey != null)
            {
                var mainKey = shellKey.OpenSubKey(RegisterName, true);
                if (mainKey == null)
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
                    mainKey.SetValue("icon", Path.Combine(executableDirectory, "icon.ico"));

                    mainKey.Close();
                }
                shellKey.Close();
            }
        }

        public static void UnregisterActionForPath(string path)
        {
            string registryPath = path + "\\" + RegisterName;

            Registry.CurrentUser.DeleteSubKeyTree(registryPath, false);
        }
    }
}
