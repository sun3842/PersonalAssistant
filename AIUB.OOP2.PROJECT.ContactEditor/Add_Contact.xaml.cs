using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using AIUB.OOP2.PROJECT.Data;
using System.Windows.Controls;
using System.Collections.Generic;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Add_Contact.xaml
    /// </summary>
    public partial class Add_Contact : Window
    {
        BitmapImage selectedImage;
        bool op;
        List<TextBox> emailList = new List<TextBox>();
        List<TextBox> phoneList = new List<TextBox>();
        public Add_Contact()
        {
            InitializeComponent();
            op = false;
        }

        private void open_image_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            Uri uri;
            if (dialog.ShowDialog() == true)
            {
                uri = new Uri(dialog.FileName);
                selectedImage = new BitmapImage(uri);
                image.Source = selectedImage;
            }
            op = true;
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Contact c = new Contact();
            c.Show();
            this.Close();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (op == false)
            {
                // MessageBox.Show("image no inserted");
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri("d.png", UriKind.Relative);
                bi3.EndInit();
                selectedImage = bi3;

            }
            byte[] imageInByte;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(selectedImage));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                imageInByte = ms.ToArray();
            }

            if (imageInByte != null)
            {
                try
                {
                    Data db = new Data();
                    db.add(name.Text, phone.Text, email.Text,phoneList,emailList, ref imageInByte);
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

            this.Close();
        }

        private void phonePlus_Click(object sender, RoutedEventArgs e)
        {
            TextBox t = new TextBox();
            t.Height = 23;
            t.Width = 200;
            phonePanel.Children.Add(t);
            phoneList.Add(t);
        }

        private void emailPlus_Click(object sender, RoutedEventArgs e)
        {
            //List<TextBox> list = new List<TextBox>();

            TextBox t = new TextBox();
           // emailList.Add(t);
            t.Height = 23;
            t.Width = 200;
            emailPanel.Children.Add(t);
            emailList.Add(t);

           // t.TextChanged += phonePlus_Click;
            
        }
    }
}
