using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace AxosnetWebApi.Controllers
{
    public class BaseController : Controller
    {

        public IRestResponse GetApiResponse(string queryStringURL)
        {
            var client = new RestClient(queryStringURL);
            var request = new RestRequest(Method.GET);
            //request.AddHeader("authorization", BindApiKey);
            IRestResponse response = client.Execute(request);
            return response;

        }


        public T DeserializeJson<T>(T dataType, string content) where T: class
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            return jsSerializer.Deserialize<T>(content);
             
        }

        public JsonNetResult GetJsonNetResult(object data)
        {
            JsonNetResult jsonNetResult = new JsonNetResult();
            jsonNetResult.Formatting = Formatting.Indented;
            jsonNetResult.Data = data;
            return jsonNetResult;

        }

        public object SerializeJSONData(object data)
        {
            var result = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.None,
            new Newtonsoft.Json.JsonSerializerSettings
            {
                StringEscapeHandling =
                Newtonsoft.Json.StringEscapeHandling.EscapeHtml
            });

            return result;
        }
    }
}