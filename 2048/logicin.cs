using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _2048
{
    class logicin
    {
        int[,] field = new int[9, 7]; int achive, score, openarchive; bool ybl,infinity,fri,gameloss, retry; double next2; Random pepega = new Random(); double[] chisla = new double[10]; musicin jam = new musicin();
        public void sozdanie()
        {
            achive = 5;
            score = 0;
            infinity = false;
            openarchive = 1024;
            ybl = false;
            gameloss = false;
            for (int i = 0; i < 9; i++)
            {
                for (int b = 0; b < 7; b++)
                {
                    if (b == 0 || b == 6 || i == 0 || i == 8)
                    {
                        field[i, b] = 666;
                    }
                    else
                    {
                        field[i, b] = 0;
                    }
                }
            }
            for (int i = 0; i < 10; i++)
            {
                chisla[i] = Math.Pow(2, 2 + i);
            }
            next2 = chisla[pepega.Next(0, achive)];
        }
        public int getchislo(int x, int y)
        {
            return field[x, y];
        }
        public bool getybl()
        {
            return ybl;
        }
        public void zadamnext(double x)
        {
            next2 = x;
        }
        public bool getgameloss()
        {
            return gameloss;
        }
        public double getnext()
        {
            return next2;
        }
        public int getscore()
        {
            return score;
        }
        public void afterpadenie()
        {
            if (getybl() == false)
            {
                next2 = chisla[pepega.Next(0, achive)];              
            }
            else
            {
                ybl = false;
            }
        }
        public void checkfri(int x1, int x2)
        {
            if (x1 == 7 & field[x1, x2] != 0)
            {
                fri = false;
            }
            else
            {
                if (x1 == 7 & field[x1, x2] == 0)
                {
                    fri = true;
                }
                field[x1, x2] = Convert.ToInt32(next2);
            }
        }
        public void padenie(int c1, int c2)
        {
            retry =true;
            bool pepega = false; int x = -1; int y = 0;
            while (pepega == false)
            {
                x = x + 1; y = y + 1;
                if (field[c1 - y, c2] != 0)
                {
                    pepega = true;
                    field[c1 - x, c2] = field[c1, c2];
                    if ((c1 - x) == 7)
                    {

                    }
                    else
                    {
                        field[c1, c2] = 0;
                    }
                    c1 = c1 - x;
                    if (field[c1, c2] != 0 & c1 == 7)
                    {
                        if (field[c1, c2] == next2)
                        {
                            if (fri == true)
                            {
                                field[c1, c2] = field[c1, c2];
                                fri = false;
                            }
                            else
                            {
                                field[c1, c2] = field[c1, c2] * 2;
                            }
                            styajka(c1, c2);
                        }
                        else
                        {
                            ybl = true;
                            SystemSounds.Asterisk.Play();
                            MessageBox.Show("Вы не можете поставить сюда иное число!");
                            if (next2 != field[7, 1] & next2 != field[7, 2] & next2 != field[7, 3] & next2 != field[7, 4] & next2 != field[7, 5] & field[7, 1] != 0 & field[7, 2] != 0 & field[7, 3] != 0 & field[7, 4] != 0 & field[7, 5] != 0)
                            {
                                jam.playmeow();
                                MessageBox.Show($"GOODGAME FINAL SCORE:{score} close window to start next game.");
                                gameloss = true;
                            }
                        }
                        break;
                    }
                }
            }
            if (field[c1, c2] == 0)
            {

            }
            else
            {
                styajka(c1, c2);
            }
        }
        public void styajka(int p1, int p2)
        {
            if (field[p1, p2] == 0)
            {

            }
            else
            {
                bool levo = false, pravo = false, niz = false; int x = 0;
                if (field[p1, p2] == field[p1 - 1, p2])
                {
                    x = x + 1;
                    niz = true;
                    field[p1 - 1, p2] = 0;
                    score = score + 5;                  
                }
                if (field[p1, p2] == field[p1, p2 + 1])
                {
                    x = x + 1;
                    pravo = true;
                    field[p1, p2 + 1] = 0;
                    score = score + 5;
                }
                if (field[p1, p2] == field[p1, p2 - 1])
                {
                    x = x + 1;
                    levo = true;
                    field[p1, p2 - 1] = 0;
                    score = score + 5;
                }
                field[p1, p2] = field[p1, p2] * Convert.ToInt32(Math.Pow(2, x));
                if (niz == true)
                {
                    padenie(p1, p2);

                }
                if (levo == true)
                {
                    if (field[p1 + 1, p2 - 1] != 666)
                    {
                        padenie(p1 + 1, p2 - 1);
                    }
                    for (int y = p1; y < 6; y++)
                    {
                        if (field[y + 2, p2 - 1] != 0)
                        {
                            padenie(y + 2, p2 - 1);
                        }
                    }

                }
                if (pravo == true)
                {
                    if (field[p1 + 1, p2 + 1] != 666)
                    {
                        padenie(p1 + 1, p2 + 1);
                    }
                    for (int y = p1; y < 6; y++)
                    {
                        if (field[y + 2, p2 + 1] != 0)
                        {
                            padenie(y + 2, p2 + 1);
                        }
                    }
                }
                if (field[p1, p2] == openarchive)
                {
                    if (achive == 9)
                    {

                    }
                    else
                    {
                        achive = achive + 1;
                        jam.playmeow();
                        MessageBox.Show($"Поздравляю! Вы все ближе к победе. Открыт блок:{Math.Pow(2, achive + 1)}");
                        openarchive = openarchive * 2;
                    }
                    if (achive == 9)
                    {
                        if (infinity == false)
                        {
                            jam.playapplause();
                            MessageBox.Show($"Поздравляю! Вы открыли последний блок. Игра пройдена, но вы можете продолжить играть в бесконечном режиме");
                        }
                        infinity = true;
                    }
                }
                if (retry == true)
                {
                    retry = false;
                    styajka(p1, p2);
                }              
            }
        }     
    }
}
