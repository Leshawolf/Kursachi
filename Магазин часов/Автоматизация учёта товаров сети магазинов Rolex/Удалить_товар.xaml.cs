using System.Windows;
namespace Автоматизация_учёта_товаров_сети_магазинов_Rolex
{
    public partial class Удалить_товар : Window
    {
        dataDataContext data = new dataDataContext(Properties.Settings.Default.Интернет_магазинConnectionString);
        public Удалить_товар()
        {
            InitializeComponent();
            Выберите_товар2.ItemsSource = data.ExecuteQuery<string>($"SELECT Наименование FROM Товары");
            Удалить.IsEnabled = false;
        }
        private void Удалить_Click(object sender, RoutedEventArgs e)
        {
            int a = Выберите_товар2.SelectedIndex;
            string mestext = "Подтвердить удаление записи?";
            string caption = "?";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;
            MessageBoxResult result = MessageBox.Show(mestext, caption, button, icon);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    data.ExecuteQuery<int>($"DELETE FROM Товары WHERE ID_товара = {a}");
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
        private void Выберите_товар2_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Удалить.IsEnabled = true;
        }
    }
}
