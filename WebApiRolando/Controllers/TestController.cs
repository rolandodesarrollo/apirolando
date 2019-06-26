using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApiRolando.Models;

namespace WebApiRolando.Controllers
{
    public class TestController : ApiController
    {
        // GET: Test
        public List<DataTestVM> GetTestData()
        {
            var result = new List<DataTestVM>();
            result.Add(new DataTestVM() { Text = "Uno", Value = 1 });
            result.Add(new DataTestVM() { Text = "Dos", Value = 2 });
            result.Add(new DataTestVM() { Text = "Tres", Value = 3 });
            return result;
        }


        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/GetAllData2")]
        public List<DataTestVM> GetAllData()
        {
            var result = new List<DataTestVM>();
            result.Add(new DataTestVM() { Text = "Cuatro", Value = 4 });
            result.Add(new DataTestVM() { Text = "Cinco", Value = 5 });
            result.Add(new DataTestVM() { Text = "Seis", Value = 6 });
            return result;
        }
    }
}