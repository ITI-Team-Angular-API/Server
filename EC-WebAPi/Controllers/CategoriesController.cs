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
    public class CategoriesController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                    select Id, Name from
                    dbo.Categories
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


        public string Post(Categories categories)
        {
            try
            {
                string query = @"
                    insert into dbo.Categories values
                    ('" + categories.Name + @"')
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

        public string Put(Categories categories)
        {
            try
            {
                string query = @"
                    update dbo.Categories set Name=
                    '" + categories.Name + @"'
                    where Id =" + categories.Id + @"
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
                    delete from dbo.Categories 
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
    }
}
