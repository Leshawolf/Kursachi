using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Windows;
namespace Project_Zero
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Come_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string a = Login.Text;
                string b = Date.Text;
                string connectionString = "Data Source=DESKTOP-8FRQK4J\\SQLEXPRESS;Initial Catalog=Электронный_журнал;Integrated Security=True";
                SqlConnection connect = new SqlConnection(connectionString);
                connect.Open();
                SqlCommand cmd = new SqlCommand($"SELECT CASE WHEN EXISTS(SELECT * FROM Пользователь WHERE Логин=\'{a}\' AND Дата_рождения=\'{b}\') THEN 1 ELSE 0 END", connect);
                var c = cmd.ExecuteScalar();
                string d = c.ToString();
                if (d == "1")
                {
                    string f = "";
                    var rand = new Random();
                    int y;
                    for (int i = 0; i < 24; i++)
                    {
                        y = rand.Next(1, 3);
                        if (y == 1)
                        {
                            f += Convert.ToChar(rand.Next(97, 124));
                        }
                        else
                        {
                            f += rand.Next(1, 10);
                        }
                    }
                    int rows = cmd.ExecuteNonQuery();
                    connect.Close();
                    Unilife h = new Unilife(a);
                    h.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
