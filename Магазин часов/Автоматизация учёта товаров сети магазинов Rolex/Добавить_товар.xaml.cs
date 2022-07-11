using System;
using System.Linq;
using System.Windows;
namespace Автоматизация_учёта_товаров_сети_магазинов_Rolex
{
    public partial class Добавить_товар : Window
    {
        dataDataContext data = new dataDataContext(Properties.Settings.Default.Интернет_магазинConnectionString);
        public Добавить_товар()
        {   
            InitializeComponent();
            Выберите_магазин2.ItemsSource = data.ExecuteQuery<string>($"SELECT Адрес_магазина FROM Магазины");
        }
        private void Добавить_продукцию_Click(object sender, RoutedEventArgs e)
        {
            if (Выберите_магазин2.SelectedIndex == -1)
                MessageBox.Show("Вы не выбрали магазин!");
            else
            {
                if (Введите_наименование_товара2.Text == "")
                    MessageBox.Show("Наименование не может быть пустым!");
                else
                {
                    if (Отпускная_цена2.Text == "")
                        MessageBox.Show("Цена не может быть пустой!");
                    else
                    {
                        int a = data.ExecuteQuery<int>("SELECT * FROM Товары").Count() + 1;
                        int b = Convert.ToInt32(Выберите_магазин2.SelectedIndex) + 1;
                        string c = Введите_наименование_товара2.Text;
                        int d = Convert.ToInt32(Отпускная_цена2.Text);
                        data.ExecuteQuery<string>($"INSERT INTO Товары(ID_товара, Наименование, Отпускная_цена, Статус, ID_магазина) VALUES({a}, '{c}', {d}, '{"На складе"}', {b})");
                        MessageBox.Show("Элемент успешно добавлен!");
                        this.Close();
                    }
                }
            }
        }
        private void Отмена_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
