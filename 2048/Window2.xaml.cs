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
using System.Windows.Shapes;
using System.Data.SQLite;
using Microsoft.Win32;

namespace _2048
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        string pepega; basedin basa = new basedin();
        public Window2()
        {
            InitializeComponent();
            pepega = null;
            login.Text = null;
        }

        private void avatari_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "*Kartinki|*.jpg;*.png;";
            dlg.ShowDialog();
            pepega = dlg.FileName;
        }

        private void fullend_Click(object sender, RoutedEventArgs e)
        {
            if (pepega == null || login.Text == null)
            {
                MessageBox.Show("Вы не ввели Имя/Аватар");
            }
            else
            {
                try
                {
                    basa.savelogin(login.Text, pepega);
                    Close();
                }
                catch
                {
                    MessageBox.Show("Имя уже занято!");
                }
            }

        }

        private void login_TextChanged(object sender, TextChangedEventArgs e)
        {
            string x;
            x = login.Text;
            x = x.Replace(" ", "");
            login.Text = x;
        }
    }
}
