using System;
using System.Collections.Generic;
using System.Data;
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

namespace AIUB.OOP2.PROJECT.Calculator
{
    /// <summary>
    /// Interaction logic for Calculator.xaml
    /// </summary>
    public partial class Calculator : Window
    {
        public Calculator()
        {
            InitializeComponent();
        }
        static double Evaluate(string expression)
        {
            var loDataTable = new DataTable();
            var loDataColumn = new DataColumn("Eval", typeof(double), expression);
            loDataTable.Columns.Add(loDataColumn);
            loDataTable.Rows.Add(0);
            return (double)(loDataTable.Rows[0]["Eval"]);
        }
        private void one_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += 1;
        }

        private void two_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += 2;
        }

        private void three_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += 3;
        }

        private void four_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += 4;
        }

        private void five_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += 5;
        }

        private void six_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += 6;
        }

        private void seven_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += 7;
        }

        private void eight_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += 8;
        }

        private void nine_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += 9;
        }

        private void zero_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += 0;
        }

        private void dot_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += ".";
        }

        private void sum_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "+";
        }

        private void sub_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "-";
        }

        private void mul_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "*";
        }

        private void div_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "/";
        }

        private void CE_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = null;
        }

        private void equal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double result = Evaluate(textBox.Text);
                textBox.Text = Convert.ToString(result);
            }
            catch (Exception ex) {
                textBox.Text = "Syntex error";
            }
            //double result = Evaluate(textBox.Text);
            //textBox.Text = Convert.ToString(result);
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text.Length == 0)
                textBox.Text = textBox.Text;
            else
                textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
        }
    }
}
