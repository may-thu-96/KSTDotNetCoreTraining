// See https://aka.ms/new-console-template for more information
using KSTDotNetCoreTraining.ConsoleApp;
using System.Data;
using System.Data.SqlClient;

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
DapperExample dapperExample = new DapperExample();
//dapperExample.Read();
//dapperExample.Create("abc","efg","111111111111111");
dapperExample.Edit(1);
dapperExample.Edit(7);
dapperExample.Update("abc", "efg", "111111111111111",1);
dapperExample.Delete(1);
Console.ReadKey();
