using System;
using System.Windows;
namespace Автоматизация_складского_учёта
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
            this.ReportViewer.ReportPath = System.IO.Path.Combine(Environment.CurrentDirectory, @"C:\Users\Notebook\Desktop\Колледж\4 курс\БДиСУБД\Курсовой проект\Автоматизация складского учёта\Отчёт.rdl");
            this.ReportViewer.RefreshReport();
        }
    }
}