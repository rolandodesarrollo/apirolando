using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace AxosnetWebApi.ServiceComponents
{
    public class BaseSC
    {
        public IRestResponse GetApiResponse(string queryStringURL)
        {
            var client = new RestClient(queryStringURL);
            var request = new RestRequest(Method.GET);
            //request.AddHeader("authorization", BindApiKey);
            IRestResponse response = client.Execute(request);
            return response;

        }

        public IRestResponse PostAPIResponse(string url)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            //request.AddHeader("authorization", BindApiKey);
            request.AddHeader("content-type", "application/json");
            IRestResponse response = client.Execute(request);
            return response;

        }

        public T DeserializeJson<T>(T dataType, string content) where T : class
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            return jsSerializer.Deserialize<T>(content);

        }

    }
}