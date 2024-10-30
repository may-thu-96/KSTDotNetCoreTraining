using KSTDotNetCoreTraining.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSTDotNetCoreTraining.ConsoleApp
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                string connectionString = "Data Source=DESKTOP-AQCT4ER\\MSSQLSERVER2016;Initial Catalog=DotNetTraining;User ID=sa;Password=sasa;TrustServerCertificate=true;";
                optionsBuilder.UseSqlServer(connectionString);
                
            }
        }
        public DbSet<BlogDataModel> blogs { get; set; }
    }
}
