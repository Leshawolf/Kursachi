using System;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
namespace Автоматизация_складского_учёта
{
    public partial class UserWindow : Window
    {
        int d;
        string f;
        public UserWindow(string a, int b, string c )
        {
            InitializeComponent();
            if (a == "Заведующий")
                Окно_администратора.Visibility = Visibility.Visible;
            string cmd = "EXEC Процедура";
            d = b;
            GridFill(cmd);
            MessageBox.Show("Здравствуйте, " + c + "!");
            Поиск3.Items.Add("Поиск по наименованию продукции");
            Поиск3.Items.Add("Поиск по категории продукции");
            Поиск3.Items.Add("Поиск по статусу");
            Поиск3.Items.Add("Поиск по наименованию поставщика"); 
            Поиск3.Items.Add("Поиск по наименованию заказчика");
            Поиск3.SelectedIndex = 0;
            Статус.Items.Add("На складе");
            Статус.Items.Add("Продано");
            Статус.Visibility = Visibility.Hidden;
        }
        private void Добавить_поставку_Click(object sender, RoutedEventArgs e)
        {
            Add_supply a = new Add_supply();
            a.Show();
        }
        private void Изменить_поставку_Click(object sender, RoutedEventArgs e)
        {
            Edit_supply a = new Edit_supply();
            a.Show();
        }
        private void Удалить_поставку_Click(object sender, RoutedEventArgs e)
        {
            Delete_supply a = new Delete_supply();
            a.Show();
        }
        private void Добавить_заказ_Click(object sender, RoutedEventArgs e)
        {
            Add_order a = new Add_order(d);
            a.Show();
        }
        private void Изменить_заказ_Click(object sender, RoutedEventArgs e)
        {
            Edit_order a = new Edit_order();
            a.Show();
        }
        private void Удалить_заказ_Click(object sender, RoutedEventArgs e)
        {
            Delete_order a = new Delete_order();
            a.Show();
        }
        private void Отчёт_Click(object sender, RoutedEventArgs e)
        {
            Отчёт a = new Отчёт();
            a.Show();
        }
        private void Окно_администратора_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow a = new AdminWindow();
            a.Show();
        }
        private void Поиск2_Click(object sender, RoutedEventArgs e)
        {
            string a = Поиск4.Text;
            string cmd = "";
            switch (Поиск3.SelectedIndex)
            {
                case 0:
                    cmd = $"SELECT Продукции.Наименование, Категория_продукции, Количество, Статус, Поставщики.Наименование, Цена_поставки, Дата_поставки, Заказчики.Наименование, Цена_заказа, Дата_заказа, Цена_выручки FROM Продукции LEFT JOIN Категории_продукции ON Продукции.ID_категории = Категории_продукции.ID_категории INNER JOIN Поставщики ON Продукции.ID_поставщика = Поставщики.ID_поставщика INNER JOIN Поставки ON Продукции.ID_продукции = Поставки.ID_поставки LEFT JOIN Заказы ON Продукции.ID_продукции = Заказы.ID_продукции LEFT JOIN Заказчики ON Заказы.ID_заказчика = Заказчики.ID_заказчика WHERE Продукции.Наименование = '{a}' or Продукции.Наименование like('{a}%')";
                    break;
                case 1:
                    cmd = $"SELECT Продукции.Наименование, Категория_продукции, Количество, Статус, Поставщики.Наименование, Цена_поставки, Дата_поставки, Заказчики.Наименование, Цена_заказа, Дата_заказа, Цена_выручки FROM Продукции LEFT JOIN Категории_продукции ON Продукции.ID_категории = Категории_продукции.ID_категории INNER JOIN Поставщики ON Продукции.ID_поставщика = Поставщики.ID_поставщика INNER JOIN Поставки ON Продукции.ID_продукции = Поставки.ID_поставки LEFT JOIN Заказы ON Продукции.ID_продукции = Заказы.ID_продукции LEFT JOIN Заказчики ON Заказы.ID_заказчика = Заказчики.ID_заказчика WHERE Категория_продукции = '{a}'";
                    break;
                case 2:
                    cmd = $"SELECT Продукции.Наименование, Категория_продукции, Количество, Статус, Поставщики.Наименование, Цена_поставки, Дата_поставки, Заказчики.Наименование, Цена_заказа, Дата_заказа, Цена_выручки FROM Продукции LEFT JOIN Категории_продукции ON Продукции.ID_категории = Категории_продукции.ID_категории INNER JOIN Поставщики ON Продукции.ID_поставщика = Поставщики.ID_поставщика INNER JOIN Поставки ON Продукции.ID_продукции = Поставки.ID_поставки LEFT JOIN Заказы ON Продукции.ID_продукции = Заказы.ID_продукции LEFT JOIN Заказчики ON Заказы.ID_заказчика = Заказчики.ID_заказчика WHERE Статус = '{f}'";
                    Статус.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    cmd = $"SELECT Продукции.Наименование, Категория_продукции, Количество, Статус, Поставщики.Наименование, Цена_поставки, Дата_поставки, Заказчики.Наименование, Цена_заказа, Дата_заказа, Цена_выручки FROM Продукции LEFT JOIN Категории_продукции ON Продукции.ID_категории = Категории_продукции.ID_категории INNER JOIN Поставщики ON Продукции.ID_поставщика = Поставщики.ID_поставщика INNER JOIN Поставки ON Продукции.ID_продукции = Поставки.ID_поставки LEFT JOIN Заказы ON Продукции.ID_продукции = Заказы.ID_продукции LEFT JOIN Заказчики ON Заказы.ID_заказчика = Заказчики.ID_заказчика WHERE Поставщики.Наименование = '{a}' or Поставщики.Наименование like '{a}%'";
                    break;
                case 4:
                    cmd = $"SELECT Продукции.Наименование, Категория_продукции, Количество, Статус, Поставщики.Наименование, Цена_поставки, Дата_поставки, Заказчики.Наименование, Цена_заказа, Дата_заказа, Цена_выручки FROM Продукции LEFT JOIN Категории_продукции ON Продукции.ID_категории = Категории_продукции.ID_категории INNER JOIN Поставщики ON Продукции.ID_поставщика = Поставщики.ID_поставщика INNER JOIN Поставки ON Продукции.ID_продукции = Поставки.ID_поставки LEFT JOIN Заказы ON Продукции.ID_продукции = Заказы.ID_продукции LEFT JOIN Заказчики ON Заказы.ID_заказчика = Заказчики.ID_заказчика WHERE Заказчики.Наименование = '{a}' or Заказчики.Наименование like '{a}%'";
                    break;
            }
            GridFill(cmd);
        }
        private void Обновить_Click(object sender, RoutedEventArgs e)
        {
            string cmd = "SELECT Продукции.Наименование, Категория_продукции, Количество, Статус, Поставщики.Наименование, Цена_поставки, Дата_поставки, Заказчики.Наименование, Цена_заказа, Дата_заказа, Цена_выручки FROM Продукции LEFT JOIN Категории_продукции ON Продукции.ID_категории = Категории_продукции.ID_категории INNER JOIN Поставщики ON Продукции.ID_поставщика = Поставщики.ID_поставщика INNER JOIN Поставки ON Продукции.ID_продукции = Поставки.ID_поставки LEFT JOIN Заказы ON Продукции.ID_продукции = Заказы.ID_продукции LEFT JOIN Заказчики ON Заказы.ID_заказчика = Заказчики.ID_заказчика";
            GridFill(cmd);
        }
        private void Статус_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            f = Convert.ToString(Статус.SelectedItem);
        }
        private void Поиск3_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (Поиск3.SelectedIndex == 2)
                Статус.Visibility = Visibility.Visible;
        }
        private void GridFill(string cmd)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-8FRQK4J\SQLEXPRESS; Initial Catalog=Склад; Integrated Security=True");
            connection.Open();
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();
            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Продукции");
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
    }
}