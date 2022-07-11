using System;
using System.Linq;
using System.Data.SqlClient;
using System.Windows;
namespace Автоматизация_складского_учёта
{
    public partial class Add_order : Window
    {
        WarehouseDataContext data = new WarehouseDataContext(Properties.Settings.Default.СкладConnectionString);
        int h;
        public Add_order(int a)
        {
            InitializeComponent();
            h = a;
            Выберите_заказчика_продукции2.ItemsSource = data.ExecuteQuery<string>($"SELECT Наименование FROM Заказчики");
            Выберите_категорию_продукции2.IsEnabled = false;
            Выберите_продукцию2.IsEnabled = false;
        }
        private void Добавить_заказ_Click(object sender, RoutedEventArgs e)
        {
            if (Выберите_заказчика_продукции2.SelectedIndex == -1)
                MessageBox.Show("Наименование не может быть пустым!");
            else
            {
                if (Выберите_категорию_продукции2.SelectedIndex == -1)
                    MessageBox.Show("Категория не может быть пустой!");
                else
                {
                    if (Выберите_продукцию2.SelectedIndex == -1)
                        MessageBox.Show("Продукция не может быть пустой!");
                    else
                    {
                        if (Цена2.Text == "")
                            MessageBox.Show("Цена не может быть пустой!");
                        else
                        {
                            int a = data.ExecuteQuery<int>("SELECT * FROM Заказы").Count() + 1;
                            string b = Convert.ToString(Выберите_продукцию2.SelectedItem);
                            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-8FRQK4J\SQLEXPRESS; Initial Catalog=Склад; Integrated Security=True");
                            string cmd1 = $"SELECT ID_продукции FROM Продукции WHERE Продукции.Наименование = '{b}'";
                            connection.Open();
                            SqlCommand command1 = new SqlCommand(cmd1, connection);
                            SqlDataReader reader1 = command1.ExecuteReader();
                            object c = null;
                            if (reader1.HasRows)
                                while (reader1.Read())
                                    c = reader1.GetValue(0);
                            reader1.Close();
                            connection.Close();
                            string d = DateTime.Now.ToShortDateString();
                            int f = Convert.ToInt32(Цена2.Text);
                            int g = Выберите_заказчика_продукции2.SelectedIndex + 1;
                            int i = Vacation_price(f);
                            data.ExecuteQuery<string>($"INSERT INTO Заказы(ID_заказа, Дата_заказа, Цена_заказа, ID_продукции, ID_заказчика, ID_работника) values( {a}, '{d}', {f}, {c}, {g}, {h} )");
                            data.ExecuteQuery<string>($"UPDATE Продукции SET Цена_выручки = {i} WHERE ID_продукции = {c} ");
                            data.ExecuteQuery<string>($"UPDATE Продукции set Статус = 'Продано' WHERE ID_продукции = {c} ");
                            MessageBox.Show("Элемент успешно добавлен!");
                            this.Close();
                        }
                    }
                }
            }
        }
        private void Отмена_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Выберите_заказчика_продукции2_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Выберите_категорию_продукции2.ItemsSource = data.ExecuteQuery<string>($"SELECT Категория_продукции FROM Категории_продукции");
            Выберите_категорию_продукции2.IsEnabled = true;
        }
        private void Выберите_категорию_продукции2_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            int a = Выберите_категорию_продукции2.SelectedIndex + 1;
            Выберите_продукцию2.ItemsSource = data.ExecuteQuery<string>($"SELECT Наименование FROM Продукции WHERE Статус = 'На складе' and Продукции.ID_категории = {a}");
            Выберите_продукцию2.IsEnabled = true;
        }
        public int Vacation_price(int a)
        {
            return a + (a * 12 / 100);
        }
    }
}