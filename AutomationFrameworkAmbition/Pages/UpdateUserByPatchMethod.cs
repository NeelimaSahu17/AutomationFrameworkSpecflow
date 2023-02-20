using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;

namespace AutomationFrameworkAmbition.Pages
{
    [Binding]
    public class UpdateUserByPatchMethod
    {
        private string url = "https://reqres.in/api/users/2";
        private RestClient restClient;
        private RestRequest restRequest;
        private RestResponse restResponse;

        public void UpdateUserByPATCHMethod(string username, string userjob)
        {
            var userRequest = new RootObj
            {
                name = username,
                job = userjob
            };

            string payload = JsonConvert.SerializeObject(userRequest);
            restClient = new RestClient(url);
            restRequest = new RestRequest(url, Method.Patch).AddJsonBody(payload);

            restResponse = restClient.Execute(restRequest);
            if (!restResponse.IsSuccessful)
            {
                TestContext.WriteLine("Response is unsuccessful,please verify");
            }
        }

        public void ValidateUserIsUpdatedByPatchMethod(string username, string userjob)
        {
            var deserializedObject = JsonConvert.DeserializeObject<PatchPayload>(restResponse.Content);
            Assert.IsTrue(deserializedObject.name.Equals(username) && (deserializedObject.job.Equals(userjob)));
            Console.WriteLine("Username :" + deserializedObject.name);
            Console.WriteLine("Userjob :" + deserializedObject.job);
        }
    }

    public class PatchPayload
    {
        public string name { get; set; }
        public string job { get; set; }
    }
}
