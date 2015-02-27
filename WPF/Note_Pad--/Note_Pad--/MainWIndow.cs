using System;
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

            myList.SelectionChanged += myList_SelectionChanged;
            myTab.SelectionChanged += myTab_SelectionChanged;
            filePath = new List<string>();
        }

//When a TabItem is selected, changing the focus of listitem to that file
        void myTab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabControl tab1 = (TabControl)e.Source;
            NotePadTabItem tabItem = (NotePadTabItem)tab1.SelectedItem;
            NotePadListBoxItem li = null;

            foreach (NotePadListBoxItem listItem in myList.Items)
            {
                if (listItem.fileInfo.fileFullPath.ToString() == tabItem.fileInfo.fileFullPath.ToString())
                {
                    li = listItem;
                }
            }

            myList.SelectedItem = li;
        }

//When a listItem is selected opening that particular TabItem
        void myList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox list1 = (ListBox)e.Source;
            NotePadListBoxItem listItem = (NotePadListBoxItem)list1.SelectedItem;
            NotePadTabItem tb = null;
            foreach(NotePadTabItem tabItem in myTab.Items)
            {
                if(tabItem.fileInfo.fileFullPath.ToString() == listItem.fileInfo.fileFullPath.ToString())
                {
                    tb = tabItem;
                }
            }

                myTab.SelectedItem = tb;
        }

//Opening files
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
                if (!filePathAdd)
                {
                   filePath.Add(ofd.FileName);
                   NotePadListBoxItem newListItem =  myList.AddListItem(ofd.SafeFileName, ofd.FileName);
                   NotePadTabItem newTabItem = myTab.AddTabItem(ofd.SafeFileName, ofd.FileName);
                    myList.SelectedItem = newListItem;
                    myTab.SelectedItem = newTabItem;
                }
            }
        }

        //Saving File
        void editItemSave_Click(object sender, RoutedEventArgs e)
        {
            NotePadTabItem tabItem = (NotePadTabItem)myTab.SelectedItem;
            if(tabItem.isDirty)
            {
                string fileContent = tabItem.txtbox.Text;
                File.WriteAllText(tabItem.fileInfo.fileFullPath, fileContent);
                tabItem.isDirty = false;
            }
            tabItem.Header = tabItem.fileInfo.fileName;
        }
    }
}
