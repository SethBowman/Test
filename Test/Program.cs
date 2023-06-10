using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using Test;
//^^^^MUST HAVE USING DIRECTIVES^^^^

var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);

//var repo = new DapperDepartmentRepo(conn);

//Console.Write("Type a new Department name: ");

//var newDepartment = Console.ReadLine();

//repo.InsertDepartment(newDepartment);

//var departments = repo.GetAllDepartments();

//foreach(var dept in departments)
//{
//    Console.WriteLine(dept.Name);
//}

var productRepo = new DapperProductRepo(conn);

//productRepo.UpdateProductName(941, "Seth's Better Product");
//productRepo.DeleteProduct(941);
//productRepo.CreateProduct("Seth's Product", 1500.00, 3);

var products = productRepo.GetAllProducts();

foreach (var product in products)
{
    Console.WriteLine($"{product.Name} | {product.Price} | {product.ProductID}");
}

