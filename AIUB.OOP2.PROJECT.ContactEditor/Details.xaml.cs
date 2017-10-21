using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using AIUB.OOP2.PROJECT.Data;
using System.Collections.Generic;
using System.Windows.Controls;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Details.xaml
    /// </summary>
    public partial class Details : Window
    {

        BitmapImage selectedImage;
        BitmapImage temp = null;
        private int id = -100;
        List<TextBox> emailList = new List<TextBox>();
        List<TextBox> phoneList = new List<TextBox>();

        public Details(String n, String p, String e, BitmapImage i, int id,List<String> m,List<String> eml)
        {
            InitializeComponent();
            name.Text = n;
            phone.Text = p;
            email.Text = e;
            image.Source = i;
            temp = i;
            this.id = id;
            int x = eml.Count;
            int y = 0;
           // MessageBox.Show(m[0]);
            while (y < x)
            {
                
                TextBox t = new TextBox();
                // emailList.Add(t);
                t.Height = 23;
                t.Width = 200;
                t.Text = eml[y];
                emailPanel1.Children.Add(t);
                //emailPanel1.Children[y] = m[y];

                y++;
                //emailList.Add(t);
            }
            x = m.Count;
            y = 0;
            while (y < x)
            {
                TextBox t = new TextBox();
                // emailList.Add(t);
                t.Height = 23;
                t.Width = 200;
                t.Text = m[y];
                phonePanel1.Children.Add(t);
                //emailList.Add(t);
                y++;
            }
            name.IsEnabled = false;
            phone.IsEnabled = false;
            email.IsEnabled = false;
            image_update.Visibility = System.Windows.Visibility.Hidden;
            Save.Visibility = System.Windows.Visibility.Hidden;
            phonePlusEdit.Visibility = Visibility.Collapsed;
            emailPlusEdit.Visibility = Visibility.Collapsed;

        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Contact c = new Contact();
            c.Show();
            this.Close();
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            name.IsEnabled = true;
            phone.IsEnabled = true;
            email.IsEnabled = true;
            phonePlusEdit.Visibility = Visibility.Visible;
            emailPlusEdit.Visibility = Visibility.Visible;
            image_update.Visibility = System.Windows.Visibility.Visible;
            Save.Visibility = System.Windows.Visibility.Visible;
            delete.Visibility = System.Windows.Visibility.Hidden;
            update.Visibility = System.Windows.Visibility.Hidden;
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            Data d = new Data();
            d.remove(id);
            Contact c = new Contact();
            c.Show();
            this.Close();
        }

        private void Save_Click_1(object sender, RoutedEventArgs e)
        {
            byte[] imageInByte;
            if (selectedImage != null)
            {
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(selectedImage));
                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    imageInByte = ms.ToArray();
                }
            }
            else
            {
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(temp));
                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    imageInByte = ms.ToArray();
                }
            }

            try
            {
                Data db = new Data();
                db.update(id, name.Text, phone.Text, email.Text, phoneList, emailList, ref imageInByte);
                MessageBox.Show("Inserted");
                Contact c = new Contact();
                c.Show();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void image_update_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            Uri uri;
            if (dialog.ShowDialog() == true)
            {
                uri = new Uri(dialog.FileName);
                selectedImage = new BitmapImage(uri);
                image.Source = selectedImage;
            }
        }

        private void phonePlusEdit_Click(object sender, RoutedEventArgs e)
        {
            
            TextBox t = new TextBox();
            t.Height = 23;
            t.Width = 200;
            phonePanel1.Children.Add(t);
            phoneList.Add(t);
        }

        private void emailPlusEdit_Click(object sender, RoutedEventArgs e)
        {
            TextBox t = new TextBox();
           // emailList.Add(t);
            t.Height = 23;
            t.Width = 200;
            emailPanel1.Children.Add(t);
            emailList.Add(t);
        }
    }
}
