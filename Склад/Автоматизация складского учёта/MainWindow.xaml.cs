using System;
using System.Windows;
using System.Data.SqlClient;
namespace Автоматизация_складского_учёта
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Войти_Click(object sender, RoutedEventArgs e)
        {
            string a = Логин2.Text;
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-8FRQK4J\SQLEXPRESS; Initial Catalog=Склад; Integrated Security=True");
            string cmd1 = $"SELECT Пароль FROM Работники  WHERE Логин = '{a}'";
            string cmd2 = $"SELECT Должность FROM Работники WHERE Логин = '{a}'";
            string cmd3 = $"SELECT ID_работника FROM Работники WHERE Логин = '{a}'";
            string cmd4 = $"SELECT ФИО FROM Работники WHERE Логин = '{a}'";
            connection.Open();
            SqlCommand command1 = new SqlCommand(cmd1, connection);
            SqlCommand command2 = new SqlCommand(cmd2, connection);
            SqlCommand command3 = new SqlCommand(cmd3, connection);
            SqlCommand command4 = new SqlCommand(cmd4, connection);
            SqlDataReader reader1 = command1.ExecuteReader();
            object c = null;
            if (reader1.HasRows)
                while (reader1.Read())
                    c = reader1.GetValue(0);
            reader1.Close();
            SqlDataReader reader2 = command2.ExecuteReader();
            object d = null;
            if (reader2.HasRows)
                while (reader2.Read())
                    d = reader2.GetValue(0);
            reader2.Close();
            SqlDataReader reader3 = command3.ExecuteReader();
            object f = null;
            if (reader3.HasRows)
                while (reader3.Read())
                    f = reader3.GetValue(0);
            reader3.Close();
            SqlDataReader reader4 = command4.ExecuteReader();
            object g = null;
            if (reader4.HasRows)
                while (reader4.Read())
                    g = reader4.GetValue(0);
            reader4.Close();
            if (c == null)
                MessageBox.Show("Логин не найден!");
            else if (Check_password(c.ToString()))
            {
                UserWindow h = new UserWindow(d.ToString(), Convert.ToInt32(f), Convert.ToString(g));
                h.Show();
                this.Close();
            }
        }
        private void Выход_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private bool Check_password(string c)
        {
            if (c.ToString() == Пароль2.Password)
                return true;
            else
            {
                MessageBox.Show("Не правильно введён пароль!");
                return false;
            }
        }
    }
}