using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Note_Pad__
{
    class MyListBox : ListBox
    {
        public MyListBox()
        {

        }

        public void AddListItem(string selectedFile)
        {
            ListBoxItem listItem = new ListBoxItem();
            listItem.Content = selectedFile;
            Items.Add(listItem);
        }
    }
}
