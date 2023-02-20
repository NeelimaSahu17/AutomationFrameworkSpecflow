using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;

namespace AutomationFrameworkAmbition.Pages
{
    [Binding]
    public class CreateUser
    {
        private string url = "https://reqres.in/api/users";
        private RestClient restClient;
        private RestRequest restRequest;
        private RestResponse restResponse;

        public void CreateUserPostMethod(string username, string userjob)
        {
            var userRequest = new UserRequest
            {
                name = username,
                job = userjob,
            };

            string payload = JsonConvert.SerializeObject(userRequest);
            restClient = new RestClient(url);
            restRequest = new RestRequest(url, Method.Post).AddJsonBody(payload);
            restResponse = restClient.Execute(restRequest);
            if (!restResponse.IsSuccessful)
            {
                TestContext.WriteLine("Response is unsuccessful,please verify");
            }
        }

        public void ValidateUserIsCreated(string username, string userjob)
        {
            var deserializedObject = JsonConvert.DeserializeObject<UserResponse>(restResponse.Content);
            Assert.IsTrue(deserializedObject.name.Equals(username) && (deserializedObject.job.Equals(userjob)));
            Console.WriteLine("UserId :" + deserializedObject.id);
        }
    }

    public class UserRequest
    {
        public string name { get; set; }
        public string job { get; set; }
    }

    public class UserResponse
    {
        public string name { get; set; }
        public string job { get; set; }
        public string id { get; set; }
        public DateTime createdAt { get; set; }
    }
}
