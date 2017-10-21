using System;
using System.Collections.Generic;
using AIUB.OOP2.PROJECT.Service;
using AIUB.OOP2.PROJECT.Entity;
using System.Data.SqlClient;
using System.Windows.Controls;

namespace AIUB.OOP2.PROJECT.Data
{
    public class Data
    {
        public void add(String name, String phone, String email, List<TextBox> phoneBox, List<TextBox> emailBox, ref byte[] image)
        {
            String qury = "SELECT id FROM contact";
            int id = 0;
            SqlDataReader reader = DataBase.read(qury);
            while (reader.Read())
            {
                id = reader.GetInt32(0) + 1;
            }
            qury = "insert into contact(id,name,phone,email,image)values(" + id + ",'" + name + "','" + phone + "','" + email + "',@p)";
            int a = phoneBox.Count;
            DataBase.add(qury,ref image);
            int i = 0;
            while (i<a)
            {
                String p=phoneBox[0].Text;
                qury = "insert into Phone(id,phone) values("+id+",'"+p+"')";
                i++;
                DataBase.add(qury);
            }
            i = 0;
            a = emailBox.Count;
            while (i <a)
            {
                
                String p = emailBox[0].Text;
                qury = "insert into Email(id,email) values(" + id + ",'" + p + "')";
                i++;
                DataBase.add(qury);
            }
        }


        public void update(int id, String name, String phone, String email, List<TextBox> phoneBox, List<TextBox> emailBox, ref byte[] image)
        {
           String qury = "update contact set name='" + name + "',phone='" + phone + "',email='" + email + "',image=@p where id=" + id + "";
            DataBase.add(qury, ref image);
            int i = 0;
            int a = phoneBox.Count;
            while (a<i)
            {
                String p = phoneBox[0].Text;
                qury = "insert into Phone(id,phone) values(" + id + ",'" + p + "')";
                i++;
                DataBase.add(qury);
            }
            i = 0;
            a = phoneBox.Count;
            while (a<i)
            {

                String p = emailBox[0].Text;
                qury = "insert into Phone(id,phone) values(" + id + ",'" + p + ")";
                i++;
                DataBase.add(qury);
            }
        }

        public void remove(int id)
        {
            String qury = "delete Email from Email e, contact c where c.id=" + id + " and c.id=e.id; delete Phone from Phone p, contact c where c.id = " + id + " and c.id = p.id; delete from contact where id = " + id + "; "; //"delete from contact where id=" + id + "";
            DataBase.read(qury);

        }

        public List<Contacts> read()
        {
            String qury = "SELECT * FROM contact ORDER BY name";
            SqlDataReader reader= DataBase.read(qury);
            List<Contacts> contactList = new List<Contacts>();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    byte[] imageInByte = (byte[])reader["image"];
                    contactList.Add(new Contacts(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), ref imageInByte));
                }
            }
            return contactList;
            //return DataBase.read(qury);
        }

        public List<String> phoneread(int id)
        {
            String qury = "select p.phone from Phone p, contact c where p.id="+id+" and c.id="+id+"";
            SqlDataReader reader = DataBase.read(qury);
            List<String> phoneList = new List<String>();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                   // byte[] imageInByte = (byte[])reader["image"];
                    phoneList.Add(reader.GetString(0));
                }
            }
            return phoneList;
            //return DataBase.read(qury);
        }
        public List<String> emailread(int id)
        {
            String qury = "select e.email from Email e, contact c where e.id=" + id + " and c.id=e.id";
            SqlDataReader reader = DataBase.read(qury);
            List<String> emailList = new List<String>();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    //byte[] imageInByte = (byte[])reader["image"];
                    emailList.Add(reader.GetString(0));
                }
            }
            return emailList;
            //return DataBase.read(qury);
        }

        public List<Contacts> search(String s, String t)
        {
            String q = "%";
            String qury = "SELECT * FROM contact where " + t + " like '" + q + "" + s + "" + q + "'";
            DataBase.read(qury);
            SqlDataReader reader = DataBase.read(qury);
            List<Contacts> contactList = new List<Contacts>();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    byte[] imageInByte = (byte[])reader["image"];
                    contactList.Add(new Contacts(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), ref imageInByte));
                }
            }
            return contactList;
        }
    }
}
