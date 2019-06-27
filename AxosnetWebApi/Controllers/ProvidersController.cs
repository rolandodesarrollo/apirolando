using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AxosnetWebApi.Controllers
{
    public class ProvidersController : Controller
    {
        // GET: Providers
        public ActionResult ProvidersList()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");


            return View();
        }
    }
}