using System.Windows;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
namespace Автоматизация_учёта_товаров_сети_магазинов_Rolex
{
    public partial class Окно_клиента : Window
    {
        dataDataContext data = new dataDataContext(Properties.Settings.Default.Интернет_магазинConnectionString);
        int x;
        public Окно_клиента(int a)
        {
            InitializeComponent();
            GridFill();
            Выберите_заказ1.Visibility = Visibility.Hidden;
            Выберите_заказ2.Visibility = Visibility.Hidden;
            Удалить.Visibility = Visibility.Hidden;
            Сохранить.Visibility = Visibility.Hidden;
            Отмена_заказа.Visibility = Visibility.Hidden;
            x = a;
        }
        private void Выход_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Изменить_личные_данные_Click(object sender, RoutedEventArgs e)
        {
            Изменение_клиента a = new Изменение_клиента(2, x);
            a.Show();
        }
        private void Сохранить_Click(object sender, RoutedEventArgs e)
        {
            Выберите_заказ1.Visibility = Visibility.Hidden;
            Выберите_заказ2.Visibility = Visibility.Hidden;
            Сохранить.Visibility = Visibility.Hidden;
            Отмена_заказа.Visibility = Visibility.Hidden;
            int a = data.ExecuteQuery<int>("SELECT * FROM Заказы").Count() + 1;
            int b = Выберите_заказ2.SelectedIndex + 1;
            string c = "11.11.2021";
            int d = 55;
            data.ExecuteQuery<string>($"INSERT INTO Заказы(ID_заказа, Дата_заказа, Цена_заказа, ID_товара, ID_покупателя) VALUES({a}, '{c}', {d}, {b}, {x})");
            data.ExecuteQuery<string>($"UPDATE Товары SET Статус= '{"Продано"}' WHERE ID_товара = {b}");
            MessageBox.Show("Элемент успешно добавлен!");
        }
        private void Обновить_Click(object sender, RoutedEventArgs e)
        {
            GridFill();
        }
        private void Отмена_заказа_Click(object sender, RoutedEventArgs e)
        {
            Выберите_заказ1.Visibility = Visibility.Hidden;
            Выберите_заказ2.Visibility = Visibility.Hidden;
            Удалить.Visibility = Visibility.Hidden;
            Сохранить.Visibility = Visibility.Hidden;
            Отмена_заказа.Visibility = Visibility.Hidden;
        }
        private void GridFill()
        {
            string cmd = $"SELECT Адрес_магазина, Наименование, Дата_заказа, Цена_заказа FROM Магазины INNER JOIN Товары ON Магазины.ID_магазина = Товары.ID_товара INNER JOIN Заказы ON Заказы.ID_товара = Товары.ID_товара AND Заказы.ID_покупателя = {x}";
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-8FRQK4J\SQLEXPRESS; Initial Catalog=Интернет_магазин; Integrated Security=True");
            connection.Open();
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();
            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Товары");
            dataAdp.Fill(dt);
            Информация.ItemsSource = dt.DefaultView;
            connection.Close();
        }
        private void Добавить_заказ_Click(object sender, RoutedEventArgs e)
        {
            Выберите_заказ1.Visibility = Visibility.Visible;
            Выберите_заказ2.Visibility = Visibility.Visible;
            Сохранить.Visibility = Visibility.Visible;
            Отмена_заказа.Visibility = Visibility.Visible;
            Выберите_заказ2.ItemsSource = data.ExecuteQuery<string>($"SELECT Наименование FROM Товары WHERE Статус = 'На складе'");
        }
        private void Удалить_заказ_Click(object sender, RoutedEventArgs e)
        {
            Выберите_заказ1.Visibility = Visibility.Visible;
            Выберите_заказ2.Visibility = Visibility.Visible;
            Удалить.Visibility = Visibility.Visible;
            Отмена_заказа.Visibility = Visibility.Visible;
            Выберите_заказ2.ItemsSource = data.ExecuteQuery<string>($"SELECT Наименование FROM Товары WHERE Статус = 'Продано'");
        }
        private void Удалить_Click(object sender, RoutedEventArgs e)
        {
            Выберите_заказ1.Visibility = Visibility.Hidden;
            Выберите_заказ2.Visibility = Visibility.Hidden;
            Удалить.Visibility = Visibility.Hidden;
            Отмена_заказа.Visibility = Visibility.Hidden;
            int a = Выберите_заказ2.SelectedIndex + 1;
            string mestext = "Подтвердить удаление записи?";
            string caption = "?";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;
            MessageBoxResult result = MessageBox.Show(mestext, caption, button, icon);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    data.ExecuteQuery<int>($"DELETE FROM Заказы WHERE ID_заказа = {a}");
                    data.ExecuteQuery<string>($"UPDATE Товары SET Статус = '{"На складе"}' WHERE ID_товара = {a}");
                    break;
                case MessageBoxResult.No:
                    break;
            }
            MessageBox.Show("Элемент успешно удалён!");
        }
    }
}