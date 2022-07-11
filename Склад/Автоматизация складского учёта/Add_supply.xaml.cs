using System;
using System.Windows;
using System.Linq;
namespace Автоматизация_складского_учёта
{
    public partial class Add_supply : Window
    {
        public Add_supply()
        {
            InitializeComponent();
            Выберите_категорию_продукции2.ItemsSource = data.ExecuteQuery<string>("SELECT Категория_продукции FROM Категории_продукции");
            Выберите_поставщика_продукции2.ItemsSource = data.ExecuteQuery<string>("SELECT Наименование FROM Поставщики");
        }
        WarehouseDataContext data = new WarehouseDataContext(Properties.Settings.Default.СкладConnectionString);
        private void Добавить_продукцию_Click(object sender, RoutedEventArgs e)
        {
            if (Введите_наименование_продукции2.Text == "")
                MessageBox.Show("Наименование не может быть пустым!");
            else
            {
                if (Выберите_категорию_продукции2.SelectedIndex == -1)
                    MessageBox.Show("Категория не может быть пустой!");
                else
                {
                    if (Выберите_поставщика_продукции2.SelectedIndex == -1)
                        MessageBox.Show("Поставщик не может быть пустым!");
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
                                int a = data.ExecuteQuery<int>("SELECT * FROM Продукции").Count() + 1;
                                string b = Введите_наименование_продукции2.Text;
                                int c = Convert.ToInt32(Выберите_категорию_продукции2.SelectedIndex) + 1;
                                int d = Convert.ToInt32(Выберите_поставщика_продукции2.SelectedIndex) + 1;
                                int f = Convert.ToInt32(Количество2.Text);
                                int g = Convert.ToInt32(Цена2.Text) * f;
                                string h = DateTime.Now.ToShortDateString();
                                data.ExecuteQuery<string>($"INSERT INTO Поставки(ID_поставки, Дата_поставки, Цена_поставки, ID_поставщика) values({a}, '{h}', {g}, {d})");
                                data.ExecuteQuery<string>($"INSERT INTO Продукции(ID_продукции, Наименование, Цена_выручки, Количество, Статус, ID_поставщика, ID_категории) values({a}, '{b}', {0}, {f}, '{"На складе"}', {d}, {c})");
                                MessageBox.Show("Элемент успешно добавлен!");
                                this.Close();
                            }
                        }
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