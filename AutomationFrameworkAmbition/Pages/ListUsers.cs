using Newtonsoft.Json;
using NUnit.Framework;


namespace AutomationFrameworkAmbition.Pages
{
    [Binding]

    public class ListUsers
    {
        public string id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }
        public string response { get; set; }

        public List<ListUsers> listofUsers = new List<ListUsers>();

        /// <summary>
        /// Getting list of users from all the pages, there are  two pages
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ListUsers>> GetListOfUsersFromAllPages()
        {
            listofUsers = new List<ListUsers>();
            var url = "https://reqres.in/api/users";
            int currentPage = 1;
            int totalPages = 0;
            var nextUrl = $"{url}?page={currentPage}";

            using (var webClient = new HttpClient())
            {
                do
                {
                    HttpResponseMessage response = webClient.GetAsync(nextUrl).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        var pageResponse = JsonConvert.DeserializeObject<PageResponse>(json);

                        if (pageResponse != null && pageResponse.data.Any())
                        {
                            listofUsers.AddRange((IEnumerable<ListUsers>)pageResponse.data);
                            totalPages = pageResponse.total_pages;

                            currentPage++;
                            nextUrl = $"{url}?page={currentPage}";
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                } while (currentPage <= totalPages);
            }
            return listofUsers;
        }

        /// <summary>
        /// Checking for a particular user in a list of users
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        public void CheckForAUserInListofUsers(string firstName, string lastName)
        {
            bool userFound = false;
            foreach (var user in listofUsers)
            {

                if (user.first_name.Contains(firstName) && (user.last_name.Contains(lastName)))
                {
                    Assert.IsTrue(true);
                    userFound = true;
                    Console.WriteLine("User " + firstName + " " + lastName + " exists in the list of users");
                    break;
                }
            }

            if (!userFound)
            {
                Assert.Fail();
                Console.WriteLine("User " + firstName + lastName + " does not exists in the list of users. please check!");
            }
        }

        public void CheckForUserEmailAddress(string emailAddress)
        {
            bool emailIdExists = false;
            foreach (var userEmailId in listofUsers)
            {
                if (userEmailId.email.Equals(emailAddress))
                {
                    emailIdExists = true;
                    Console.WriteLine("User EmailId " + emailAddress + "  already exists");
                    break;
                }
            }

            if (!emailIdExists)
            {
                Console.WriteLine("User EmailId " + emailAddress + " does not exists");
            }
        }

        public class PageResponse
        {
            public int page { get; set; }

            [JsonProperty("per_page")]
            public int per_page { get; set; }
            public int total { get; set; }

            [JsonProperty("total_pages")]
            public int total_pages { get; set; }
            public List<ListUsers> data { get; set; }
        }

        public class Root
        {
            public PageResponse response { get; set; }
            public Support support { get; set; }
        }

        public class Support
        {
            public string url { get; set; }
            public string text { get; set; }
        }
    }
}



