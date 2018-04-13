using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ASPNET.Models;
using Microsoft.AspNetCore.Mvc;

public class CategoryController : Controller
{
    public List<Category> GetAllCategory(string searchedPhrase)
    {
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = "Server=LAPTOP-2AOO7D4S\\SQLEXPRESS;Database=TSQL2012;Trusted_Connection=True;";
        connection.Open();
        SqlCommand command = new SqlCommand();

        command.CommandType = CommandType.Text;
        command.CommandText = $"SELECT categoryname,categoryid FROM Production.Categories ";
        command.Connection = connection;

        SqlDataReader reader = command.ExecuteReader();

        List<Category> listCategory = new List<Category>();
        while (reader.Read())
        {
            Category temp = new Category();
            temp.Id = int.Parse(reader["categoryid"].ToString());
            temp.CategoryName = reader["categoryName"].ToString();

            listCategory.Add(temp);
        }

        return listCategory;
    }
}