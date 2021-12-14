using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace _2048
{
    [TestFixture]
    class logic_test
    {
        logicin tessr = new logicin();
        [TestCase]
        public void padaem()
        {
            double x;
            tessr.sozdanie();
            x = tessr.getnext();
            tessr.checkfri(2,2);
            tessr.padenie(2, 2);
            Assert.That(tessr.getchislo(1,2), Is.EqualTo(x));
        }
        [TestCase]
        public void padaem2()
        {
            double x;
            tessr.sozdanie();
            x = tessr.getnext();
            var exception = Assert.Throws<IndexOutOfRangeException>(() => tessr.checkfri(99,99));
            // сравнение полученного сообщения с ожидаемым
            Assert.That(exception.Message, Is.EqualTo("Индекс находился вне границ массива."));
        }
        [TestCase]
        public void styajk3a()
        {
            tessr.sozdanie();
            tessr.zadamnext(16);
            tessr.checkfri(2, 2);
            tessr.padenie(2, 2);
            tessr.checkfri(3, 2);
            tessr.padenie(3, 2);
            Assert.That(tessr.getchislo(1, 2), Is.EqualTo(32));
        }
        [TestCase]
        public void styajk3a2()
        {
            tessr.sozdanie();
            tessr.zadamnext(2147483647);
            tessr.checkfri(2, 2);
            tessr.padenie(2, 2);
            tessr.checkfri(3, 2);
            tessr.padenie(3, 2);
            Assert.That(tessr.getchislo(1, 2), Is.EqualTo(2147483647));
        }
    }
}
