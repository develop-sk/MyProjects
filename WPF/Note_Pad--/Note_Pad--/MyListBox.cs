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

        public NotePadListBoxItem AddListItem(string selectedFile, string filePath)
        {
            NotePadListBoxItem listItem = new NotePadListBoxItem();
            listItem.fileInfo.fileName = selectedFile;
            listItem.fileInfo.fileFullPath = filePath;
            listItem.Content = selectedFile;
            Items.Add(listItem);
            return listItem;
           // SelectedItem = listItem;
        }
    }
}
