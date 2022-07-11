using System;
using System.Windows;
using System.Linq;
using System.Data.SqlClient;
namespace Автоматизация_учёта_товаров_сети_магазинов_Rolex
{
    public partial class Изменить_товар : Window
    {
        int a;
        dataDataContext data = new dataDataContext(Properties.Settings.Default.Интернет_магазинConnectionString);
        public Изменить_товар()
        {
            InitializeComponent();
            Выберите_наименование_товара2.ItemsSource = data.ExecuteQuery<string>($"SELECT Наименование FROM Товары");
            Выберите_магазин2.ItemsSource = data.ExecuteQuery<string>($"SELECT Адрес_магазина FROM Магазины");
        }
        private void Выберите_наименование_товара2_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            enabled();
            a = Convert.ToInt32(Выберите_наименование_товара2.SelectedIndex) + 1;
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-8FRQK4J\SQLEXPRESS; Initial Catalog=Интернет_магазин; Integrated Security=True");
            string cmd = $"SELECT Магазины.Адрес_магазина FROM Товары, Магазины WHERE Товары.ID_магазина = Магазины.ID_магазина and Товары.ID_товара = {a}";
            connection.Open();
            SqlCommand command = new SqlCommand(cmd, connection);
            SqlDataReader reader = command.ExecuteReader();
            object b = null;
            if (reader.HasRows)
                while (reader.Read())
                    b = reader.GetValue(0);
            reader.Close();
            connection.Close();
            string c = Convert.ToString(Выберите_наименование_товара2.SelectedItem);
            Введите_наименование_товара2.Text = c;
            Выберите_магазин2.ItemsSource = data.ExecuteQuery<string>($"SELECT Адрес_магазина FROM Магазины");
            Выберите_магазин2.SelectedItem = b.ToString();
            Отпускная_цена2.Text = Convert.ToString(data.ExecuteQuery<int>($"SELECT Отпускная_цена FROM Товары").ElementAt(a - 1));
        }
        private void Изменить_Click(object sender, RoutedEventArgs e)
        {
            if (Введите_наименование_товара2.Text == "")
                MessageBox.Show("Наименование не может быть пустым!");
            else
            {
                if (Отпускная_цена2.Text == "")
                    MessageBox.Show("Цена не может быть пустой!");
                else
                {
                    string b = Введите_наименование_товара2.Text;
                    int c = Convert.ToInt32(Выберите_магазин2.SelectedIndex) + 1;
                    int d = Convert.ToInt32(Отпускная_цена2.Text);
                    data.ExecuteQuery<string>($"UPDATE Товары SET Наименование = '{b}' WHERE ID_товара = {a}");
                    data.ExecuteQuery<string>($"UPDATE Товары SET ID_магазина = '{c}' WHERE ID_товара = {a}");
                    data.ExecuteQuery<string>($"UPDATE Товары SET Отпускная_цена = '{d}' WHERE ID_товара = {a}");
                    MessageBox.Show("Элемент успешно изменён!");
                    this.Close();
                }
            }
        }
        private void Отмена_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void notenabled()
        {
            Введите_наименование_товара2.IsEnabled = false;
            Выберите_магазин2.IsEnabled = false;
            Отпускная_цена2.IsEnabled = false;
            Изменить.IsEnabled = false;
        }
        private void enabled()
        {
            Введите_наименование_товара2.IsEnabled = true;
            Выберите_магазин2.IsEnabled = true;
            Отпускная_цена2.IsEnabled = true;
            Изменить.IsEnabled = true;
        }
    }
}
