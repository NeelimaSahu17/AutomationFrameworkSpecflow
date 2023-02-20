using Newtonsoft.Json;
using RestSharp;

using NUnit.Framework;
using System.Net;
using System.Configuration;
using AutomationFrameworkAmbition.Pages;

namespace AutomationFrameworkAmbition.Handler
{
    [Binding]
    public class CommonHelpers
    {
        private readonly string url = "https://reqres.in";
        private static readonly string GetReqresUrl = ConfigurationManager.AppSettings["ReqresUrl"];

        public void GetUserPageResponse()
        {
            var client = new RestClient(url);
            var request = new RestRequest("/api/users/", Method.Get);
            var restResponse = client.Execute(request);

            //verfying status response is 200 
            Assert.That(restResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var userPageResponse = JsonConvert.DeserializeObject(restResponse.Content);

            //verfying userdata is not null
            Assert.That(userPageResponse, Is.Not.Null);

        }
    }

}
