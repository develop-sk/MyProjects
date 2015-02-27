using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Note_Pad__
{
    class NotePadTabItem : TabItem
    {
        public FileInfo fileInfo;
        public TextBox txtbox;
        public bool isDirty = false;

        public NotePadTabItem() : base()
        {
            fileInfo = new FileInfo();
        }
    }
}
