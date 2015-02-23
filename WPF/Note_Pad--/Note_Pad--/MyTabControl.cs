using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Note_Pad__
{
    class MyTabControl : TabControl
    {
        public MyTabControl()
        {

        }

        public void AddTabItem(string fileName, string filePath)
        {
            TabItem tabItem = new TabItem();
            tabItem.Header = fileName;
            Items.Add(tabItem);
        }
    }
}
