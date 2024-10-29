using Dapper;
using KSTDotNetCoreTraining.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace KSTDotNetCoreTraining.ConsoleApp
{
    public class DapperExample
    {
        private readonly string _connectionString = "Data Source=DESKTOP-AQCT4ER\\MSSQLSERVER2016;Initial Catalog=DotNetTraining;User ID=sa;Password=sasa;";

        public void Read()
        {
            //          using (IDbConnection db= new SqlConnection(_connectionString))
            //          {
            //              string query = @"SELECT [BlogID]
            //    ,[BlogTitle]
            //    ,[BlogAuthor]
            //    ,[BlogContent]
            //    ,[DeleteFlag]
            //FROM [dbo].[Tbl_Blog]";
            //              var lst = db.Query(query).ToList();
            //              foreach(var item in lst)
            //              {
            //                  Console.WriteLine(item.BlogID);
            //                  Console.WriteLine(item.BlogTitle);
            //                  Console.WriteLine(item.BlogAuthor);
            //                  Console.WriteLine(item.BlogContent);
            //                  Console.WriteLine(item.DeleteFlag);
            //              }
            //          }
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = @"SELECT [BlogID]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog]";
                var lst = db.Query<BlogDataModel>(query).ToList();
                foreach (var item in lst)
                {
                    Console.WriteLine(item.BlogID);
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogContent);
                    Console.WriteLine(item.DeleteFlag);
                }
            }
        }
        public void Create(String title, String author, String content)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent]
           ,[DeleteFlag])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent
           ,0)";
                int result = db.Execute(query, new BlogDataModel
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content,
                });
                Console.WriteLine(result == 1 ? "Saving Successful..." : "Saving Faileds....");

            }
        }
        public void Edit(int ID)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = @"SELECT [BlogID]
                ,[BlogTitle]
                ,[BlogAuthor]
                ,[BlogContent]
                ,[DeleteFlag]
            FROM [dbo].[Tbl_Blog] where BlogID=@BlogID";
                var item = db.Query<BlogDataModel>(query, new BlogDataModel { BlogID = ID }).FirstOrDefault();
                if (item is null)
                {
                    Console.WriteLine("No Data Found...");
                    return;
                }
                Console.WriteLine(item.BlogID);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine(item.DeleteFlag);

            }
        }
        public void Update(String title, String author, String content, int blogID)
        {

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
      WHERE BlogID=@BlogID ";
                int result = db.Execute(query, new BlogDataModel
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content,
                    BlogID = blogID,
                });
                Console.WriteLine(result == 1 ? "Update Successful..." : "Update Faileds....");

            }
        }
        public void Delete(int ID)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = @"DELETE
            FROM [dbo].[Tbl_Blog] where BlogID=@BlogID";
                int result = db.Execute(query, new BlogDataModel
                {
                    BlogID = ID
                });

                var item = db.Query<BlogDataModel>(query, new BlogDataModel { BlogID = ID }).FirstOrDefault();
                Console.WriteLine(result == 1 ? "Delete Successful..." : "Delete Faileds....");

            }
        }
    }
}
