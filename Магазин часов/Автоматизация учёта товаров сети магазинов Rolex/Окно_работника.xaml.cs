using System;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
namespace Автоматизация_учёта_товаров_сети_магазинов_Rolex
{
    public partial class Окно_работника : Window
    {
        string f;
        dataDataContext data = new dataDataContext(Properties.Settings.Default.Интернет_магазинConnectionString);
        public Окно_работника(string a)
        {
            InitializeComponent();
            string cmd = "SELECT * FROM Таблица";
            GridFill(cmd);
            MessageBox.Show("Здравствуйте, " + a + "!");
            Поиск3.Items.Add("Поиск по магазину");
            Поиск3.Items.Add("Поиск по наименованию товара");
            Поиск3.Items.Add("Поиск по статусу");
            Поиск3.SelectedIndex = 0;
            Статус.Items.Add("На складе");
            Статус.Items.Add("Продано");
            Статус.Visibility = Visibility.Hidden;
            Магазин.ItemsSource = data.ExecuteQuery<string>($"SELECT Адрес_магазина FROM Магазины");
            Магазин.Visibility = Visibility.Visible;
            Поиск4.Visibility = Visibility.Hidden;
            Выберите_заказ1.Visibility = Visibility.Hidden;
            Выберите_заказ2.Visibility = Visibility.Hidden;
            Удалить.Visibility = Visibility.Hidden;
            Отмена.Visibility = Visibility.Hidden;
            Удалить.IsEnabled = false;
            Выберите_заказ2.ItemsSource = data.ExecuteQuery<string>($"SELECT Наименование FROM Товары WHERE Статус = '{"Продано"}'");
        }
        private void Добавить_товар_Click(object sender, RoutedEventArgs e)
        {
            Добавить_товар a = new Добавить_товар();
            a.Show();
        }
        private void Изменить_товар_Click(object sender, RoutedEventArgs e)
        {
            Изменить_товар a = new Изменить_товар();
            a.Show();
        }
        private void Удалить_товар_Click(object sender, RoutedEventArgs e)
        {
            Удалить_товар a = new Удалить_товар();
            a.Show();
        }
        private void Отчёт_Click(object sender, RoutedEventArgs e)
        {
            Отчёт a = new Отчёт();
            a.Show();
        }
        private void Поиск2_Click(object sender, RoutedEventArgs e)
        {
            string a = Поиск4.Text;
            string cmd = "";
            switch (Поиск3.SelectedIndex)
            {
                case 0:
                    cmd = $"SELECT * FROM Таблица WHERE Адрес_магазина = '{f}'";
                    break;
                case 1:
                    cmd = $"SELECT * FROM Таблица WHERE Товары.Наименование = '{a}' or Товары.Наименование like('{a}%')";
                    Магазин.Visibility = Visibility.Hidden;
                    Статус.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    cmd = $"SELECT * FROM Таблица WHERE Статус = '{f}'";
                    break;
            }
            GridFill(cmd);
        }
        private void Обновить_Click(object sender, RoutedEventArgs e)
        {
            string cmd = "SELECT * FROM Таблица";
            GridFill(cmd);
        }
        private void Статус_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            f = Convert.ToString(Статус.SelectedItem);
        }
        private void Магазин_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            f = Convert.ToString(Магазин.SelectedItem);
        }
        private void Поиск3_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (Поиск3.SelectedIndex == 0)
            {
                Магазин.Visibility = Visibility.Visible;
                Статус.Visibility = Visibility.Hidden;
                Поиск4.Visibility = Visibility.Hidden;
            }
            if (Поиск3.SelectedIndex == 1)
            {
                Магазин.Visibility = Visibility.Hidden;
                Статус.Visibility = Visibility.Hidden;
                Поиск4.Visibility = Visibility.Visible;
            }
            if (Поиск3.SelectedIndex == 2)
            {
                Магазин.Visibility = Visibility.Hidden;
                Статус.Visibility = Visibility.Visible;
                Поиск4.Visibility = Visibility.Hidden;
            }
        }
        private void GridFill(string cmd)
        {
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
        private void Выход_Click(object sender, RoutedEventArgs e)
        {
            MainWindow g = new MainWindow();
            g.Show();
            this.Close();
        }
        private void Удалить_заказ_Click(object sender, RoutedEventArgs e)
        {
            Выберите_заказ1.Visibility = Visibility.Visible;
            Выберите_заказ2.Visibility = Visibility.Visible;
            Удалить.Visibility = Visibility.Visible;
            Отмена.Visibility = Visibility.Visible;
        }
        private void Удалить_Click(object sender, RoutedEventArgs e)
        {
            int a = Выберите_заказ2.SelectedIndex+1;
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
        private void Отмена_Click(object sender, RoutedEventArgs e)
        {
            Выберите_заказ1.Visibility = Visibility.Hidden;
            Выберите_заказ2.Visibility = Visibility.Hidden;
            Удалить.Visibility = Visibility.Hidden;
            Отмена.Visibility = Visibility.Hidden;
            Удалить.IsEnabled = false;
        }
        private void Выберите_заказ2_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Удалить.IsEnabled = true;
        }
    }
}