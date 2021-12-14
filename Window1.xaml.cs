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
using System.Media;
using Microsoft.Win32;
using System.Data.SQLite;

namespace _2048
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Button[,] btns = new Button[9, 7]; int x1, x2;  bool volume; BitmapImage ramka = new BitmapImage(new Uri(@"pack://application:,,,/NewFolder1/Fax7euwJVIg.jpg", UriKind.Absolute));  logicin kek = new logicin(); basedin kekb = new basedin(); musicin kekm = new musicin();
        public Window1()
        {                    
            InitializeComponent();
            int u, l;
            kekm.startmusic();
            volume = true;
            u = 9;
            l = 7;
            //указыается количество строк и столбцов в сетке
            ugr.Rows = u;
            ugr.Columns = l;
            //указываются размеры сетки (число ячеек * (размер кнопки в ячейки + толщина её границ))
            ugr.Width = u * (40 + 4);
            ugr.Height = l * (80 + 4);
            //толщина границ сетки
            ugr.Margin = new Thickness(5, 5, 5, 5);
            int y= -1;
            for (int i = 0; i < u; i++)
            {
                for (int b = 0; b < l; b++)
                {
                        y = y + 1;
                        //создание кнопки
                        btns[i, b] = new Button();
                        //запись номера кнопки
                        btns[i, b].Tag = y;
                        //установка размеров кнопки
                        btns[i, b].Width = 50;
                        btns[i, b].Height = 50;
                        //текст на кнопке
                        btns[i, b].Content = " ";
                        //толщина границ кнопки
                        btns[i, b].Margin = new Thickness(2);
                        //при нажатии кнопки, будет вызываться метод Btn_Click
                        btns[i, b].Click += Btn_Click;
                        //добавление кнопки в сетку
                        ugr.Children.Add(btns[i, b]);
                        btns[i, b].IsEnabled = false;
                        btns[i, b].Background = Brushes.White;
                        btns[i, b].Foreground = Brushes.Blue;
                        btns[i, b].FontSize = 23;
                        if (i == 7)
                        {
                            btns[i, b].IsEnabled = true;
                        }
                    if (b == 0 || b == 6 || i == 0 || i == 8)
                    {                      
                        Image img = new Image();
                        img.Source = ramka;
                        StackPanel stackPnl = new StackPanel();
                        stackPnl.Children.Add(img);
                        btns[i, b].Content = stackPnl;
                        if (i == 7)
                        {
                            btns[i, b].IsEnabled = false;
                        }
                    }
                }
                
            }
            kek.sozdanie();
            NEXT.Content = $"Следующее число:{kek.getnext()}";
            scorep.Content = $"SCORE:{kek.getscore()}";          
        }
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
           
            //получение значения лежащего в Tag
            int n = (int)((Button)sender).Tag;
            //установка фона нажатой кнопки, цвета и размера шрифта          
            //запись в нажатую кнопку её номера
            int u = 9;
            int l = 7;
            int x = l - 1; x1 = -1;
            for (int i = 0; i < u; i++)
            {
                x1 = x1 + 1;
                if (n <= x)
                {
                    break;
                }
                else
                {
                    x = x + l;
                }
            }
            x2 = 0; x = x - l + 1;
            while (x != n)
            {
                x2 = x2 + 1;
                x = x + 1;
            }
            kek.checkfri(x1, x2);
            kek.padenie(x1,x2);
            kek.afterpadenie();
            scorep.Content = $"SCORE:{kek.getscore()}";
            for (int i = 0; i < 9; i++)
            {
                for (int b = 0; b < 7; b++)
                {
                    if (b == 0 || b == 6 || i == 0 || i == 8)
                    {

                    }
                    else
                    {
                        if (kek.getchislo(i,b) == 0)
                        {
                            btns[i, b].Content = null;
                        }
                        else
                        {
                            btns[i, b].Content = kek.getchislo(i, b);

                        }
                    }
                }
            }
            if (kek.getgameloss()==true)
            {
                for (int i = 1; i < 6; i++)
                {
                    btns[7, i].IsEnabled = false;
                }
            }
            if (kek.getybl()==false)
            {
                NEXT.Content = $"Следующее число:{kek.getnext()}";
            }
        }            
        private void start_Click(object sender, RoutedEventArgs e)
        {
            if (volume == true)
            {
                kekm.stopmusic();
                volume = false;
            }
            else
            {
                kekm.playmusic();
                volume = true;
            }
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            kekm.stopfullmusic();
        }
        private void save_Click(object sender, RoutedEventArgs e)
        {
            kekb.savescore(kek.getscore());
        }
    }
}
