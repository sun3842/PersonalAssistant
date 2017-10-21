using AIUB.OOP2.PROJECT.Entity;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using AIUB.OOP2.PROJECT.Data;
using AIUB.OOP2.PROJECT.Service;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Contact.xaml
    /// </summary>
    public partial class Contact : Window
    {
        public Contact()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Add_Contact add = new Add_Contact();
            add.Show();
            this.Close();
        }

        private void Contact_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contacts c = (Contacts)e.AddedItems[0];
            Data db = new Data();
            List<String> p = new List<string>();
            List<String> eml = new List<string>();
            p =db.phoneread(c.Id);
            eml=db.emailread(c.Id);
            Details d = new Details(c.Names, c.Phone, c.Email, c.Image, c.Id,p,eml);
            d.Show();
            this.Close();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            String s = (String)search_with.SelectionBoxItem;
            Data db = new Data();
            Contact_list.ItemsSource = db.search(contact_search.Text, s);

        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<Char> l = new List<Char>();
            for (Char c = 'A'; c <= 'Z'; c++)
            {
                l.Add(c);
            }
            First_letter.ItemsSource = l;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            Data db = new Data();
            Contact_list.ItemsSource = db.read();
            //Contact_list.ItemsSource = cs.read(); 
            //Contact_list.Items.Add(db.read());
        }

        private void ComboBox_Loaded_1(object sender, RoutedEventArgs e)
        {
            List<String> s = new List<string>();
            s.Add("name");
            s.Add("phone");
            s.Add("email");
            search_with.ItemsSource = s;
            search_with.SelectedIndex = 0;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Char c = (Char)e.AddedItems[0];
            MessageBox.Show(c.ToString());
        }

        private void search_with_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
