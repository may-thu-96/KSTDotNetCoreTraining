// See https://aka.ms/new-console-template for more information
using KSTDotNetCoreTraining.ConsoleApp;
using System.Data;
using System.Data.SqlClient;

//Console.WriteLine("Hello, World!");
////Console.ReadLine();


//// md => markdown
//// control+. 

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create();
//adoDotNetExample.Edit();
//adoDotNetExample.Update();
adoDotNetExample.Delete();
Console.ReadKey();
