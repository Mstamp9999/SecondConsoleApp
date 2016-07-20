using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace secondConsoleApp
{

    public class BlogPost
    {
       public int id;
       public string Text;
       public int userId;
       public string date;

    }



    class Program
    {
        static void Main(string[] args)
        {
            var blogpost = new BlogPost();
            blogpost.id = 1;
            blogpost.Text = "this is a test";
            blogpost.userId = 2;
            blogpost.date = "7/19/2016";
            InsertBlogPost(blogpost);
            ReadFromBankAccount();

            Console.ReadLine();
    

        }

        static void InsertBlogPost(int id, string blogpost, int userId, string date)
        {

        }

        static void ReadFromBankAccount()
        {

            SqlConnection connection = new SqlConnection("Data Source=(LocalDb)\\v11.0;Initial Catalog=aspnet-MvcApplication1-20160628191626;Integrated Security=SSPI;");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM BankAccount";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;

            connection.Open();

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["Id"] + " " +
                reader["Fname"] + " " +
                reader["Lname"] + " " +
                reader["AccountNum"] + " " +
                reader["Address"] + " " +
                reader["Balance"] + " " +
                reader["Active"]);
            }

            connection.Close();


        }

        static void InsertBlogPost(BlogPost blogpost)
        {

            SqlConnection connection = new SqlConnection("Data Source=(LocalDb)\\v11.0;Initial Catalog=aspnet-MvcApplication1-20160628191626;Integrated Security=SSPI;");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "INSERT INTO [dbo].[BlogPosts] VALUES (" + blogpost.id + ", '" + blogpost.Text + "', " + blogpost.userId + ", '" + blogpost.date + "')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;

            connection.Open();
            cmd.ExecuteNonQuery();

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["BlogPostId"] + " " +
                reader["BlogPost"] + " " +
                reader["userId"] + " " +
                reader["DatePosted"]);
            }

            connection.Close();

        }
        



    }
}
