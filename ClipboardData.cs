using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagePaste
{
    public enum ClipboardDataType
    {
        None,
        Text,
        Image
    }

    public class ClipboardData
    {
        public ClipboardDataType Type;
        public Image Image;
        public string Text;
    }
}
