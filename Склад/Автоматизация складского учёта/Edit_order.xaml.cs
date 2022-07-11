using System;
using System.Windows;
using System.Data.SqlClient;
namespace Автоматизация_складского_учёта
{
    public partial class Edit_order : Window
    {
        WarehouseDataContext data = new WarehouseDataContext(Properties.Settings.Default.СкладConnectionString);
        int h;
        int i;
        int z;
        public Edit_order()
        {
            InitializeComponent();
            Выберите_заказчика_продукции2.IsEnabled = false;
            Выберите_категорию_продукции2.IsEnabled = false;
            Цена2.IsEnabled = false;
            Изменить_заказ.IsEnabled = false;
            Выберите_заказ2.ItemsSource = data.ExecuteQuery<string>($"SELECT Наименование FROM Продукции WHERE Статус = 'Продано'");
        }
        private void Выберите_заказ2_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string a = Convert.ToString(Выберите_заказ2.SelectedItem);
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-8FRQK4J\SQLEXPRESS; Initial Catalog=Склад; Integrated Security=True");
            connection.Open();
            string cmd1 = $"SELECT ID_продукции FROM Продукции WHERE Продукции.Наименование = '{a}'";
            SqlCommand command1 = new SqlCommand(cmd1, connection);
            SqlDataReader reader1 = command1.ExecuteReader();
            object b = null;
            if (reader1.HasRows)
                while (reader1.Read())
                    b = reader1.GetValue(0);
            reader1.Close();
            i = Convert.ToInt32(b);
            string cmd2 = $"SELECT Категория_продукции FROM Категории_продукции, Продукции WHERE Категории_продукции.ID_категории = Продукции.ID_категории and Продукции.ID_продукции = {i}";
            SqlCommand command2 = new SqlCommand(cmd2, connection);
            SqlDataReader reader2 = command2.ExecuteReader();
            object c = null;
            if (reader2.HasRows)
                while (reader2.Read())
                    c = reader2.GetValue(0);
            reader2.Close();
            string cmd3 = $"SELECT Заказы.ID_заказа FROM Заказы, Продукции WHERE Заказы.ID_продукции = Продукции.ID_продукции and Продукции.ID_продукции = {i}";
            SqlCommand command3 = new SqlCommand(cmd3, connection);
            SqlDataReader reader3 = command3.ExecuteReader();
            object d = null;
            if (reader3.HasRows)
                while (reader3.Read())
                    d = reader3.GetValue(0);
            reader3.Close();
            h = Convert.ToInt32(d);
            string cmd4 = $"SELECT Заказчики.Наименование FROM Заказчики, Заказы  WHERE Заказчики.ID_заказчика = Заказы.ID_заказчика and Заказы.ID_заказа = {h}";
            SqlCommand command4 = new SqlCommand(cmd4, connection);
            SqlDataReader reader4 = command4.ExecuteReader();
            object f = null;
            if (reader4.HasRows)
                while (reader4.Read())
                    f = reader4.GetValue(0);
            reader4.Close();
            string cmd5 = $"SELECT Цена_заказа FROM Заказы WHERE Заказы.ID_заказа = {h}";
            SqlCommand command5 = new SqlCommand(cmd5, connection);
            SqlDataReader reader5 = command5.ExecuteReader();
            object g = null;
            if (reader5.HasRows)
                while (reader5.Read())
                    g = reader5.GetValue(0);
            reader5.Close();
            string cmd6 = $"SELECT Заказчики.ID_заказчика FROM Заказчики, Заказы  WHERE Заказчики.ID_заказчика = Заказы.ID_заказчика and Заказы.ID_заказа = {h}";
            SqlCommand command6 = new SqlCommand(cmd6, connection);
            SqlDataReader reader6 = command6.ExecuteReader();
            object j = null;
            if (reader6.HasRows)
                while (reader6.Read())
                    j = reader6.GetValue(0);
            reader6.Close();
            connection.Close();
            z = Convert.ToInt32(j);
            Выберите_заказчика_продукции2.IsEnabled = true; 
            Выберите_категорию_продукции2.IsEnabled = true;
            Цена2.IsEnabled = true;
            Изменить_заказ.IsEnabled = true;
            Выберите_заказчика_продукции2.ItemsSource = data.ExecuteQuery<string>($"SELECT Наименование FROM Заказчики");
            Выберите_категорию_продукции2.ItemsSource = data.ExecuteQuery<string>($"SELECT Категория_продукции FROM Категории_продукции");
            Выберите_заказчика_продукции2.SelectedItem = f.ToString();
            Выберите_категорию_продукции2.SelectedItem = c.ToString();
            Цена2.Text = g.ToString();
        }
        private void Изменить_заказ_Click(object sender, RoutedEventArgs e)
        {
            if (Цена2.Text == "")
                MessageBox.Show("Цена не может быть пустой!");
            else
            {
                //int b = Выберите_категорию_продукции2.SelectedIndex + 1;
                int f = Convert.ToInt32(Цена2.Text);
                int g = Vacation_price(f);
                data.ExecuteQuery<string>($"UPDATE Заказы SET Цена_заказа = {f} WHERE ID_заказа = {h}");
                data.ExecuteQuery<string>($"UPDATE Заказы SET ID_заказчика = {z} WHERE ID_заказа = {h}");
                data.ExecuteQuery<string>($"UPDATE Продукции SET Цена_выручки = '{g}' WHERE ID_продукции = {i}");
                MessageBox.Show("Элемент успешно изменён!");
                this.Close();
            }
        }
        private void Отмена_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public int Vacation_price(int a)
        {
            return a + (a * 12 / 100);
        }
    }
}