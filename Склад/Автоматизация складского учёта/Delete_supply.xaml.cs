using System;
using System.Data.SqlClient;
using System.Windows;
namespace Автоматизация_складского_учёта
{
    public partial class Delete_supply : Window
    {
        WarehouseDataContext data = new WarehouseDataContext(Properties.Settings.Default.СкладConnectionString);
        public Delete_supply()
        {
            InitializeComponent();
            Выберите_поставку2.ItemsSource = data.ExecuteQuery<string>($"SELECT Наименование FROM Продукции");
            Удалить.IsEnabled = false;
        }
        private void Удалить_Click(object sender, RoutedEventArgs e)
        {
            string a = Convert.ToString(Выберите_поставку2.SelectedItem);
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-8FRQK4J\SQLEXPRESS; Initial Catalog=Склад; Integrated Security=True");
            string cmd1 = $"SELECT ID_продукции FROM Продукции WHERE Продукции.Наименование = '{a}'";
            connection.Open();
            SqlCommand command1 = new SqlCommand(cmd1, connection);
            SqlDataReader reader1 = command1.ExecuteReader();
            object b = null;
            if (reader1.HasRows)
                while (reader1.Read())
                    b = reader1.GetValue(0);
            reader1.Close();
            connection.Close();
            string mestext = "Подтвердить удаление записи?";
            string caption = "?";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;
            MessageBoxResult result = MessageBox.Show(mestext, caption, button, icon);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    data.ExecuteQuery<int>($"DELETE FROM Поставки WHERE ID_поставки = {Convert.ToInt32(b)}");
                    data.ExecuteQuery<int>($"DELETE FROM Продукции WHERE ID_продукции = {Convert.ToInt32(b)}");
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
        private void Выберите_поставку2_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Удалить.IsEnabled = true;
        }
    }
}