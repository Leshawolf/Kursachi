using System;
using System.Data.SqlClient;
using System.Windows;
namespace Project_Zero
{
    public partial class Window3 : Window
    {
        string a;
        string connectionString = "Data Source=DESKTOP-8FRQK4J\\SQLEXPRESS;Initial Catalog=Электронный_журнал;Integrated Security=True";
        DataClasses1DataContext data = new DataClasses1DataContext(Properties.Settings.Default.Электронный_журналConnectionString);
        public Window3(string b)
        {
            a = b;
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Student.ItemsSource = data.ExecuteQuery<string>($"SELECT ФИО FROM Пользователь WHERE Статус = 'Студент'");
        }
        private void Student_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string z = Student.Text;
            SqlConnection connect = new SqlConnection(connectionString);
            connect.Open();
            string sql = $"SELECT ID_пользователя FROM Пользователь WHERE ФИО=\'{z}\' ";
            SqlCommand command = new SqlCommand(sql, connect);
            int i = Convert.ToInt32(command.ExecuteScalar());
            Date.ItemsSource = data.ExecuteQuery<DateTime>($"SELECT Дата_оценки FROM Оценка WHERE ID_пользователя = 2 ");
            Date.IsEnabled = true;
            connect.Close();
        }
        private void Alter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection connect = new SqlConnection(connectionString);
                connect.Open();
                string c = Date.Text;
                string d = Subject.Text;
                string f = Mark.Text;
                if (f == "")
                {
                    using (SqlCommand cmd = new SqlCommand($"UPDATE Оценка SET {d}=null WHERE Дата_оценки=@Дата_оценки", connect))
                    {
                        cmd.Parameters.AddWithValue("@ОП", f);
                        cmd.Parameters.AddWithValue("@Дата_оценки", c);
                        int rows = cmd.ExecuteNonQuery();
                        Unilife g = new Unilife(a);
                        g.Show();
                        this.Close();
                    }
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand($"UPDATE Оценка SET {d}=@ОП WHERE Дата_оценки=@Дата_оценки", connect))
                    {
                        cmd.Parameters.AddWithValue("@ОП", f);
                        cmd.Parameters.AddWithValue("@Дата_оценки", c);
                        int rows = cmd.ExecuteNonQuery();
                        Unilife Kod = new Unilife(a);
                        Kod.Show();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
