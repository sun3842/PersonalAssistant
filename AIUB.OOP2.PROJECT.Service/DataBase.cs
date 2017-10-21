using System;
using System.Data.SqlClient;

namespace AIUB.OOP2.PROJECT.Service
{
    static public class DataBase
    {
        static private String connectionString= "Server=HP-MAD; Database=contactDB; User Id=sa; Password=root";

        static  public void add(String qury, ref byte[] image)
        {
            SqlConnection sql = new SqlConnection(connectionString);
            sql.Open();
            SqlCommand cmd = new SqlCommand(qury, sql);
            cmd.Parameters.AddWithValue("@p", image);
            cmd.ExecuteNonQuery();
            sql.Close();
        }

        static public void add(String qury)
        {
            SqlConnection sql = new SqlConnection(connectionString);
            sql.Open();
            SqlCommand cmd = new SqlCommand(qury, sql);
            cmd.ExecuteNonQuery();
            sql.Close();
        }

        static public SqlDataReader read(String qury)
        {
            SqlConnection sql = new SqlConnection(connectionString);
            sql.Open();
            SqlCommand cmd = new SqlCommand(qury, sql);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }


        
    }
}
