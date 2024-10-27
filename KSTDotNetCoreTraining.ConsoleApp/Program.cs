// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");
//Console.ReadLine();


// md => markdown
// control+. 

string connectionString = "Data Source=DESKTOP-AQCT4ER\\MSSQLSERVER2016;Initial Catalog=DotNetTraining;User ID=sa;Password=sasa;";
Console.WriteLine("Connection String:" + connectionString);
SqlConnection connection = new SqlConnection(connectionString);
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

