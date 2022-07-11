using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
namespace Железнодорожные_переезды
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }
        DataClasses1DataContext data = new DataClasses1DataContext(Properties.Settings.Default.АвтовокзалConnectionString);
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Информация.ItemsSource = data.ExecuteQuery<Билет>($"SELECT * FROM Билет");
        }
        private void Переименовать_пассажира_Click(object sender, RoutedEventArgs e)
        {
            Введите_новое_ФИО1.Visibility = Visibility.Visible;
            Введите_новое_ФИО2.Visibility = Visibility.Visible;
            Изменить.Visibility = Visibility.Visible;
        }
        private void Удалить_Click(object sender, RoutedEventArgs e)
        {
            var a = Информация.SelectedIndex;
            int b = data.ExecuteQuery<int>($"SELECT Номер_билета FROM Билет").ElementAt(Convert.ToInt32(a));
            string mestext = "Подтвердить удаление записи?";
            string caption = "?";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;
            MessageBoxResult result = MessageBox.Show(mestext, caption, button, icon);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    data.ExecuteQuery<int>($"DELETE FROM Билет WHERE Номер_билета={b}");
                    break;
                case MessageBoxResult.No:
                    break;
            }
            MessageBox.Show("Элемент успешно удалён!");
            Информация.ItemsSource = data.ExecuteQuery<Билет>($"SELECT * FROM Билет");
        }
        private void Удалить_всё_Click(object sender, RoutedEventArgs e)
        {
            string mestext = "Подтвердить удаление таблицы?";
            string caption = "?";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;
            MessageBoxResult result = MessageBox.Show(mestext, caption, button, icon);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    data.ExecuteQuery<int>($"DELETE FROM Билет");
                    break;
                case MessageBoxResult.No:
                    break;
            }
            MessageBox.Show("Таблица успешно очищена!");
            Информация.ItemsSource = data.ExecuteQuery<Билет>($"SELECT * FROM Билет");
        }
        private void Изменить_Click(object sender, RoutedEventArgs e)
        {
            var a = Информация.SelectedIndex;
            int b = data.ExecuteQuery<int>($"SELECT Номер_билета FROM Билет").ElementAt(Convert.ToInt32(a));
            string c = Введите_новое_ФИО2.Text;
            if (!string.IsNullOrEmpty(Введите_новое_ФИО2.Text))
                data.ExecuteQuery<string>($"UPDATE Билет SET ФИО_пассажира = '{c}' WHERE Номер_билета = {b}");
            else
                MessageBox.Show("Вы не ввели ФИО!");
            Введите_новое_ФИО2.Text = "";
            Введите_новое_ФИО1.Visibility = Visibility.Hidden;
            Введите_новое_ФИО2.Visibility = Visibility.Hidden;
            Изменить.Visibility = Visibility.Hidden;
            Информация.ItemsSource = data.ExecuteQuery<Билет>($"SELECT * FROM Билет");
        }
    }
}
