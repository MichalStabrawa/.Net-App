using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ASPNET.Models;

namespace ASPNET.Repository{
    class ProductsRepository{
      public List<Product> GetAllProducts(string sortBy,string searchPhrase,int page)
        {
            List<Product> products = new List<Product>();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server=LAPTOP-2AOO7D4S\\SQLEXPRESS;Database=TSQL2012;Trusted_Connection=True;";
            connection.Open();

            SqlCommand command = new SqlCommand();

            if (sortBy == null)
            {
                sortBy = "ProductName";
            }
            command.CommandType = CommandType.Text;
            command.CommandText = $"SELECT * FROM GetAllProducts where productname like '%{searchPhrase}%' order by {sortBy} offset {page * 10} rows fetch next 10 rows only";
            command.Connection = connection;
            SqlDataReader reader = command.ExecuteReader();

            List<Product> productNames = new List<Product>();
            while (reader.Read())
            {
                Product temp = new Product();
                temp.ProductID = int.Parse(reader["productid"].ToString());
                temp.ProductName = reader["productName"].ToString();
                temp.CategoryID = int.Parse(reader["categoryid"].ToString());
                temp.UnitPrice = double.Parse(reader["unitprice"].ToString());
                productNames.Add(temp);
            }
            return productNames;
        }
    }
}