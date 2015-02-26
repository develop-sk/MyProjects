using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Note_Pad__
{

    class NotePadListBoxItem : ListBoxItem
    {
        public FileInfo fileInfo;

        public NotePadListBoxItem() : base()
        {
            fileInfo = new FileInfo();
        }
    }
}
