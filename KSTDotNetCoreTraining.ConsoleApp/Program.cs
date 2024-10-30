// See https://aka.ms/new-console-template for more information
using KSTDotNetCoreTraining.ConsoleApp;
using System.Data;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

//Console.WriteLine("Hello, World!");
////Console.ReadLine();


//// md => markdown
//// control+. 

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create();
//adoDotNetExample.Edit();
//adoDotNetExample.Update();
//adoDotNetExample.Delete();
//DapperExample dapperExample = new DapperExample();
////dapperExample.Read();
////dapperExample.Create("abc","efg","111111111111111");
//dapperExample.Edit(1);
//dapperExample.Edit(7);
//dapperExample.Update("abc", "efg", "111111111111111",1);
//dapperExample.Delete(1);
EFCoreExample eF = new EFCoreExample();
//eF.Read();
//eF.Create("3333", "444", "aa");
//eF.Update("3333", "444", "aa",3);
eF.Delete(3);
Console.ReadKey();
