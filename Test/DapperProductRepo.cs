using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
	public class DapperProductRepo : IProductRepo
	{
		private readonly IDbConnection _connection;

        public DapperProductRepo(IDbConnection connection)
        {
			_connection = connection;
        }
        public void CreateProduct(string name, double price, int categoryID)
		{
			_connection.Execute("INSERT INTO Products (Name, Price, CategoryID) VALUES (@name, @price, @categoryID);",
				new { name = name, price = price, categoryID = categoryID }) ;
		}

		public IEnumerable<Product> GetAllProducts()
		{
			return _connection.Query<Product>("SELECT * FROM Products;");
		}

		public void UpdateProductName(int productID, string updatedName)
		{
			_connection.Execute("UPDATE Products SET Name = @updatedName WHERE ProductID = @productID;",
				new { updatedName = updatedName, productID = productID });
		}

		public void DeleteProduct(int productID)
		{
			_connection.Execute("DELETE FROM Reviews WHERE ProductID = @productID;",
				new { productID = productID });

			_connection.Execute("DELETE FROM Sales WHERE ProductID = @productID;",
				new { productID = productID });

			_connection.Execute("DELETE FROM Products WHERE ProductID = @productID;",
				new { productID = productID });
		}
	}
}
