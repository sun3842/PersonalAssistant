using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace AIUB.OOP2.PROJECT.Entity
{
    public class Contacts
    {
        public Contacts(int id, String name, String phone, String email, ref byte[] image)
        {
            Id = id;
            Names = name;
            Phone = phone;
            Email = email;
            Stream StreamObj = new MemoryStream(image);
            BitmapImage retrievedImage = new BitmapImage();
            retrievedImage.BeginInit();
            retrievedImage.StreamSource = StreamObj;
            retrievedImage.EndInit();
            Image = retrievedImage;

        }
        public int Id
        {
            set;
            get;
        }

        public String Names
        {
            set;
            get;
        }


        public String Phone
        {
            set;
            get;
        }

        public String Email
        {
            set;
            get;
        }


        public String T
        {
            get
            {
                return Names + '\n' + Phone;
            }
        }
        public BitmapImage Image
        {
            set;
            get;
        }
    }
}
