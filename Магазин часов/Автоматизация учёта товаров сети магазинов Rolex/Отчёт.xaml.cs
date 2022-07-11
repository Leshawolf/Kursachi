using System;
using System.Windows;
namespace Автоматизация_учёта_товаров_сети_магазинов_Rolex
{
    public partial class Отчёт : Window
    {
        public Отчёт()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Window_Loaded);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.ReportViewer.ReportPath = System.IO.Path.Combine(Environment.CurrentDirectory, @"C:\Users\Notebook\Desktop\Автоматизация учёта товаров сети магазинов Rolex\Отчёт.rdl");
            this.ReportViewer.RefreshReport();
        }
    }
}
