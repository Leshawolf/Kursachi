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
using System.IO;
namespace Железнодорожные_переезды
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Login;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Выход_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Войти_Click(object sender, RoutedEventArgs e)
        {
            if (Check_password())
            {
                UsersWindow a = new UsersWindow(Login);
                a.Show();
            }
            else
                MessageBox.Show("Не правильно введён логин или пароль!", "Ошибка!");
        }
        private void Зарегистрироваться_Click(object sender, RoutedEventArgs e)
        {
            WriteLogin();
            WritePassword();
            UsersWindow a = new UsersWindow(Login);
            a.Show();
        }
        private void Нет_аккаунта_Click(object sender, RoutedEventArgs e)
        {
            Авторизация.Visibility = Visibility.Hidden;
            Регистрация.Visibility = Visibility.Visible;
            Нет_аккаунта.Visibility = Visibility.Hidden;
            Есть_аккаунт.Visibility = Visibility.Visible;
            Зарегистрироваться.Visibility = Visibility.Visible;
            Войти.Visibility = Visibility.Hidden;
        }
        private void Режим_администратора1_Click(object sender, RoutedEventArgs e)
        {
            Войти_как_администратор.Visibility = Visibility.Visible;
            Режим_администратора2.Visibility = Visibility.Visible;
            Пароль_администратора.Visibility = Visibility.Visible;
        }
        private void Войти_как_администратор_Click(object sender, RoutedEventArgs e)
        {
            string a = Режим_администратора2.Text;
            if (a == "admin")
            {
                AdminWindow b = new AdminWindow();
                b.Show();
            }
            else
            {
                MessageBox.Show("Пароль администратора введён неккоректно!");
                Войти_как_администратор.Visibility = Visibility.Hidden;
                Режим_администратора2.Visibility = Visibility.Hidden;
                Пароль_администратора.Visibility = Visibility.Hidden;
                a = "";
            }
        }
        private void Есть_аккаунт_Click(object sender, RoutedEventArgs e)
        {
            Авторизация.Visibility = Visibility.Visible;
            Регистрация.Visibility = Visibility.Hidden;
            Нет_аккаунта.Visibility = Visibility.Visible;
            Есть_аккаунт.Visibility = Visibility.Hidden;
            Зарегистрироваться.Visibility = Visibility.Hidden;
            Войти.Visibility = Visibility.Visible;
        }
        private void WriteLogin()
        {
            string writePath = @"C:\Users\Notebook\Desktop\Колледж\3 курс\КПиЯП\Курсовой проект\Железнодорожные переезды\Login.txt";
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                sw.WriteLine(Логин2.Text);
            Login = Логин2.Text;
        }
        private void WritePassword()
        {
            string writePath = @"C:\Users\Notebook\Desktop\Колледж\3 курс\КПиЯП\Курсовой проект\Железнодорожные переезды\Password.txt";
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                sw.WriteLine(Пароль2.Text);
        }
        private bool Check_password()
        {
            string a = Логин2.Text;
            Login = a;
            string b = Пароль2.Text;
            int count = 0, i = 0;
            string pathl = @"C:\Users\Notebook\Desktop\Колледж\3 курс\КПиЯП\Курсовой проект\Железнодорожные переезды\Login.txt";
            StreamReader sr = new StreamReader(pathl, System.Text.Encoding.Default);
            string line;
            while ((line = sr.ReadLine()) != null)
                count++;
            string[] login = new string[count];
            string[] password = new string[count];
            StreamReader l = new StreamReader(pathl, System.Text.Encoding.Default);
            while ((line = l.ReadLine()) != null)
            {
                login[i] = line;
                i++;
            }
            i = 0;
            string path = @"C:\Users\Notebook\Desktop\Колледж\3 курс\КПиЯП\Курсовой проект\Железнодорожные переезды\Password.txt";
            StreamReader p = new StreamReader(path, System.Text.Encoding.Default);
            while ((line = p.ReadLine()) != null)
            {
                password[i] = line;
                i++;
            }
            int c = 0;
            for (int j = 0; j < count; j++)
            {
                if (a == login[j])
                {
                    c = j;
                    break;
                }
                if (login[count - 1] != a)
                {

                    return false;
                }
            }
            if (password[c] == b)
                return true;
            else
                return false;
        }
    }
}
