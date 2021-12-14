using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Data.SQLite;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace _2048
{
    [TestFixture]
    class baza_test
    {
        basedin testr = new basedin();
        [TestCase]
        public void Testsavescore()
        {
            MainWindow.hochykushat = "ванёк";
            testr.savescore(5);
            testr.find("ванёк");
            Assert.AreEqual("Счёт в последней игре:\n5", testr.getdann());
        }
        [TestCase]
        public void Testsavescore2()
        {
            MainWindow.hochykushat = "ванёк";
            // получение исключения
            var exception = Assert.Throws<OverflowException>(() => testr.savescore(Convert.ToInt32(Convert.ToDouble(2147483649))));
            // сравнение полученного сообщения с ожидаемым
            Assert.That(exception.Message, Is.EqualTo("Значение было недопустимо малым или недопустимо большим для Int32."));
        }
        [TestCase]
        public void Testsavelogin()
        {         
            testr.savelogin("ванек2", @"C:\Users\Дом\source\repos\2048\2048\NewFolder1\Fax7euwJVIg.jpg");
            testr.find("ванек2");
            Assert.AreEqual("Добро пожаловать,\nванек2!", testr.getdann2());
        }
        [TestCase]
        public void Testsavelogin2()
        {
            var exception = Assert.Throws<SQLiteException>(() => testr.savelogin("ванёк", @"C:\Users\Дом\source\repos\2048\2048\NewFolder1\Fax7euwJVIg.jpg"));
            // сравнение полученного сообщения с ожидаемым
            Assert.That(exception.Message, Is.EqualTo("constraint failed\r\nUNIQUE constraint failed: nicknames.nick"));
        }
        [TestCase]
        public void Testfind()
        {
            testr.find("ванёк");
            ImageSource sss = new BitmapImage(new Uri(@"C:\Users\Дом\Desktop\FZGZwpsJvJo.jpg"));
            Assert.AreEqual("Добро пожаловать,\nванёк!", testr.getdann2());
            Assert.AreEqual("Счёт в последней игре:\n5", testr.getdann());
            Assert.AreEqual(sss, testr.getpic());
        }
        [TestCase]
        public void Testfind2()
        {
            testr.find("ванёк5");
            // сравнение полученного сообщения с ожидаемым
            Assert.That(testr.getsss, Is.EqualTo(true));
        }
    }
}
