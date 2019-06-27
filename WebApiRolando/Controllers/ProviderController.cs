using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace WebApiRolando.Controllers
{
    public class ProviderController : ApiController
    {
        // GET: Provider
        public ActionResult GetAllProviders()
        {
            return View();
        }
    }
}