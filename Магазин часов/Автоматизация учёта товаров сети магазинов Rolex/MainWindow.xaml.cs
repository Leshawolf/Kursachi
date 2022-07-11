using System;
using System.Windows;
using System.Data.SqlClient;
namespace Автоматизация_учёта_товаров_сети_магазинов_Rolex
{
    public partial class MainWindow : Window
    {
        int a1;
        public MainWindow()
        {
            InitializeComponent();
            Тип_аккаунта.SelectedIndex = 0;
            Тип_аккаунта.Items.Add("Аккаунт работника");
            Тип_аккаунта.Items.Add("Аккаунт покупателя");
        }
        private void Войти_Click(object sender, RoutedEventArgs e)
        {
            string a = Логин2.Text;
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-8FRQK4J\SQLEXPRESS; Initial Catalog=Интернет_магазин; Integrated Security=True");
            switch(a1)
            { 
                case 1:
                {
                    string cmd1 = $"SELECT Пароль FROM Сотрудники WHERE Логин = '{a}'";
                    string cmd2 = $"SELECT ФИО FROM Сотрудники WHERE Логин = '{a}'";
                    connection.Open();
                    SqlCommand command1 = new SqlCommand(cmd1, connection);
                    SqlDataReader reader1 = command1.ExecuteReader();
                    object b = null;
                    if (reader1.HasRows)
                        while (reader1.Read())
                            b = reader1.GetValue(0);
                    reader1.Close();
                    SqlCommand command2 = new SqlCommand(cmd2, connection);
                    SqlDataReader reader2 = command2.ExecuteReader();
                    object c = null;
                    if (reader2.HasRows)
                        while (reader2.Read())
                            c = reader2.GetValue(0);
                    reader2.Close();
                    if (b == null)
                        MessageBox.Show("Логин не найден!");
                    else if (Check_password(b.ToString()))
                    {
                        Окно_работника h = new Окно_работника(Convert.ToString(c));
                        h.Show();
                        this.Close();
                    }
                    break;
                }
                case 2:
                {      
                    string cmd1 = $"SELECT Пароль FROM Покупатели WHERE Логин = '{a}'";
                    string cmd2 = $"SELECT ID_покупателя FROM Покупатели WHERE Логин = '{a}'";
                    connection.Open();
                    SqlCommand command1 = new SqlCommand(cmd1, connection);
                    SqlDataReader reader1 = command1.ExecuteReader();
                    object b = null;
                    if (reader1.HasRows)
                        while (reader1.Read())
                            b = reader1.GetValue(0);
                    reader1.Close();
                    SqlCommand command2 = new SqlCommand(cmd2, connection);
                    SqlDataReader reader2 = command2.ExecuteReader();
                    object c = null;
                    if (reader2.HasRows)
                        while (reader2.Read())
                            c = reader2.GetValue(0);
                    reader2.Close();
                    if (b == null)
                        MessageBox.Show("Логин не найден!");
                    else if (Check_password(b.ToString()))
                    {
                        Окно_клиента h = new Окно_клиента(Convert.ToInt32(c));
                        h.Show();
                        this.Close();
                    }
                    break;
                }
            }
        }
        private void Выход_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private bool Check_password(string b)
        {
            if (b.ToString() == Пароль2.Password)
                return true;
            else
            {
                MessageBox.Show("Не правильно введён пароль!");
                return false;
            }
        }
        private void Регистрация_Click(object sender, RoutedEventArgs e)
        {
            Изменение_клиента h = new Изменение_клиента(1,0);
            h.Show();
        }
        private void Тип_аккаунта_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (Тип_аккаунта.SelectedIndex == 0)
            {
                a1 = 1;
                Регистрация.Visibility = Visibility.Hidden;
            }
            else
            {
                a1 = 2;
                Регистрация.Visibility = Visibility.Visible;
            }
        }
    }
}