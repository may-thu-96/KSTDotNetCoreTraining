using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSTDotNetCoreTraining.ConsoleApp
{
    public class AdoDotNetExample
    {
        private readonly string _connectionString = "Data Source=DESKTOP-AQCT4ER\\MSSQLSERVER2016;Initial Catalog=DotNetTraining;User ID=sa;Password=sasa;";
        public void Read()
        {
            //  string connectionString = "Data Source=DESKTOP-AQCT4ER\\MSSQLSERVER2016;Initial Catalog=DotNetTraining;User ID=sa;Password=sasa;";
            Console.WriteLine("Connection String:" + _connectionString);
            SqlConnection connection = new SqlConnection(_connectionString);
            Console.WriteLine("Connection Opening...");

            connection.Open();
            Console.WriteLine("Connection Opened");
            string query = @"SELECT [BlogID]
                  ,[BlogTitle]
                  ,[BlogAuthor]
                  ,[BlogContent]
                  ,[DeleteFlag]
              FROM [dbo].[Tbl_Blog] where DeleteFlag=1";
            SqlCommand command = new SqlCommand(query, connection);
            //SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            //DataTable db = new DataTable();
            //dataAdapter.Fill(db);
            //db = dataAdapter.Execute();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["BlogID"]);
                Console.WriteLine(reader["BlogTitle"]);
                Console.WriteLine(reader["BlogAuthor"]);
                Console.WriteLine(reader["BlogContent"]);
            }

            Console.WriteLine("Connection Closing...");
            connection.Close();
            Console.WriteLine("Connection Closed");
            Console.ReadKey();
            //dataset
            //datatable
            //datarow
            //DataColumn
            //foreach (DataRow dr in db.Rows)
            //{
            //    Console.WriteLine(dr["BlogID"]);
            //    Console.WriteLine(dr["BlogTitle"]);
            //    Console.WriteLine(dr["BlogAuthor"]);
            //    Console.WriteLine(dr["BlogContent"]);

            //}

        }
        public void Create()
        {
            Console.WriteLine("Blog Title :");
            string title = Console.ReadLine();

            Console.WriteLine("Blog Author :");
            string author = Console.ReadLine();

            Console.WriteLine("Blog Content :");
            string content = Console.ReadLine();

            //  string connectionString2 = "Data Source=DESKTOP-AQCT4ER\\MSSQLSERVER2016;Initial Catalog=DotNetTraining;User ID=sa;Password=sasa;";

            SqlConnection connection = new SqlConnection(_connectionString);
            //string insertquery = $@"INSERT INTO [dbo].[Tbl_Blog]
            //           ([BlogTitle]
            //           ,[BlogAuthor]
            //           ,[BlogContent]
            //           ,[DeleteFlag])
            //     VALUES
            //           ('{title}'
            //           ,'{author}'
            //           ,'{content}'
            //           ,0)";
            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent]
           ,[DeleteFlag])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent
           ,0)";
            connection.Open();
            SqlCommand command2 = new SqlCommand(query, connection);
            command2.Parameters.AddWithValue("@BlogTitle", title);
            command2.Parameters.AddWithValue("@BlogAuthor", author);
            command2.Parameters.AddWithValue("@BlogContent", content);

            int result = command2.ExecuteNonQuery();
            //SqlDataAdapter dataAdapter = new SqlDataAdapter(command2);
            //DataTable dtinsert = new DataTable();
            //dataAdapter.Fill(dtinsert);

            connection.Close();

            //if (result == 1)
            //{
            //    Console.WriteLine("Saving Successful...");
            //}
            //else
            //{
            //    Console.WriteLine("Saving Faileds....");
            //}
            Console.WriteLine(result == 1 ? "Saving Successful..." : "Saving Faileds....");
        }
        public void Edit()
        {
            Console.Write("Blog ID:");
            string blogID = Console.ReadLine();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string query = $@"SELECT [BlogID]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog]
  where [BlogID]=@blogID";
            SqlCommand command2 = new SqlCommand(query, connection);
            command2.Parameters.AddWithValue("@blogID", blogID);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command2);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("no data found.");
                return;
            }
            DataRow dr = dt.Rows[0];
            Console.WriteLine(dr["BlogID"]);
            Console.WriteLine(dr["BlogTitle"]);
            Console.WriteLine(dr["BlogAuthor"]);
            Console.WriteLine(dr["BlogContent"]);
        }
        public void Update()
        {
            Console.WriteLine("Blog ID :");
            string blogID = Console.ReadLine();

            Console.WriteLine("Blog Title :");
            string title = Console.ReadLine();

            Console.WriteLine("Blog Author :");
            string author = Console.ReadLine();

            Console.WriteLine("Blog Content :");
            string content = Console.ReadLine();

            //  string connectionString2 = "Data Source=DESKTOP-AQCT4ER\\MSSQLSERVER2016;Initial Catalog=DotNetTraining;User ID=sa;Password=sasa;";

            SqlConnection connection = new SqlConnection(_connectionString);

            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] =@BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
      
 WHERE BlogID=@BlogID";
            connection.Open();
            SqlCommand command2 = new SqlCommand(query, connection);
            command2.Parameters.AddWithValue("@BlogTitle", title);
            command2.Parameters.AddWithValue("@BlogAuthor", author);
            command2.Parameters.AddWithValue("@BlogContent", content);
            command2.Parameters.AddWithValue("@BlogID", blogID);
            int result = command2.ExecuteNonQuery();
          

            connection.Close();

            Console.WriteLine(result == 1 ? "Update Successful..." : "Update Faileds....");
        }
        public void Delete()
        {
            Console.Write("Blog ID:");
            string blogID = Console.ReadLine();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string query = $@"Delete 
  FROM [dbo].[Tbl_Blog]
  where [BlogID]=@blogID";
            SqlCommand command2 = new SqlCommand(query, connection);
            command2.Parameters.AddWithValue("@blogID", blogID);
            int result = command2.ExecuteNonQuery();


            connection.Close();

            Console.WriteLine(result == 1 ? "Delete Successful..." : "Delete Faileds....");
        }
    }
}
