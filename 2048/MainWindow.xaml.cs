using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;
using Microsoft.Win32;

namespace _2048
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string hochykushat; basedin basa = new basedin();
        public MainWindow()
        {
            InitializeComponent();
            start.IsEnabled = false;
            
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            Window1 lessgo = new Window1();            
            lessgo.ShowDialog();
        }

        private void regi_Click(object sender, RoutedEventArgs e)
        {
            Window2 registriruem = new Window2();
            registriruem.ShowDialog();
        }

        private void login_TextChanged(object sender, TextChangedEventArgs e)
        {
            string x;
            x = login.Text;
            x = x.Replace(" ", "");
            login.Text = x;
        }

        private void vhod_Click(object sender, RoutedEventArgs e)
        {
            basa.find(login.Text);
            if (basa.getsss() == false)
            {
                start.IsEnabled = true;
                hochykushat = login.Text;
                anyo.pic =basa.getpic();
                anyo.dann =basa.getdann();
                anyo.PCname= basa.getdann2();
            }
        }
    }
}
