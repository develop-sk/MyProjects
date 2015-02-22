using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Threading.Tasks;

namespace Note_Pad__
{
    class ApplicationWindow : Window
    {
        [System.STAThread]
        public static void Main(string[] args)
        {
            Application app = new Application();
            MainWindow win = new MainWindow();
            app.Run(win);
        }
    }
}
