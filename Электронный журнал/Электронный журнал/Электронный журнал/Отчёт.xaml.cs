using System;
using System.Data.SqlClient;
using System.Windows;
namespace Project_Zero
{
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
        }
        private void Report_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-8FRQK4J\\SQLEXPRESS;Initial Catalog=Электронный_журнал;Integrated Security=True";
                SqlConnection connect = new SqlConnection(connectionString);
                connect.Open();
                string a = Subject.Text;
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Оценка", connect);
                double b = Convert.ToDouble(command.ExecuteScalar());
                double c = 0, d = 0;
                for (int i = 1; i <= b; i++)
                {
                    string sql = $"SELECT CASE WHEN EXISTS(SELECT {a} FROM Оценка WHERE {a}>-1 AND ID_оценки=\'{i}\') THEN 1 ELSE 0 END";
                    SqlCommand cmd = new SqlCommand(sql, connect);
                    var f = cmd.ExecuteScalar();
                    if (f.ToString() == "1")
                    {
                        cmd = new SqlCommand($"SELECT {a} FROM Оценка WHERE ID_оценки=\'{i}\' ", connect);
                        d = Convert.ToDouble(cmd.ExecuteScalar());
                        c += d;
                    }
                }
                command = new SqlCommand($"SELECT COUNT(*) FROM Оценка  WHERE {a}>-1", connect);
                b = Convert.ToDouble(command.ExecuteScalar());
                if (b > 0)
                {
                    MessageBox.Show($"Предмет: {a}, количество оценок: {b}, средний балл: {c / b} .");
                }
                else
                {
                    MessageBox.Show($"Предмет: {a}, количество оценок: - , средний балл: - .");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
