using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImagePaste
{
    public partial class MainWindow : Form
    {
        private string  _defaultFileName = "Paste";
        private string  _workingFolder = "";
        private bool _launchedFromPath = false;

        private ClipboardData _clipboardData = null;

        public MainWindow()
        {
            string[] args = Environment.GetCommandLineArgs();

            InitializeComponent();

            if(args.Length > 1)
            {
                _launchedFromPath = true;
                SetWorkingFolder(args[1]);
            }
            else
            {
                string executableDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

                SetWorkingFolder(executableDirectory);
            }

            _uiPathTextBox.Text = GetFileName();

            _clipboardData = GetClipboardData();

            if(_clipboardData.Type  == ClipboardDataType.Image)
            {
                _uiPictureBox.Image = _clipboardData.Image;
                _uiMainButton.Enabled = true;
            }
            else
            {
                _uiMainButton.Enabled = false;
            }
        }

        private ClipboardData GetClipboardData()
        {
            ClipboardData data = new ClipboardData();

            string text = Clipboard.GetText();
            Image image = Clipboard.GetImage();

            if(image != null)
            {
                data.Image = image;
                data.Type = ClipboardDataType.Image;
                return data;
            }

            if (!string.IsNullOrEmpty(text))
            {
                data.Text = text;
                data.Type = ClipboardDataType.Text;
                return data;
            }

            data.Type = ClipboardDataType.None;
            return data;
        }

        private void SetWorkingFolder(string path)
        {
            if (Directory.Exists(path))
            {
                _workingFolder = path;
            }
        }

        private string GetFileName()
        {
            return _defaultFileName + "_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm") + ".png";
        }

        private bool SaveText()
        {
            if (_clipboardData != null && _clipboardData.Type == ClipboardDataType.Text)
            {
                return true;
            }

            return false;
        }

        private bool SaveImage()
        {
            if (_clipboardData != null && _clipboardData.Type == ClipboardDataType.Image &&  _clipboardData.Image != null)
            {
                string outputPath = Path.Combine(_workingFolder, _uiPathTextBox.Text);
                string outputDirectory = Path.GetDirectoryName(outputPath);

                _clipboardData.Image.Save(outputPath);

                if(!_launchedFromPath)
                {
                    Process.Start("explorer.exe", outputDirectory);
                }

                return true;
            }
            return false;
        }

        private void _uiMainButton_Click(object sender, EventArgs e)
        {
            if(SaveImage())
            {
                Application.Exit();
            }
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                Debug.WriteLine("Escape");
                Application.Exit();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
