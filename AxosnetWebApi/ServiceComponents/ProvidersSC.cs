using AxosnetWebApi.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace AxosnetWebApi.ServiceComponents
{
    public class ProvidersSC : BaseSC
    {
        public List<ProviderVM> GetAllProviders()
        {
            var providersjson = GetApiResponse("http://apirolando.azurewebsites.net/api/provider");
            var providers = DeserializeJson(new List<ProviderVM>(), providersjson.Content);
            return providers;
        }

        public string AddNewProvider(string ProviderName, string Telephone)
        {
            var url = "http://apirolando.azurewebsites.net/api/AddNewProvider?ProviderName=" + ProviderName + "&Telephone=" + Telephone;
            IRestResponse response = PostAPIResponse(url);
            try
            {
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                var r = jsSerializer.Deserialize<RequestMessage>(response.Content);

                if (r.code != "200")
                {
                    return r.message;
                }
            }
            catch (Exception)
            {

            }

            return "";
        }
    }
}