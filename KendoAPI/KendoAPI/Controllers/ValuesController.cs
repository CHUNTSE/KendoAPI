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

            var items = db.Query<Products>("SELECT * FROM Car_Brand ORDER BY F10400 DESC");
            //"SELECT * FROM Products ORDER BY ProductID DESC");

            return items;
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            var db = new SqlConnection(
                     ConfigurationManager
                     .ConnectionStrings["db"]
                     .ConnectionString);

            var items = db.Query<Products>(
                //"SELECT * FROM Products WHERE ProductID = @id",
                "SELECT * FROM Car_Brand WHERE F10400 = @f10400",
                new
                {
                    f10400 = id
                });

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return NotFound();
            }
            else
            {
                return Content(HttpStatusCode.OK, item);
            }
        }

        [Route("")]
        [HttpPost]
        public void Create([FromBody] Products item)
        {
            var db = new SqlConnection(
                     ConfigurationManager
                     .ConnectionStrings["db"]
                     .ConnectionString);

            db.Execute("INSERT INTO Car_Brand (Id, F10400, F10401)" +
                       " VALUES (@id, @f10400 ,@f10401)", new
                       {
                           id = item.Id,
                           f10400 = item.F10400,
                           f10401 = item.F10401
                       });
            //"INSERT INTO Products (ProductID, CategoryID, ProductName, Stock, UnitPrice, Size, Color, Instructions, Path)" +
            //"VALUES (@productID, @categoryID, @productName, @stock, @unitPrice, @size, @color, @instructions, @path)", new
            //{
            //    productID = item.ProductID,
            //    categoryID = item.CategoryID,
            //    productName = item.ProductName,
            //    stock = item.Stock,
            //    unitPrice = item.UnitPrice,
            //    size = item.Size,
            //    color = item.Color,
            //    instructions = item.Instructions,
            //    path = item.Path
            //});
        }

        [Route("{id}")]
        [HttpPatch]
        public void Update(string id , [FromBody] Products item)
        {
            var db = new SqlConnection(
                     ConfigurationManager
                     .ConnectionStrings["db"]
                     .ConnectionString);

            db.Execute("UPDATE Car_Brand SET Id = @id, F10401 = @f10401 WHERE F10400 = @f10400",
                        new
                        {
                            id = item.Id,
                            f10400 = id,
                            f10401 = item.F10401
                        });
            //"UPDATE Products SET ProductName = @productName WHERE ProductID = @productID", new
            //{
            //    productID = id,
            //    productName = item.ProductName
            //});
        }


        //public HttpResponseMessage Delete(string id)
        //{
        //    var db = new SqlConnection(
        //             ConfigurationManager
        //             .ConnectionStrings["db"]
        //             .ConnectionString);

        //    db.Execute(
        //        "DELETE FROM Car_Brand " +
        //        "WHERE F10400 = @f10400", new
        //        {
        //            f10400 = id,
        //        });
        //    return Request.CreateResponse(HttpStatusCode.OK,id);
        //}
        [Route("{id}")]
        [HttpDelete]
        public void Delete(string id)
        {
            var db = new SqlConnection(
                     ConfigurationManager
                     .ConnectionStrings["db"]
                     .ConnectionString);

            db.Execute(
                "DELETE FROM Car_Brand " +
                "WHERE F10400 = @f10400", new
                {
                    f10400 = id,
                });
        }
    }
}
