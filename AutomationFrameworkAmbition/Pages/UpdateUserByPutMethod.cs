using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;

namespace AutomationFrameworkAmbition.Pages
{
    [Binding]
    public  class UpdateUserByPUTMethod
    {
        private string url = "https://reqres.in/api/users/2";
        private RestClient restClient;
        private RestRequest restRequest;
        private RestResponse restResponse;

        public void UpdateUserPUTMethod(string username, string userjob)
        {
            var userRequest = new RootObj
            {
             
             name= username,
             job = userjob
            };

            string payload = JsonConvert.SerializeObject(userRequest);
            restClient = new RestClient(url);
            restRequest = new RestRequest(url, Method.Put).AddJsonBody(payload);

            restResponse = restClient.Execute(restRequest);
            if (!restResponse.IsSuccessful)
            {
                TestContext.WriteLine("Response is unsuccessful,please verify");
            }
        }

        public void ValidateUserIsUpdated(string username, string userjob)
        {
            var deserializedObject = JsonConvert.DeserializeObject<RootObj>(restResponse.Content);
            Assert.IsTrue(deserializedObject.name.Equals(username) && (deserializedObject.job.Equals(userjob)));
            Console.WriteLine("Username :" + deserializedObject.name);
            Console.WriteLine("Userjob :" + deserializedObject.job);
        }
    }

    public class RootObj
    {
        public string name { get; set; }
        public string job { get; set; }
    }

}
