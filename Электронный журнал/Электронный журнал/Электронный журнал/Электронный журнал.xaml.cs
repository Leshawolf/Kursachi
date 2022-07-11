using System;
using System.Data.SqlClient;
using System.Windows;
namespace Project_Zero
{
    public partial class Unilife : Window
    {
        string a;
        DataClasses1DataContext data = new DataClasses1DataContext(Properties.Settings.Default.Электронный_журналConnectionString);
        public Unilife(string b)
        {
            a = b;
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Hello.Content += a;
                Add_date.Visibility = Visibility.Collapsed;
                Delete_date.Visibility = Visibility.Collapsed;
                Add_alter_mark.Visibility = Visibility.Collapsed;
                Report.Visibility = Visibility.Visible;
                string connectionString = "Data Source=DESKTOP-8FRQK4J\\SQLEXPRESS;Initial Catalog=Электронный_журнал;Integrated Security=True";
                SqlConnection connect = new SqlConnection(connectionString);
                connect.Open();
                SqlCommand command = new SqlCommand($"SELECT Статус FROM Пользователь WHERE Логин =\'{a}\'", connect);
                string c = Convert.ToString(command.ExecuteScalar());
                if (c == "Админ")
                {
                    Grid.ItemsSource = data.ExecuteQuery<Оценка>($"SELECT * FROM Оценка");
                    Add_date.Visibility = Visibility.Visible;
                    Delete_date.Visibility = Visibility.Visible;
                    Add_alter_mark.Visibility = Visibility.Visible;
                    Report.Visibility = Visibility.Collapsed;
                }
                else
                {
                    command = new SqlCommand($"SELECT ID_пользователя FROM Пользователь WHERE Логин=\'{a}\' ", connect);
                    int i = Convert.ToInt32(command.ExecuteScalar());
                    Grid.ItemsSource = data.ExecuteQuery<Оценка>($"SELECT * FROM Оценка WHERE ID_пользователя = {i}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Add_date_Click(object sender, RoutedEventArgs e)
        {
            Window1 f = new Window1(a);
            f.Show();
            this.Close();
        }
        private void Delete_date_Click(object sender, RoutedEventArgs e)
        {
            Window2 f = new Window2(a);
            f.Show();
            this.Close();
        }
        private void Add_alter_mark_Click(object sender, RoutedEventArgs e)
        {
            Window3 f = new Window3(a);
            f.Show();
            this.Close();
        }
        private void Report_Click(object sender, RoutedEventArgs e)
        {
            Window4 f = new Window4();
            f.Show();
        }
    }
}
