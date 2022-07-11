using System.Windows;
using System.Linq;
namespace Автоматизация_учёта_товаров_сети_магазинов_Rolex
{
    public partial class Изменение_клиента : Window
    {
        dataDataContext data = new dataDataContext(Properties.Settings.Default.Интернет_магазинConnectionString);
        int y;
        public Изменение_клиента(int a, int b)
        {
            InitializeComponent();
            y = b;
            if (a == 1)
            {
                Сохранить.Visibility = Visibility.Visible;
                Изменить.Visibility = Visibility.Hidden;
            }
            else
            {
                Сохранить.Visibility = Visibility.Hidden;
                Изменить.Visibility = Visibility.Visible;
                ФИО2.Text = data.ExecuteQuery<string>($"SELECT ФИО FROM Покупатели").ElementAt(b - 2);
                Адрес2.Text = data.ExecuteQuery<string>($"SELECT Адрес FROM Покупатели").ElementAt(b - 2);
                Телефон2.Text = data.ExecuteQuery<string>($"SELECT Контактный_телефон FROM Покупатели").ElementAt(b - 2);
                Электронный_адрес2.Text = data.ExecuteQuery<string>($"SELECT Электронный_адрес FROM Покупатели").ElementAt(b - 2);
                Логин2.Text = data.ExecuteQuery<string>($"SELECT Логин FROM Покупатели").ElementAt(b - 2);
                Пароль2.Text = data.ExecuteQuery<string>($"SELECT Пароль FROM Покупатели").ElementAt(b - 2);
            }
        }
        private void Сохранить_Click(object sender, RoutedEventArgs e)
        {
            int a = data.ExecuteQuery<int>("SELECT * FROM Товары").Count() + 1;
            string b = ФИО2.Text;
            string c = Адрес2.Text;
            string d = Телефон2.Text;
            string f = Электронный_адрес2.Text;
            string g = Логин2.Text;
            string h = Пароль2.Text;
            if (ФИО2.Text == "")
                MessageBox.Show("Вы не ввели ФИО!");
            else
            {
                if (Адрес2.Text == "")
                    MessageBox.Show("Вы не ввели адрес!");
                else 
                {
                    if (Электронный_адрес2.Text == "")
                        MessageBox.Show("Вы не ввели электронный адрес!");
                    else
                    {
                        if (Логин2.Text == "")
                            MessageBox.Show("Вы не ввели логин!");
                        else
                        {
                            if (Пароль2.Text == "")
                                MessageBox.Show("Вы не ввели пароль!");
                            else 
                            {
                                data.ExecuteQuery<string>($"INSERT INTO Покупатели(ID_покупателя, ФИО, Адрес, Контактный_телефон, Электронный_адрес, Логин, Пароль) values({a}, '{b}', '{c}', '{d}', '{f}', '{g}', '{h}')");
                                MessageBox.Show("Элемент успешно добавлен!");
                                this.Close();
                            }
                        }
                    }
                
                }
            }
        }
        private void Изменить_Click(object sender, RoutedEventArgs e)
        {
            string b = ФИО2.Text;
            string c = Адрес2.Text;
            string d = Телефон2.Text;
            string f = Электронный_адрес2.Text;
            string g = Логин2.Text;
            string h = Пароль2.Text;
            if (ФИО2.Text == "")
                MessageBox.Show("Вы не ввели ФИО!");
            else
            {
                if (Адрес2.Text == "")
                    MessageBox.Show("Вы не ввели адрес!");
                else
                {
                    if (Электронный_адрес2.Text == "")
                        MessageBox.Show("Вы не ввели электронный адрес!");
                    else
                    {
                        if (Логин2.Text == "")
                            MessageBox.Show("Вы не ввели логин!");
                        else
                        {
                            if (Пароль2.Text == "")
                                MessageBox.Show("Вы не ввели пароль!");
                            else
                            {
                                data.ExecuteQuery<string>($"UPDATE Покупатели SET ФИО = '{b}' WHERE ID_покупателя = {y-1}");
                                data.ExecuteQuery<string>($"UPDATE Покупатели SET Адрес = '{c}' WHERE ID_покупателя = {y-1}");
                                data.ExecuteQuery<string>($"UPDATE Покупатели SET Контактный_телефон = '{d}' WHERE ID_покупателя = {y-1}");
                                data.ExecuteQuery<string>($"UPDATE Покупатели SET Электронный_адрес = '{f}' WHERE ID_покупателя = {y-1}");
                                data.ExecuteQuery<string>($"UPDATE Покупатели SET Логин = '{g}' WHERE ID_покупателя = {y-1}");
                                data.ExecuteQuery<string>($"UPDATE Покупатели SET Пароль = '{h}' WHERE ID_покупателя = {y-1}");
                                MessageBox.Show("Элемент успешно изменёнен!");
                                this.Close();
                            }
                        }
                    }

                }
            }
        }
        private void Отмена_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
