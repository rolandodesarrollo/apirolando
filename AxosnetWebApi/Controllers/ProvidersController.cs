using AxosnetWebApi.Models;
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
            var providersjson = GetApiResponse("http://apirolando.azurewebsites.net/api/provider");
            var providers = DeserializeJson(new List<ProviderVM>(), providersjson.Content);
            return GetJsonNetResult(providers);
        }
    }
}