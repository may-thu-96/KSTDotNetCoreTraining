using KSTDotNetCoreTraining.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSTDotNetCoreTraining.ConsoleApp
{
    public class EFCoreExample
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            var lst = db.blogs.Where(x => x.DeleteFlag == false).ToList();
            foreach (var item in lst)
            {
                Console.WriteLine(item.BlogID);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine(item.DeleteFlag);
            }
        }
        public void Create(String title, String author, String content)
        {
            BlogDataModel blog = new BlogDataModel
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            AppDbContext db = new AppDbContext();
            db.blogs.Add(blog);
            int result = db.SaveChanges();
            Console.WriteLine(result == 1 ? "Saving Successful..." : "Saving Faileds....");
        }
        public void Edit(int ID)
        {

            AppDbContext db = new AppDbContext();
            var item = db.blogs.FirstOrDefault(x => x.BlogID == ID);
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
        public void Update(String title, String author, String content, int blogID)
        {
            AppDbContext db = new AppDbContext();
            var item = db.blogs.AsNoTracking().FirstOrDefault(x => x.BlogID == blogID);
            if (item is null)
            {
                Console.WriteLine("No Data Found...");
                return;
            }

            if (!string.IsNullOrEmpty(title))
            {
                item.BlogTitle = title;
            }
            if (!string.IsNullOrEmpty(author))
            {
                item.BlogAuthor = author;
            }
            if (!string.IsNullOrEmpty(content))
            {
                item.BlogContent = content;
            }
            db.Entry(item).State = EntityState.Modified;
            int result = db.SaveChanges();
            Console.WriteLine(result == 1 ? "Update Successful..." : "Update Faileds....");
        }
        public void Delete(int ID)
        {

            AppDbContext db = new AppDbContext();
            var item = db.blogs.AsNoTracking().FirstOrDefault(x => x.BlogID == ID);
            if (item is null)
            {
                Console.WriteLine("No Data Found...");
                return;
            }
            db.Entry(item).State = EntityState.Deleted;
            int result = db.SaveChanges();
            Console.WriteLine(result == 1 ? "Delete Successful..." : "Delete Faileds....");
        }
    }
}
