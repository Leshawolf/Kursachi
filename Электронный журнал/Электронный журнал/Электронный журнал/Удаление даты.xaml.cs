using System;
using System.Data.SqlClient;
using System.Windows;
namespace Project_Zero
{
    public partial class Window2 : Window
    {
        string a;
        DataClasses1DataContext data = new DataClasses1DataContext(Properties.Settings.Default.Электронный_журналConnectionString);
        public Window2(string b)
        {
            a = b;
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Date.ItemsSource = data.ExecuteQuery<DateTime>($"SELECT Дата_оценки FROM Оценка");
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-8FRQK4J\\SQLEXPRESS;Initial Catalog=Электронный_журнал;Integrated Security=True";
            SqlConnection connect = new SqlConnection(connectionString);
            connect.Open();
            string c = Date.Text;
            string sql = $"DELETE FROM Оценка WHERE Дата_оценки = \'{c}\'";
            SqlCommand command = new SqlCommand(sql, connect);
            int rows = command.ExecuteNonQuery();
            Unilife d = new Unilife(a);
            d.Show();
            this.Close();
        }
    }
}
