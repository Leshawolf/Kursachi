using System;
using System.Data.SqlClient;
using System.Windows;
namespace Project_Zero
{
    public partial class Window1 : Window
    {
        string a;
        DataClasses1DataContext data = new DataClasses1DataContext(Properties.Settings.Default.Электронный_журналConnectionString);
        public Window1(string b)
        {
            a = b;
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Student.ItemsSource = data.ExecuteQuery<string>($"SELECT ФИО FROM Пользователь WHERE Статус = 'Студент'");
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-8FRQK4J\\SQLEXPRESS;Initial Catalog=Электронный_журнал;Integrated Security=True";
                SqlConnection connect = new SqlConnection(connectionString);
                connect.Open();
                string c = Date.Text;
                string h = Student.Text;
                string sql = $"SELECT CASE WHEN EXISTS(SELECT * FROM Оценка WHERE Дата_оценки=\'{c}\') THEN 1 ELSE 0 END";
                SqlCommand command = new SqlCommand(sql, connect);
                var d = command.ExecuteScalar();
                string f = d.ToString();
                command = new SqlCommand($"SELECT ID_пользователя FROM Пользователь WHERE ФИО=\'{h}\' ", connect);
                int i = Convert.ToInt32(command.ExecuteScalar());
                if (f == "0")
                {
                    sql = "SELECT COUNT(*) FROM Оценка ";
                    command = new SqlCommand(sql, connect);
                    int output = Convert.ToInt32(command.ExecuteScalar()) + 1;
                    sql = $"INSERT Оценка(Дата_оценки, ID_пользователя) VALUES('{c}', {i})";
                    command = new SqlCommand(sql, connect);
                    int rows = command.ExecuteNonQuery();
                    Unilife g = new Unilife(a);
                    g.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Данная дата уже есть. Выберите другую");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}