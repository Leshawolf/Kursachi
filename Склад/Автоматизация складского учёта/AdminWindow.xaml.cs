using System;
using System.Windows;
using System.Linq;
namespace Автоматизация_складского_учёта
{
    public partial class AdminWindow : Window
    {
        WarehouseDataContext data = new WarehouseDataContext(Properties.Settings.Default.СкладConnectionString);
        int a;
        int x;
        public AdminWindow()
        {
            InitializeComponent();
            hidden1();
            hidden2();
            hidden3();
        }
        private void Добавить_поставщика_Click(object sender, RoutedEventArgs e)
        {
            hidden1();
            visible1();
            hidden2();
            hidden3();
            Сохранить.Visibility = Visibility.Visible;
            Отмена.Visibility = Visibility.Visible;
            a = 1;
        }
        private void Изменить_поставщика_Click(object sender, RoutedEventArgs e)
        {
            hidden1();
            hidden2();
            Выберите_наименование1.Visibility = Visibility.Visible;
            Выберите_наименование1.Content = "Выберите поставщика";
            Выберите_наименование2.Visibility = Visibility.Visible;
            Отмена.Visibility = Visibility.Visible;
            Выберите_наименование2.ItemsSource = data.ExecuteQuery<string>($"SELECT Наименование FROM Поставщики");
            a = 2;
        }
        private void Удалить_поставщика_Click(object sender, RoutedEventArgs e)
        {
            hidden1();
            hidden2();
            Отмена.Visibility = Visibility.Visible;
            Выберите_наименование1.Content = "Выберите поставщика";
            Выберите_наименование2.Visibility = Visibility.Visible;
            Выберите_наименование2.ItemsSource = data.ExecuteQuery<string>($"SELECT Наименование FROM Поставщики");
            Сохранить.Content = "Удалить";
            a = 3;
        }
        private void Добавить_заказчика_Click(object sender, RoutedEventArgs e)
        {
            hidden1();
            visible1();
            hidden2();
            hidden3();
            Сохранить.Visibility = Visibility.Visible;
            Отмена.Visibility = Visibility.Visible;
            a = 4;
        }
        private void Изменить_заказчика_Click(object sender, RoutedEventArgs e)
        {
            hidden1();
            hidden2();
            Выберите_наименование1.Visibility = Visibility.Visible;
            Выберите_наименование1.Content = "Выберите заказчика";
            Выберите_наименование2.Visibility = Visibility.Visible;
            Выберите_наименование2.Visibility = Visibility.Visible;
            Выберите_наименование2.ItemsSource = data.ExecuteQuery<string>($"SELECT Наименование FROM Заказчики");
            Отмена.Visibility = Visibility.Visible;
            a = 5;
        }
        private void Удалить_заказчика_Click(object sender, RoutedEventArgs e)
        {
            hidden1();
            hidden2();
            Отмена.Visibility = Visibility.Visible;
            Выберите_наименование1.Content = "Выберите заказчика";
            Выберите_наименование2.Visibility = Visibility.Visible;
            Выберите_наименование2.ItemsSource = data.ExecuteQuery<string>($"SELECT Наименование FROM Заказчики");
            Сохранить.Content = "Удалить";
            Отмена.Visibility = Visibility.Visible;
            a = 6;
        }
        private void Добавить_работника_Click(object sender, RoutedEventArgs e)
        {
            visible1();
            visible2();
            Отмена.Visibility = Visibility.Visible;
            a = 7;
        }
        private void Изменить_работника_Click(object sender, RoutedEventArgs e)
        {
            visible1();
            visible2();
            Отмена.Visibility = Visibility.Visible;
            Выберите_наименование2.Visibility = Visibility.Visible;
            Выберите_наименование2.ItemsSource = data.ExecuteQuery<string>($"SELECT ФИО FROM Работники");
            a = 8;
        }
        private void Удалить_работника_Click(object sender, RoutedEventArgs e)
        {
            hidden1();
            hidden2();
            Выберите_наименование1.Content = "Выберите работника";
            Выберите_наименование2.Visibility = Visibility.Visible;
            Выберите_наименование2.ItemsSource = data.ExecuteQuery<string>($"SELECT ФИО FROM Работники");
            Сохранить.Content = "Удалить";
            Отмена.Visibility = Visibility.Visible;
            a = 9;
        }
        private void Выберите_наименование2_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Сохранить.Visibility = Visibility.Hidden;
            Сохранить.Visibility = Visibility.Visible;
            int b = Выберите_наименование2.SelectedIndex;
            string c;
            switch (a)
            {
                case 2:
                    visible1();
                    c = data.ExecuteQuery<string>($"SELECT Наименование FROM Поставщики").ElementAt(b);
                    Введите_наименование2.Text = c;
                    c = data.ExecuteQuery<string>($"SELECT Телефон FROM Поставщики").ElementAt(b);
                    Введите_телефон2.Text = c;
                    c = data.ExecuteQuery<string>($"SELECT Адрес FROM Поставщики").ElementAt(b);
                    Введите_адрес2.Text = c;
                    c = data.ExecuteQuery<string>($"SELECT Электронный_адрес FROM Поставщики").ElementAt(b);
                    Введите_электронный_адрес2.Text = c;
                    x = b + 1;
                    break;
                case 5:
                    visible1();
                    c = data.ExecuteQuery<string>($"SELECT Наименование FROM Заказчики").ElementAt(b);
                    Введите_наименование2.Text = c;
                    c = data.ExecuteQuery<string>($"SELECT Телефон FROM Заказчики").ElementAt(b);
                    Введите_телефон2.Text = c;
                    c = data.ExecuteQuery<string>($"SELECT Адрес FROM Заказчики").ElementAt(b);
                    Введите_адрес2.Text = c;
                    c = data.ExecuteQuery<string>($"SELECT Электронный_адрес FROM Заказчики").ElementAt(b);
                    Введите_электронный_адрес2.Text = c;
                    x = b + 1;
                    break;
                case 8:
                    visible1();
                    visible2();
                    c = data.ExecuteQuery<string>($"SELECT ФИО FROM Работники").ElementAt(b);
                    Введите_наименование2.Text = c;
                    c = data.ExecuteQuery<string>($"SELECT Адрес FROM Работники").ElementAt(b);
                    Введите_адрес2.Text = c;
                    c = data.ExecuteQuery<string>($"SELECT Дата_рождения FROM Работники").ElementAt(b);
                    Введите_дату_рождения2.Text = c;
                    c = data.ExecuteQuery<string>($"SELECT Должность FROM Работники").ElementAt(b);
                    Введите_должность2.Text = c;
                    c = data.ExecuteQuery<string>($"SELECT Мобильный_Телефон FROM Работники").ElementAt(b);
                    Введите_телефон2.Text = c;
                    c = data.ExecuteQuery<string>($"SELECT Домашний_Телефон FROM Работники").ElementAt(b);
                    Введите_домашний_телефон2.Text = c;
                    c = data.ExecuteQuery<string>($"SELECT Электронный_адрес FROM Работники").ElementAt(b);
                    Введите_электронный_адрес2.Text = c;
                    x = b + 1;
                    break;
            }
        }
        private void Сохранить_Click(object sender, RoutedEventArgs e)
        {
            int b;
            string c = Введите_наименование2.Text;
            string d = Введите_телефон2.Text;
            string f = Введите_адрес2.Text;
            string g = Введите_электронный_адрес2.Text;
            string h = Введите_дату_рождения2.Text;
            string i = Введите_домашний_телефон2.Text;
            string j = Введите_должность2.Text;
            string k = Введите_логин2.Text;
            string mestext = "Подтвердить удаление записи?";
            string caption = "?";
            int z;
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;
            switch (a)
            {
                case 1:
                    Сохранить.Visibility = Visibility.Visible;
                    b = data.ExecuteQuery<int>("SELECT * FROM Поставщики").Count() + 1;
                    data.ExecuteQuery<string>($"INSERT INTO Поставщики(ID_поставщика, Наименование, Телефон, Адрес, Электронный_адрес) VALUES({b}, '{c}', '{d}', '{f}', '{g}')");
                    break;
                case 2:
                    Сохранить.Visibility = Visibility.Visible;
                    data.ExecuteQuery<string>($"UPDATE Поставщики SET Наименование = '{c}' WHERE ID_поставщика = {x}");
                    data.ExecuteQuery<string>($"UPDATE Поставщики SET Телефон = '{d}' WHERE ID_поставщика = {x}");
                    data.ExecuteQuery<string>($"UPDATE Поставщики SET Адрес = '{f}' WHERE ID_поставщика = {x}");
                    data.ExecuteQuery<string>($"UPDATE Поставщики SET Электронный_адрес = '{g}' WHERE ID_поставщика = {x}");
                    MessageBox.Show("Элемент успешно изменён!");
                    Выберите_наименование2.Visibility = Visibility.Hidden;
                    break; 
                case 3:
                    Сохранить.Visibility = Visibility.Visible;
                    z = Convert.ToInt32(Выберите_наименование2.SelectedIndex) + 1;
                    MessageBoxResult result1 = MessageBox.Show(mestext, caption, button, icon);
                    switch (result1)
                    {
                        case MessageBoxResult.Yes:
                            data.ExecuteQuery<int>($"DELETE FROM Поставщики WHERE ID_поставщика={z}");
                            break;
                        case MessageBoxResult.No:
                            break;
                    }
                    MessageBox.Show("Элемент успешно удалён!");
                    Сохранить.Content = "Сохранить";
                    Выберите_наименование1.Content = "";
                    Выберите_наименование2.Visibility = Visibility.Hidden;
                    break;
                case 4:
                    Сохранить.Visibility = Visibility.Visible;
                    b = data.ExecuteQuery<int>("SELECT * FROM Заказчики").Count() + 1;
                    data.ExecuteQuery<string>($"INSERT INTO Заказчики(ID_заказчика, Наименование, Телефон, Адрес, Электронный_адрес) VALUES({b}, '{c}', '{d}', '{f}', '{g}')");
                    break;
                case 5:
                    data.ExecuteQuery<string>($"UPDATE Заказчики SET Наименование = '{c}' WHERE ID_заказчика = {x}");
                    data.ExecuteQuery<string>($"UPDATE Заказчики SET Телефон = '{d}' WHERE ID_заказчика = {x}");
                    data.ExecuteQuery<string>($"UPDATE Заказчики SET Адрес = '{f}' WHERE ID_заказчика = {x}");
                    data.ExecuteQuery<string>($"UPDATE Заказчики SET Электронный_адрес = '{g}' WHERE ID_заказчика = {x}");
                    MessageBox.Show("Элемент успешно изменён!");
                    Выберите_наименование2.Visibility = Visibility.Hidden;
                    break;
                case 6:
                    Сохранить.Visibility = Visibility.Visible;
                    z = Convert.ToInt32(Выберите_наименование2.SelectedIndex) + 1;
                    MessageBoxResult result2 = MessageBox.Show(mestext, caption, button, icon);
                    switch (result2)
                    {
                        case MessageBoxResult.Yes:
                            data.ExecuteQuery<int>($"DELETE FROM Заказчики WHERE ID_заказчика={z}");
                            break;
                        case MessageBoxResult.No:
                            break;
                    }
                    MessageBox.Show("Элемент успешно удалён!");
                    Сохранить.Content = "Сохранить";
                    Выберите_наименование1.Content = "";
                    Выберите_наименование2.Visibility = Visibility.Hidden;
                    break;
                case 7:
                    Сохранить.Visibility = Visibility.Visible;
                    b = data.ExecuteQuery<int>("SELECT * FROM Работники").Count() + 1;
                    data.ExecuteQuery<string>($"INSERT INTO Работники(ID_работника, Логин, Пароль, ФИО, Адрес, Дата_рождения, Должность, Мобильный_телефон, Домашний_телефон, Электронный_адрес) VALUES({b}, '{k}', '{password()}' '{c}', '{f}', '{h}', '{j}', '{d}', '{i}', '{g}')");
                    break;
                case 8:
                    Сохранить.Visibility = Visibility.Visible;
                    data.ExecuteQuery<string>($"UPDATE Работники SET Логин = '{k}' WHERE ID_работника = {x}");
                    data.ExecuteQuery<string>($"UPDATE Работники SET ФИО = '{c}' WHERE ID_работника = {x}");
                    data.ExecuteQuery<string>($"UPDATE Работники SET Адрес = '{f}' WHERE ID_работника = {x}");
                    data.ExecuteQuery<string>($"UPDATE Работники SET Дата_рождения = '{h}' WHERE ID_работника = {x}");
                    data.ExecuteQuery<string>($"UPDATE Работники SET Должность = '{j}' WHERE ID_работника = {x}");
                    data.ExecuteQuery<string>($"UPDATE Работники SET Мобильный_телефон = '{d}' WHERE ID_работника = {x}");
                    data.ExecuteQuery<string>($"UPDATE Работники SET Домашний_телефон = '{i}' WHERE ID_работника = {x}");
                    data.ExecuteQuery<string>($"UPDATE Работники SET Электронный_адрес = '{g}' WHERE ID_работника = {x}");
                    MessageBox.Show("Элемент успешно изменён!");
                    Выберите_наименование2.Visibility = Visibility.Hidden;
                    break;
                case 9:
                    Сохранить.Visibility = Visibility.Visible;
                    z = Convert.ToInt32(Выберите_наименование2.SelectedIndex) + 1;
                    MessageBoxResult result3 = MessageBox.Show(mestext, caption, button, icon);
                    switch (result3)
                    {
                        case MessageBoxResult.Yes:
                            data.ExecuteQuery<int>($"DELETE FROM Работники WHERE ID_работника={z}");
                            break;
                        case MessageBoxResult.No:
                            break;
                    }
                    MessageBox.Show("Элемент успешно удалён!");
                    Сохранить.Content = "Сохранить";
                    Выберите_наименование1.Content = "";
                    Выберите_наименование2.Visibility = Visibility.Hidden;
                    break;
                default:
                    break;
            }
            hidden1();
            hidden2();
        }
        private void hidden1()
        {
            Введите_наименование1.Visibility = Visibility.Hidden;
            Введите_наименование2.Visibility = Visibility.Hidden;
            Введите_телефон1.Visibility = Visibility.Hidden;
            Введите_телефон2.Visibility = Visibility.Hidden;
            Введите_адрес1.Visibility = Visibility.Hidden;
            Введите_адрес2.Visibility = Visibility.Hidden;
            Введите_электронный_адрес1.Visibility = Visibility.Hidden;
            Введите_электронный_адрес2.Visibility = Visibility.Hidden;
            Введите_наименование2.Text = "";
            Введите_телефон2.Text = "";
            Введите_адрес2.Text = "";
            Введите_электронный_адрес2.Text = "";
            Выберите_наименование2.Visibility = Visibility.Hidden;
            Выберите_наименование2.SelectedIndex = -1;
            Сохранить.Visibility = Visibility.Hidden;
            Отмена.Visibility = Visibility.Hidden;
        }
        private void hidden2()
        {
            Выберите_наименование1.Content = "";
            Выберите_наименование2.Visibility = Visibility.Hidden;
            Введите_дату_рождения1.Visibility = Visibility.Hidden;
            Введите_дату_рождения2.Visibility = Visibility.Hidden;
            Введите_домашний_телефон1.Visibility = Visibility.Hidden;
            Введите_домашний_телефон2.Visibility = Visibility.Hidden;
            Введите_должность1.Visibility = Visibility.Hidden;
            Введите_должность2.Visibility = Visibility.Hidden;
            Введите_логин1.Visibility = Visibility.Hidden;
            Введите_логин2.Visibility = Visibility.Hidden;

            Введите_дату_рождения2.Text = "";
            Введите_домашний_телефон2.Text = "";
            Введите_должность2.Text = "";
            Введите_логин2.Text = "";
        }
        private void hidden3()
        {
            Сохранить.Content = "Сохранить";
            Сохранить.Visibility = Visibility.Hidden;
            Отмена.Visibility = Visibility.Hidden;
        }
        private void visible1()
        {
            Введите_наименование1.Visibility = Visibility.Visible;
            Введите_наименование2.Visibility = Visibility.Visible;
            Введите_телефон1.Visibility = Visibility.Visible;
            Введите_телефон2.Visibility = Visibility.Visible;
            Введите_адрес1.Visibility = Visibility.Visible;
            Введите_адрес2.Visibility = Visibility.Visible;
            Введите_электронный_адрес1.Visibility = Visibility.Visible;
            Введите_электронный_адрес2.Visibility = Visibility.Visible;
            Сохранить.Visibility = Visibility.Visible;
            Отмена.Visibility = Visibility.Visible;
        }
        private void visible2()
        {
            Введите_дату_рождения1.Visibility = Visibility.Visible;
            Введите_дату_рождения2.Visibility = Visibility.Visible;
            Введите_домашний_телефон1.Visibility = Visibility.Visible;
            Введите_домашний_телефон2.Visibility = Visibility.Visible;
            Введите_логин1.Visibility = Visibility.Visible;
            Введите_логин2.Visibility = Visibility.Visible;
            Введите_должность1.Visibility = Visibility.Visible;
            Введите_должность2.Visibility = Visibility.Visible;
        }
        private void Отмена_Click(object sender, RoutedEventArgs e)
        {
            hidden1();
            hidden2();
        }
        private string password()
        {
            string chars = "abcdefghijklnopqrstuvwxyz";
            string password = "";
            Random rand = new Random();
            for (int i = 0; i < 7; i++)
                password += chars[rand.Next(0, 25)];
            return password;
        }
    }
}