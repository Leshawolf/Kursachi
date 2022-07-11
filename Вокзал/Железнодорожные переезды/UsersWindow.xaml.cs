using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
namespace Железнодорожные_переезды
{
    struct Рейс
    {
        static public int Номер_билета;
        static public int Номер_маршрута;
        static public string Место_отправления;
        static public string Место_прибытия;
        static public DateTime? Дата_отправления;
        static public int Номер_места;
    }
    struct Пассажир1
    {
        static public string Номер_паспорта;
        static public string ФИО;
        static public int Возраст;
    }
    public partial class UsersWindow : Window
    {
        public string login;
        public UsersWindow(string a)
        {
            InitializeComponent();
            login = a;
        }
        DataClasses1DataContext data = new DataClasses1DataContext(Properties.Settings.Default.АвтовокзалConnectionString);
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Привет.Content = ("Привет, "  +login + "!");
            Выберите_маршрут2.ItemsSource = data.ExecuteQuery<string>($"SELECT Путь FROM Маршрут");
            Выберите_город_выезда2.ItemsSource = data.ExecuteQuery<string>($"SELECT DISTINCT Город FROM Вокзал");
            Выберите_вокзал_выезда2.ItemsSource = data.ExecuteQuery<string>($"SELECT Название Город FROM Вокзал");
            Выберите_город_приезда2.ItemsSource = data.ExecuteQuery<string>($"SELECT DISTINCT Город FROM Вокзал");
            Выберите_вокзал_приезда2.ItemsSource = data.ExecuteQuery<string>($"SELECT Название Город FROM Вокзал");
            Информация.ItemsSource = data.ExecuteQuery<Билет>($"SELECT * FROM Билет");
            Рейс.Номер_билета = data.ExecuteQuery<Билет>($"SELECT * FROM Билет").Count();
        }
        private void Выберите_маршрут2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Рейс.Номер_маршрута = Convert.ToInt32(Выберите_маршрут2.SelectedIndex) + 1;
        }
        private void Выберите_город_выезда2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Выберите_вокзал_выезда2.IsEnabled = true;
            Рейс.Место_отправления = Convert.ToString(Выберите_город_выезда2.SelectedItem);
            Выберите_вокзал_выезда2.ItemsSource = data.ExecuteQuery<string>($"SELECT Название FROM Вокзал WHERE Город = '{Рейс.Место_отправления}'");
        }
        private void Выберите_город_приезда2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Выберите_вокзал_приезда2.IsEnabled = true;
            Рейс.Место_прибытия = Convert.ToString(Выберите_город_приезда2.SelectedItem);
            Выберите_вокзал_приезда2.ItemsSource = data.ExecuteQuery<string>($"SELECT Название FROM Вокзал WHERE Город = '{Рейс.Место_прибытия}'");
        }
        private void Выберите_вокзал_выезда2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string b = Convert.ToString(Выберите_вокзал_выезда2.SelectedItem);
            Рейс.Место_отправления += '-' + b;
        }
        private void Выберите_вокзал_приезда2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string b = Convert.ToString(Выберите_вокзал_приезда2.SelectedItem);
            Рейс.Место_прибытия += '-' + b;
        }
        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            Рейс.Дата_отправления = Дата_отправления.SelectedDate;
        }
        private void Добавить1_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Введите_ФИО2.Text))
            {
                Пассажир1.ФИО = Введите_ФИО2.Text;
                if (!string.IsNullOrEmpty(Введите_идентификационный_номер_паспорта2.Text))
                {
                    Пассажир1.Номер_паспорта = Введите_идентификационный_номер_паспорта2.Text;
                    if (!string.IsNullOrEmpty(Введите_ваш_возраст2.Text))
                    {
                        Пассажир1.Возраст = Convert.ToInt32(Введите_ваш_возраст2.Text);
                        if (Рейс.Номер_маршрута == 0)
                            MessageBox.Show("Вы не выбрали номер маршрута!");
                        else
                                if (Выберите_вокзал_выезда2.SelectedIndex == -1)
                            MessageBox.Show("Вы не выбрали место отправления");
                        else
                                            if (Выберите_вокзал_приезда2.SelectedIndex == -1)
                            MessageBox.Show("Вы не выбрали место прибытия");
                        else
                                                        if (Рейс.Дата_отправления == null)
                            MessageBox.Show("Вы не выбрали дату");
                        else
                        {
                            data.ExecuteQuery<string>($"INSERT INTO Билет(ФИО_Пассажира, Номер_Маршрута, Место_Отправления, Место_Прибытия, Дата_Отправления, Номер_места) VALUES ('{Пассажир1.ФИО}', {Рейс.Номер_маршрута}, '{Рейс.Место_отправления}', '{Рейс.Место_прибытия}', '{Рейс.Дата_отправления}', {Рейс.Номер_места})");
                            Информация.ItemsSource = data.ExecuteQuery<Билет>($"SELECT * FROM Билет");
                        }
                    }
                    else
                        MessageBox.Show("Вы не ввели возраст!");
                }
                else
                    MessageBox.Show("Вы не ввели идентификационный номер паспорта!");
            }
            else
                MessageBox.Show("Вы не ввели ФИО!");
            Введите_ваш_возраст2.Text = "";
            Введите_ФИО2.Text = "";
            Введите_идентификационный_номер_паспорта2.Text = "";
        }
    }
}