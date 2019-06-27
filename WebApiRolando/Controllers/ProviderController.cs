using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApiRolando.Backend;
using WebApiRolando.Models.Providers;

namespace WebApiRolando.Controllers
{
    public class ProviderController : ApiController
    {
        // GET: Provider
        public List<ProvidersDTO> GetAllProviders()
        {
            var providers = new ProviderSC().GetAllProvidersList();
            return providers;
        }

        [System.Web.Http.Route("api/Providersv2")]
        public List<ProvidersDTO> GetAllProviders2()
        {
            List<ProvidersDTO> providers = new List<ProvidersDTO>();
            return providers;
        }


        //http://localhost:56631/api/AddNewProvider?ProviderName=Bind&Telephone=392093023
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/AddNewProvider")]
        public long AddProvider(string ProviderName, string Telephone)
        {
            return new ProviderSC().AddNewProvider(ProviderName, Telephone);
        }
    }
}