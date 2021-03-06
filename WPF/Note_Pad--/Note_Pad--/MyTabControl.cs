﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.IO;
//using Microsoft.Win32;

namespace Note_Pad__
{
    class MyTabControl : TabControl
    {
        public MyTabControl()
        {

        }

        public NotePadTabItem AddTabItem(string fileName, string filePath)
        {
            NotePadTabItem tabItem = new NotePadTabItem();
            TextBox textBox = new TextBox();
            Grid textgrid = new Grid();
            textgrid.Children.Add(textBox);
            tabItem.Content = textgrid;
            tabItem.fileInfo.fileName = fileName;
            tabItem.fileInfo.fileFullPath = filePath;
            tabItem.Header = fileName;

            textBox.Text = File.ReadAllText(filePath);
            tabItem.txtbox = textBox;

            textBox.KeyDown += textBox_KeyDown;
            Items.Add(tabItem);
           SelectedItem = tabItem;
            return tabItem;
        }

        void textBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            NotePadTabItem tabItem1 = (NotePadTabItem)SelectedItem;
            if(!tabItem1.isDirty)
            {
                tabItem1.Header += "*";
                tabItem1.isDirty = true;
            }
        }

    }
}
