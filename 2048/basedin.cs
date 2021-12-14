using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace _2048
{
    class basedin
    {
        ImageSource pepo; string da,net; bool sss;
        public void savescore(int scoraya)
        {
            string db_name = @"C:\Users\Дом\source\repos\2048\gneg.db";
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=" + db_name + ";Version=3;");
            //открытие соединения с базой данных
            m_dbConnection.Open();
            //выполнение запросов
            string sql = $"UPDATE nicknames SET score = '{scoraya}' WHERE nick = '{MainWindow.hochykushat}'";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            //извлечение запроса
            command.ExecuteNonQuery();
            //закрытие соединения с базой данных
            m_dbConnection.Close();
            MessageBox.Show("Успешно сохранено! Для обновления значений в профиле войдите снова.");
        }
        public void savelogin(string g, string gg)
        {
            //имя базы данных
            string db_name = @"C:\Users\Дом\source\repos\2048\gneg.db";
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=" + db_name + ";Version=3;");
            //открытие соединения с базой данных
            m_dbConnection.Open();
            //выполнение запросов
            string sql = $"INSERT INTO	nicknames (nick,avatar,score) VALUES ('{g}','{gg}', '0')";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            //извлечение запроса
            command.ExecuteNonQuery();
            //закрытие соединения с базой данных
            m_dbConnection.Close();
            MessageBox.Show("Регистрация прошла успешно!");
        }
        public void find(string h)
        {
            string loginh; bool kosyak = false; sss = false;
            try
            {
                loginh = h;
                //имя базы данных
                string db_name = @"C:\Users\Дом\source\repos\2048\gneg.db";
                SQLiteConnection m_dbConnection;
                m_dbConnection = new SQLiteConnection("Data Source=" + db_name + ";Version=3;");
                //открытие соединения с базой данных
                m_dbConnection.Open();
                string sql = $"SELECT nick FROM nicknames";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader1 = command.ExecuteReader();
                while (reader1.Read())
                {
                    if (loginh == Convert.ToString(reader1["nick"]))
                    {
                        kosyak = true;
                        break;
                    }
                }
                if (kosyak == true)
                {
                    sql = $"SELECT avatar FROM nicknames WHERE nick = '{h}'";
                    command = new SQLiteCommand(sql, m_dbConnection);
                    SQLiteDataReader reader2 = command.ExecuteReader();
                    while (reader2.Read())
                        pepo = new BitmapImage(new Uri(Convert.ToString(reader2["avatar"])));
                    sql = $"SELECT score FROM nicknames WHERE nick = '{h}'";
                    command = new SQLiteCommand(sql, m_dbConnection);
                    SQLiteDataReader reader3 = command.ExecuteReader();
                    while (reader3.Read())
                        da = $"Счёт в последней игре:\n{Convert.ToString(reader3["score"])}";
                    m_dbConnection.Close();
                    net = $"Добро пожаловать,\n{h}!";
                    MessageBox.Show("Добро пожаловать!");                                  
                }
                else
                {
                    MessageBox.Show("Неверный логин!");
                    sss = true;
                }
            }
            catch
            {
                MessageBox.Show("Неверный логин!");
                sss = true;
            }
        }
        public string getdann()
        {
            return da;
        }
        public string getdann2()
        {
            return net;
        }
        public ImageSource getpic()
        {
            return pepo;
        }
        public bool getsss()
        {
            return sss;
        }
    }
}
