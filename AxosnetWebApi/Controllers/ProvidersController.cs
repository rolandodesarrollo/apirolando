using AxosnetWebApi.Models;
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
            var providersjson = GetApiResponse("http://apirolando.azurewebsites.net/api/provider");
            var providers = DeserializeJson(new List<ProviderVM>(), providersjson.Content);
            return GetJsonNetResult(providers);
        }

        public ActionResult AddNewProvider(string ProviderName, string Telephone)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            var client = new RestClient("http://apirolando.azurewebsites.net/api/AddNewProvider?ProviderName=" +ProviderName +"&Telephone=" +Telephone);
            var request = PostAPIResponse(client);
          
           
            IRestResponse response = client.Execute(request);

            try
            {
                var r = jsSerializer.Deserialize<RequestMessage>(response.Content);

                if (r.code != "200")
                {
                    return GetJsonNetResult(r.message);
                }
            }
            catch (Exception)
            {

            }

            return GetJsonNetResult(null);
        }
    }
}