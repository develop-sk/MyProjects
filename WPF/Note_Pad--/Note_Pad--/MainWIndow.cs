﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using Microsoft.Win32;

namespace Note_Pad__
{
    class MainWindow : Window
    {
        private Grid gridPanel;
        private MainMenu mainMenu;
        private MyListBox myList;
        private MyTabControl myTab;
        List<string> filePath;
        public MainWindow()
        {
            Title = "NotePad--";
            Height = 400;
            Width = 500;

            gridPanel = new Grid();
            Content = gridPanel;

            RowDefinition row1 = new RowDefinition();
            row1.Height = GridLength.Auto;
            RowDefinition row2 = new RowDefinition();
            row2.Height = new GridLength(1, GridUnitType.Star);

            gridPanel.RowDefinitions.Add(row1);
            gridPanel.RowDefinitions.Add(row2);

            mainMenu = new MainMenu();
            Grid.SetRow(mainMenu, 0);
            gridPanel.Children.Add(mainMenu);
            //Creating MenuItems
            MenuItem fileItem = new MenuItem();
            fileItem.Header = "_FILE";

            MenuItem fileItemNew = new MenuItem();
            fileItemNew.Header = "New";
            MenuItem fileItemOpen = new MenuItem();
            fileItemOpen.Header = "Open";
            fileItemOpen.Click += fileItemOpen_Click;

            fileItem.Items.Add(fileItemNew);
            fileItem.Items.Add(fileItemOpen);

            MenuItem editItem = new MenuItem();
            editItem.Header = "_EDIT";

            MenuItem editItemSave = new MenuItem();
            editItemSave.Header = "Save";
            editItemSave.Click += editItemSave_Click;
            MenuItem editItemExit = new MenuItem();
            editItemExit.Header = "Exit";
            editItem.Items.Add(editItemSave);
            editItem.Items.Add(editItemExit);

            MenuItem viewItem = new MenuItem();
            viewItem.Header = "_VIEW";

            mainMenu.Items.Add(fileItem);
            mainMenu.Items.Add(editItem);
            mainMenu.Items.Add(viewItem);

            Grid gridApp = new Grid();

            ColumnDefinition col1 = new ColumnDefinition();
            col1.Width = GridLength.Auto;
            ColumnDefinition col2 = new ColumnDefinition();
            col2.Width = new GridLength(1, GridUnitType.Star);
            gridApp.ColumnDefinitions.Add(col1);
            gridApp.ColumnDefinitions.Add(col2);
            gridPanel.Children.Add(gridApp);
            Grid.SetRow(gridApp, 1);

            myList = new MyListBox();
            Grid.SetColumn(myList, 0);
            gridApp.Children.Add(myList);
            myTab = new MyTabControl();
            Grid.SetColumn(myTab, 1);
            gridApp.Children.Add(myTab);

            filePath = new List<string>();
        }

        void fileItemOpen_Click(object sender, RoutedEventArgs e)
        {
            bool filePathAdd = false;
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == true)
            {
                for (int i = 0; i < filePath.Count; i++ )
                {
                    if(ofd.FileName == filePath[i])
                    {
                        filePathAdd = true;
                    }
                }
                if (!(filePathAdd))
                {
                    filePath.Add(ofd.FileName);
                    myList.AddListItem(ofd.SafeFileName);
                    myTab.AddTabItem(ofd.SafeFileName, ofd.FileName);
                }
            }
        }

        void editItemSave_Click(object sender, RoutedEventArgs e)
        {

          
        }
    }
}
