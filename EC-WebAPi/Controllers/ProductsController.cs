using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EC_WebAPi.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;

namespace EC_WebAPi.Controllers
{
    public class ProductsController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                    select Id, Name, Details, Price, Image, Quantity, CategoryId from
                    dbo.Products
                   ";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["ECommerceApp"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var data = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                data.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(Products products)
        { 
            try
            {

                string query = @"
                    insert into dbo.Products values
                    (
                      '" + products.Name + @"'
                      ,'" + products.Details + @"'
                      ," + products.Price + @"
                      ,'" + products.Image + @"'
                      ," + products.Quantity + @"
                      ," + products.CategoryId + @"
                    )
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["ECommerceApp"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var data = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    data.Fill(table);
                }

                return "Added Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Add!!";
            }
        }

        public string Put(Products products)
        {
            try
            {
                string query = @"
                    update dbo.Products set 
                    Name='" + products.Name + @"'
                    ,Details='" + products.Details + @"'
                    ,Price='" + products.Price + @"'
                    ,Image='" + products.Image + @"'
                    ,Quantity='" + products.Quantity + @"'
                    ,CategoryId='" + products.CategoryId + @"'
                    where Id =" + products.Id + @"
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["ECommerceApp"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var data = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    data.Fill(table);
                }

                return "Updated Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Update!!";
            }
        }


        public string Delete(int Id)
        {
            try
            {
                string query = @"
                    delete from dbo.Products 
                    where Id=" + Id + @"
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["ECommerceApp"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var data = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    data.Fill(table);
                }

                return "Deleted Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Delete!!";
            }
        }


        [Route("api/Products/GetAllCategoriesNames")]
        [HttpGet]
        public HttpResponseMessage GetAllCategoriesNames()
        {
            string query = @"
                    select Name from dbo.Categories";

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["ECommerceApp"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var data = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                data.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }


        /* To Upload Photos*/
        //[Route("api/Poducts/SaveFile")]
        //public string SaveFile()
        //{
        //    try
        //    {
        //        var httpRequest = HttpContext.Current.Request;
        //        var postedFile = httpRequest.Files[0];
        //        string Image = postedFile.FileName;
        //        var physicalPath = HttpContext.Current.Server.MapPath("~/Images/" + Image);

        //        postedFile.SaveAs(physicalPath);

        //        return Image;
        //    }
        //    catch (Exception)
        //    {

        //        return "anonymous.jpg";
        //    }
        //}
    }
}
