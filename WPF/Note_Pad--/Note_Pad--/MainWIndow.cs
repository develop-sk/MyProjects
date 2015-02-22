using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;


namespace Note_Pad__
{
    class MainWindow : Window
    {
        private Grid gridPanel;
        
        public MainWindow()
        {
            Title = "NotePad--";
            Height = 400;
            Width = 500;

            gridPanel = new Grid();
            Content = gridPanel;

           

        }
    }
}
