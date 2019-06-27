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
    }
}