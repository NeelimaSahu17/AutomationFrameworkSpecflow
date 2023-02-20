using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Net;

namespace AutomationFrameworkAmbition.Pages
{
    [Binding]
    public class SingleUser
    {
        private string url;
        private RestClient client;
        private RestRequest restRequest;
        private RestResponse restResponse;

        public void GetApiResponse(int Id)
        {
            url = $"https://reqres.in/api/users/{Id}";
            client = new RestClient(url);
            restRequest = new RestRequest(url, Method.Get);
            restResponse = client.Execute(restRequest);
        }

        public void GetUserById(int Id)
        {
            GetApiResponse(Id);

            //verfying status code is 200 OK
            Assert.That(restResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var pageResponse = JsonConvert.DeserializeObject(restResponse.Content);

            //verfying the response is not null
            Assert.That(pageResponse, Is.Not.Null);

        }
        public void VaidateUserById(int Id)
        {
            // verify the userid is equal to 2
            var apiResponse = JsonConvert.DeserializeObject<SingleUserResponseObject>(restResponse.Content);
            Assert.IsTrue(apiResponse.data.id.Equals(Id));

            Console.WriteLine(string.Format("{0} \n {1} \n {2} \n {3}", apiResponse.data.id, apiResponse.data.email, apiResponse.data.first_name, apiResponse.data.last_name));
        }

        public class SingleUserResponseObject
        {
            public Data data { get; set; }
            public Support support { get; set; }
        }

        public class Data
        {
            public int id { get; set; }
            public string email { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string avatar { get; set; }
        }

        public class Support
        {
            public string url { get; set; }
            public string text { get; set; }
        }
    }

}
