using AxosnetWebApi.Models;
using AxosnetWebApi.ServiceComponents;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace AxosnetWebApi.Controllers
{
    public class ProvidersController : BaseController
    {
        // GET: Providers
        public ActionResult ProvidersList()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");


            return View();
        }

        public ActionResult GetAllProviders()
        {
            var providers = new ProvidersSC().GetAllProviders();
            return GetJsonNetResult(providers);
        }

        public ActionResult AddNewProvider(string ProviderName, string Telephone)
        {
            var response = new ProvidersSC().AddNewProvider(ProviderName, Telephone);
            return GetJsonNetResult(response);
        }
    }
}