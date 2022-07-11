using System;
using System.Windows;
using System.Linq;
using System.Data.SqlClient;
namespace Автоматизация_складского_учёта
{
    public partial class Edit_supply : Window
    {
        int a;
        WarehouseDataContext data = new WarehouseDataContext(Properties.Settings.Default.СкладConnectionString);
        public Edit_supply()
        {
            InitializeComponent();
            notenabled();
            Выберите_поставку2.ItemsSource = data.ExecuteQuery<string>($"SELECT Наименование FROM Продукции");
        }
        private void Выберите_поставку2_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            a = Convert.ToInt32(Выберите_поставку2.SelectedIndex) + 1;
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-8FRQK4J\SQLEXPRESS; Initial Catalog=Склад; Integrated Security=True");
            string cmd1 = $"SELECT Категории_продукции.Категория_продукции FROM Продукции, Категории_продукции WHERE Продукции.ID_продукции = {a} and Категории_продукции.ID_категории = Продукции.ID_категории";
            string cmd2 = $"SELECT Поставщики.Наименование FROM Поставщики, Продукции WHERE Продукции.ID_продукции = {a} and Поставщики.ID_поставщика = Продукции.ID_поставщика";
            connection.Open();
            SqlCommand command1 = new SqlCommand(cmd1, connection);
            SqlCommand command2 = new SqlCommand(cmd2, connection);
            SqlDataReader reader1 = command1.ExecuteReader();
            object b = null;
            if (reader1.HasRows)
                while (reader1.Read())
                    b = reader1.GetValue(0);
            reader1.Close();
            SqlDataReader reader2 = command2.ExecuteReader();
            object c = null;
            if (reader2.HasRows)
                while (reader2.Read())
                    c = reader2.GetValue(0);
            reader2.Close();
            connection.Close();
            enabled();
            string d = Convert.ToString(Выберите_поставку2.SelectedItem);
            Введите_наименование_продукции2.Text = d;
            Выберите_категорию_продукции2.ItemsSource = data.ExecuteQuery<string>($"SELECT Категория_продукции FROM Категории_продукции");
            Выберите_категорию_продукции2.SelectedItem = b;
            Выберите_поставщика_продукции2.ItemsSource = data.ExecuteQuery<string>($"SELECT Наименование FROM Поставщики");
            Выберите_поставщика_продукции2.SelectedItem = c; 
            Количество2.Text = Convert.ToString(data.ExecuteQuery<int>($"SELECT Количество FROM Продукции").ElementAt(a-1));
            int f = Convert.ToInt32(data.ExecuteQuery<int>($"SELECT Количество FROM Продукции").ElementAt(a - 1));
            Цена2.Text = Convert.ToString(data.ExecuteQuery<int>($"SELECT Цена_поставки FROM Поставки").ElementAt(a-1)/f);
        }
        private void Изменить_продукцию_Click(object sender, RoutedEventArgs e)
        {
            if (Введите_наименование_продукции2.Text == "")
                MessageBox.Show("Наименование не может быть пустым!");
            else
            {
                if (Количество2.Text == "")
                    MessageBox.Show("Количество не может быть пустым!");
                else
                {
                    if (Цена2.Text == "")
                        MessageBox.Show("Цена не может быть пустой!");
                    else
                    {
                        string b = Введите_наименование_продукции2.Text;
                        int c = Convert.ToInt32(Выберите_категорию_продукции2.SelectedIndex) + 1;
                        int d = Convert.ToInt32(Выберите_поставщика_продукции2.SelectedIndex) + 1;
                        int f = Convert.ToInt32(Количество2.Text);
                        int g = Convert.ToInt32(Цена2.Text) * f;
                        data.ExecuteQuery<string>($"UPDATE Продукции set Наименование = '{b}' WHERE ID_продукции = {a}");
                        data.ExecuteQuery<string>($"UPDATE Продукции set ID_поставщика = '{d}' WHERE ID_продукции = {a}");
                        data.ExecuteQuery<string>($"UPDATE Продукции set ID_категории = '{c}' WHERE ID_продукции = {a}");
                        data.ExecuteQuery<string>($"UPDATE Продукции set Количество = '{f}' WHERE ID_продукции = {a}");
                        data.ExecuteQuery<string>($"UPDATE Поставки set ID_поставщика = '{d}' WHERE ID_поставки = {a}");
                        data.ExecuteQuery<string>($"UPDATE Поставки set Цена_поставки = '{g}' WHERE ID_поставки = {a}");
                        MessageBox.Show("Элемент успешно изменён!");
                        this.Close();
                    }
                }
            }
        }
        private void Отмена_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void notenabled()
        {
            Введите_наименование_продукции2.IsEnabled = false;
            Выберите_категорию_продукции2.IsEnabled = false;
            Выберите_поставщика_продукции2.IsEnabled = false;
            Цена2.IsEnabled = false;
            Количество2.IsEnabled = false;
            Изменить_продукцию.IsEnabled = false;
        }
        private void enabled()
        {
            Введите_наименование_продукции2.IsEnabled = true;
            Выберите_категорию_продукции2.IsEnabled = true;
            Выберите_поставщика_продукции2.IsEnabled = true;
            Цена2.IsEnabled = true;
            Количество2.IsEnabled = true;
            Изменить_продукцию.IsEnabled = true;
        }
    }
}