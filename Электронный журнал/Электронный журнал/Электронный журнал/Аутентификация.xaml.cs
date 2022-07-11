using System;
using System.Data.SqlClient;
using System.Windows;
namespace Project_Zero
{
    public partial class Kod : Window
    {
        string a;
        string b;
        public Kod(string c, string d)
        {
            a = c;
            b = d;
            InitializeComponent();
        }
        private void Come_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string f = Code.Text;
                if (f == b)
                {
                    Unilife h = new Unilife(a);
                    h.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Message Error: {ex.Message}");
            }
        }
    }
}
