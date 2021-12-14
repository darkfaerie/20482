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

namespace _2048
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Button[,] btns = new Button[7, 5]; int[,] field = new int[9, 7]; Random pepega = new Random(); double[] chisla = new double[10]; int x1, x2, x3, x4; double next2; int achive, score; bool ybl;
        public Window1()
        {
            InitializeComponent();
            int u, l;
            achive = 5;
            u = 7;
            l = 5;
            //указыается количество строк и столбцов в сетке
            ugr.Rows = u;
            ugr.Columns = l;
            //указываются размеры сетки (число ячеек * (размер кнопки в ячейки + толщина её границ))
            ugr.Width = u * (40 + 4);
            ugr.Height = l * (80 + 4);
            //толщина границ сетки
            ugr.Margin = new Thickness(5, 5, 5, 5);
            int y = -1;
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
                    if (i == 6)
                    {
                        btns[i, b].IsEnabled = true;
                    }
                    //btns[i, b].PreviewMouseDown += Btn_MouseDown;
                }
                
            }
            for (int i = 0; i < 9; i++)
            {
                for (int b = 0; b < 7; b++)
                {
                    if (b == 0 || b == 6 || i == 0 || i == 8)
                    {
                        field[i, b] = 9;
                        NEXT.Content = +field[i, b];
                    }
                    else
                    {
                        field[i, b] = 0;
                        NEXT.Content = +field[i, b];
                    }
                }
            }
            for (int i = 0; i < 10; i++)
            {
                chisla[i] = Math.Pow(2, 2 + i);
            }
            next2 = chisla[pepega.Next(0, achive)];
            NEXT.Content = $"Следующее число:{next2}";
            ybl = false;
        }
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            //получение значения лежащего в Tag
            int n = (int)((Button)sender).Tag + 20;
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
            u = 7;
            l = 5;
            n = n - 20;
            x = l - 1; x3 = -1;
            for (int i = 0; i < u; i++)
            {
                x3 = x3 + 1;
                if (n <= x)
                {
                    break;
                }
                else
                {
                    x = x + l;
                }
            }
            x4 = 0; x = x - l + 1;
            while (x != n)
            {
                x4 = x4 + 1;
                x = x + 1;
            }
            rabotaem(x1,x2,x3,x4);
            if (ybl==false)
            {
                next2 = chisla[pepega.Next(0, achive)];
                NEXT.Content = $"Следующее число:{next2}";
            }
            else
            {
                ybl = false;
            }
        }
        private void rabotaem(int c1,int c2, int c3, int c4)
        {
            bool pepega = false; int x = -1; int y = 0;
            while (pepega == false)
            {
                if (field[c1, c2] != 0 & c1 == 7)
                {
                    if (field[c1, c2] == next2)
                    {
                        rabotaem2(c1, c2, c3, c4);
                    }
                    else
                    {
                        ybl = true;
                        MessageBox.Show("Вы не можете поставить сюда иное число!");
                        if (next2 != field[7, 1] & next2 != field[7, 2] & next2 != field[7, 3] & next2 != field[7, 4] & next2 != field[7, 5])
                        {
                            MessageBox.Show($"GOODGAME FINAL SCORE: close window to start next game.");
                            for (int i = 0; i < 5; i++)
                            {
                                btns[6, i].IsEnabled = false;
                            }

                        }
                    }
                    break;
                }
                x = x + 1; y = y + 1;
                if (field[c1 - y, c2] != 0)
                {
                    pepega = true;
                    try
                    {
                        btns[c3 - x + 1, c4].Content = null;
                        btns[c3 - x, c4].Content = next2;
                        field[c1 - x, c2] = Convert.ToInt32(next2);
                        c1 = c1 - x;
                        c3 = c3 - x;
                    }
                    catch
                    {
                        btns[c3 - x, c4].Content = next2;
                        field[c1 - x, c2] = Convert.ToInt32(next2);
                        c1 = c1 - x;
                        c3 = c3 - x;
                    }
                }
                else
                {
                    try
                    {
                        btns[c3 - x + 1, c4].Content = null;
                        btns[c3 - x, c4].Content = next2;
                    }
                    catch
                    {

                    }
                }
            }
            if (field[c1, c2] == 0)
            {

            }
            else
            {
                rabotaem2(c1, c2, c3, c4);
            }
        }
        private void rabotaem2(int p1,int p2,int p3,int p4)
        {
            bool levo=false, pravo=false, niz =false;
            if (field[p1, p2] == field[p1 - 1, p2])
            {
                niz = true;
                field[p1, p2] = field[p1, p2] * 2;
                field[p1 - 1, p2] = 0;
            }
            if (field[p1, p2] == field[p1, p2+1])
            {
                pravo = true;
                field[p1, p2] = field[p1, p2] * 2;
                field[p1, p2+1] = 0;
            }
            if (field[p1, p2] == field[p1, p2 - 1])
            {
                levo = true;
                field[p1, p2] = field[p1, p2] * 2;
                field[p1, p2 - 1] = 0;
            }
            if (niz == true)
            {
                rabotaem(p1, p2, p3, p4);
            }
            if (levo == true)
            {
                rabotaem(p1 + 1, p2 - 1, p3 + 1, p4 - 1);
            }
            if (pravo == true)
            {
                rabotaem(p1 + 1, p2 + 1, p3 + 1, p4 + 1);
            }
        }
    }
}
