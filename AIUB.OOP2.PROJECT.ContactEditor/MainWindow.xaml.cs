using AIUB.OOP2.PROJECT.Calculator;
using System.Windows;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void contact_Click(object sender, RoutedEventArgs e)
        {
            Contact ct = new WpfApplication1.Contact();
            ct.Show();
        }

        private void calculator_Click(object sender, RoutedEventArgs e)
        {
            Calculator ct = new Calculator();
            ct.Show();
        }
    }
}
