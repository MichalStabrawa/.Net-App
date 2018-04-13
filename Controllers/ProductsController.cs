using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ASPNET.Models;
using ASPNET.Repository;
using Microsoft.AspNetCore.Mvc;

public class ProductsController : Controller
{

    [HttpGet]
    public ViewResult GetAllProducts(string sortBy,string searchP,int page)
    {
        ProductsRepository repo1=new ProductsRepository();
        ViewData["currentpage"]=page;
        ViewData["products"]=repo1.GetAllProducts(sortBy,searchP,page);
        ViewData["sortBy"]=sortBy;
        return View();   

    }

    [HttpGet]
    public ViewResult AddProductForm()
    {
        return View();
    }

    [HttpPost]
    public void AddProduct([FromForm]Product p)
    {
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = "Server=LAPTOP-2AOO7D4S\\SQLEXPRESS;Database=TSQL2012;Trusted_Connection=True;";
        connection.Open();
        SqlCommand command = new SqlCommand();
        command.CommandType = CommandType.Text;

        command.CommandText = $"exec [dbo].[addProduct]  '{p.ProductName}',{p.SupplierID},{p.CategoryID},{p.UnitPrice} ,{p.Discontinued}";//,
        command.Connection = connection;
        command.ExecuteNonQuery();//dodowanie do sql

    }





    public string getSomeText()
     {
        return "ale ma kota";
    }

    public string[] getSomeArray()
    {
        return new string[] { "pierwszy string" };
   }

     public string[] GetVeggies()
      {
         return new string[]{
     "pomidor",
    "marchew",
   "jablko"
    };
    }

    


}

