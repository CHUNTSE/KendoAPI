using Dapper;
using KendoAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace KendoAPI.Controllers
{
    [RoutePrefix("Kendo")]
    [EnableCorsAttribute("*", "*", "*")]
    public class ValuesController : ApiController
    {
        [Route("")]
        [HttpGet]
        public IEnumerable<Products> Get()
        {
            var db = new SqlConnection(
                     ConfigurationManager
                     .ConnectionStrings["db"]
                     .ConnectionString);

            var items = db.Query<Products>("SELECT * FROM Car_Brand ORDER BY Id DESC");
            //"SELECT * FROM Products ORDER BY ProductID DESC");

            return items;
        }

        //[Route("{id}")]
        //[HttpGet]
        //public IHttpActionResult Get(string id)
        //{
        //    var db = new SqlConnection(
        //             ConfigurationManager
        //             .ConnectionStrings["db"]
        //             .ConnectionString);

        //    var items = db.Query<Products>(
        //        "SELECT * FROM Products WHERE ProductID = @id", new
        //        {
        //            id = id
        //        });

        //    var item = items.FirstOrDefault();

        //    if (item == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        return Content(HttpStatusCode.OK, item);
        //    }
        //}

        //[Route("")]
        //[HttpPost]
        //public void Post([FromBody] Products item)
        //{
        //    var db = new SqlConnection(
        //             ConfigurationManager
        //             .ConnectionStrings["db"]
        //             .ConnectionString);

        //    db.Execute(
        //        "INSERT INTO Products (ProductID, CategoryID, ProductName, Stock, UnitPrice, Size, Color, Instructions, Path)" +
        //        "VALUES (@productID, @categoryID, @productName, @stock, @unitPrice, @size, @color, @instructions, @path)", new
        //        {
        //            productID = item.ProductID,
        //            categoryID = item.CategoryID,
        //            productName = item.ProductName,
        //            stock = item.Stock,
        //            unitPrice = item.UnitPrice,
        //            size = item.Size,
        //            color = item.Color,
        //            instructions = item.Instructions,
        //            path = item.Path
        //        });
        //}

        //[Route("{id}/productName")]
        //[HttpPatch]
        //public void UpdateTodoTitle(string id, [FromBody] Products item)
        //{
        //    var db = new SqlConnection(
        //             ConfigurationManager
        //             .ConnectionStrings["db"]
        //             .ConnectionString);

        //    db.Execute(
        //        "UPDATE Products " +
        //        "SET ProductName = @productName " +
        //        "WHERE ProductID = @id", new
        //        {
        //            id,
        //            productName = item.ProductName
        //        });
        //}

        //[Route("{id}")]
        //[HttpDelete]
        //public void Delete(string id)
        //{
        //    var db = new SqlConnection(
        //             ConfigurationManager
        //             .ConnectionStrings["db"]
        //             .ConnectionString);

        //    db.Execute(
        //        "DELETE FROM Products " +
        //        "WHERE ProductID = @id", new
        //        {
        //            id = id,
        //        });
        //}
    }
}
