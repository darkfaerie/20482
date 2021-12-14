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

namespace _2048
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public string PCname
        {
            get { return (string)GetValue(LoginProperty); }
            set { SetValue(LoginProperty, value); }
        }
        public string dann
        {
            get { return (string)GetValue(scoreProperty); }
            set { SetValue(scoreProperty, value); }
        }
        public ImageSource pic
        {
            get { return (ImageSource)GetValue(PCPicProperty); }
            set { SetValue(PCPicProperty, value); }
        }

        public UserControl1()
        {
            InitializeComponent();
        }

        private static void NameChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var loginForm = obj as UserControl1;
            loginForm.nick.Content = loginForm.PCname;
        }
        private static void danChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var loginForm = obj as UserControl1;
            loginForm.score.Content = loginForm.dann;
        }
        private static void PicChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var loginForm = obj as UserControl1;
            loginForm.ava.Source = loginForm.pic;
        }
        public static readonly DependencyProperty LoginProperty = DependencyProperty.Register(
"nick", // имя параметра в разметке
typeof(string), // тип данных параметра
typeof(UserControl1), // тип данных элемента управления
new PropertyMetadata(string.Empty, NameChanged));
        public static readonly DependencyProperty scoreProperty = DependencyProperty.Register(
"score", // имя параметра в разметке
typeof(string), // тип данных параметра
typeof(UserControl1), // тип данных элемента управления
new PropertyMetadata(string.Empty, danChanged));
        public static readonly DependencyProperty PCPicProperty = DependencyProperty.Register(
"ava", // имя параметра в разметке
typeof(ImageSource), // тип данных параметра
typeof(UserControl1), // тип данных элемента управления
new PropertyMetadata(null, PicChanged));
    }
}
