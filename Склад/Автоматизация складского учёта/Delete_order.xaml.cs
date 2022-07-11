using System;
using System.Data.SqlClient;
using System.Windows;
using System.Linq;
namespace Автоматизация_складского_учёта
{
    public partial class Delete_order : Window
    {
        WarehouseDataContext data = new WarehouseDataContext(Properties.Settings.Default.СкладConnectionString);
        public Delete_order()
        {
            InitializeComponent();
            Выберите_заказ2.ItemsSource = data.ExecuteQuery<string>($"SELECT Наименование FROM Продукции WHERE Статус = 'Продано'");
        }
        private void Удалить_Click(object sender, RoutedEventArgs e)
        {
            int a = data.ExecuteQuery<int>("SELECT * FROM Заказы").Count() + 1;
            string b = Convert.ToString(Выберите_заказ2.SelectedItem);
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
            string cmd2 = $"SELECT ID_заказа FROM Заказы WHERE Заказы.ID_ПРОДУКЦИИ = {Convert.ToInt32(c)}";
            SqlCommand command2 = new SqlCommand(cmd2, connection);
            SqlDataReader reader2 = command2.ExecuteReader();
            object d = null;
            if (reader2.HasRows)
                while (reader2.Read())
                    d = reader2.GetValue(0);
            reader2.Close();
            connection.Close();
            string mestext = "Подтвердить удаление записи?";
            string caption = "?";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;
            MessageBoxResult result = MessageBox.Show(mestext, caption, button, icon);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    data.ExecuteQuery<int>($"DELETE FROM Заказы WHERE ID_заказа={Convert.ToInt32(d)}");
                    data.ExecuteQuery<string>($"UPDATE Продукции SET Цена_выручки = 0 WHERE ID_продукции = {c} ");
                    data.ExecuteQuery<string>($"UPDATE Продукции set Статус = 'На складе' WHERE ID_продукции = {c}");
                    break;
                case MessageBoxResult.No:
                    break;
            }
            MessageBox.Show("Элемент успешно удалён!");
            this.Close();
        }
        private void Отмена_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}