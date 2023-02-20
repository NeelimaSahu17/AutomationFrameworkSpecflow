using AutomationFrameworkAmbition.Configuration;
using AutomationFrameworkAmbition.Handler;
using AutomationFrameworkAmbition.Pages;
using OpenQA.Selenium;

namespace AutomationFrameworkAmbition.StepDefinitions
{
    [Binding]
    public class UserVerificationStepDefinitions
    {
        private readonly IWebDriver _driver;
        private  readonly CommonHelpers _commonHelpers;
        private readonly ListUsers _listUsers;
        private readonly SingleUser _singleUser;
        private readonly CreateUser _createUser;
        private readonly UpdateUserByPUTMethod _updateUserPut;
        private readonly UpdateUserByPatchMethod __updateUserPatch;

        public UserVerificationStepDefinitions(IWebDriver driver, CommonHelpers commonHelpers, ListUsers listUsers, SingleUser singleUser, CreateUser createUser, UpdateUserByPUTMethod updateUserPut, UpdateUserByPatchMethod updateUserPatch)
        {
            _driver = driver;
            _commonHelpers = commonHelpers;
            _listUsers = listUsers;
            _singleUser = singleUser;
            _createUser = createUser;
            _updateUserPut = updateUserPut;
            __updateUserPatch = updateUserPatch;
        }

        #region Givens


        [Given(@"I have connected to Reqresclient")]
        public void GivenIHaveConnectedToReqresclient()
        {
            _commonHelpers.GetUserPageResponse();
        }

        #endregion

        #region Whens

        [When(@"I make a GET request to LIST USERS endpoint")]
        public void WhenIMakeAGETRequestToLISTUSERSEndpoint()
        {
            _listUsers.GetListOfUsersFromAllPages();
        }


        [When(@"I make a GET request to SINGLE USER endpoint by (.*)")]
        public void WhenIMakeAGETRequestToSINGLEUSEREndpointBy(int Id)
        {
           _singleUser.GetUserById(Id);

        }

        [When(@"I create a user ""([^""]*)"" ""([^""]*)"" using POST method on CREATE endpoint")]
        public void WhenICreateAUserUsingPOSTMethodOnCREATEEndpoint(string usename, string userjob)
        {
            _createUser.CreateUserPostMethod(usename,userjob);
        }

        [When(@"I have updated a user  ""([^""]*)"" ""([^""]*)"" using PUT method on UPDATE endpoint")]
        public void WhenIHaveUpdatedAUserUsingPUTMethodOnUPDATEEndpoint(string name, string job)
        {
            _updateUserPut.UpdateUserPUTMethod(name, job);
        }


        [When(@"I have updated a user ""([^""]*)"" ""([^""]*)"" using Patch method on UPDATE endpoint")]
        public void WhenIHaveUpdatedAUserUsingPatchMethodOnUPDATEEndpoint(string name, string job)
        {
            __updateUserPatch.UpdateUserByPATCHMethod(name, job);
        }

        [When(@"I create a user with already existing ""([^""]*)""")]
        public void WhenICreateAUserWithAlreadyExisting(string emailAddress)
        {
            _listUsers.GetListOfUsersFromAllPages();
        }

        #endregion

        #region Thens

        [Then(@"the user ""([^""]*)"" ""([^""]*)"" should be found")]
        public void ThenTheUserShouldBeFound(string firstName, string lastName)
        {
            _listUsers.CheckForAUserInListofUsers(firstName, lastName);
        }

        [Then(@"the user with (.*) should be found")]
        public void ThenTheUserWithShouldBeFound(int Id)
        {
            _singleUser.VaidateUserById(Id);
        }

  
        [Then(@"the user ""([^""]*)"" ""([^""]*)"" should be updated")]
        public void ThenTheUserShouldBeUpdated(string name, string job)
        {
            _updateUserPut.ValidateUserIsUpdated(name, job);
        }

        [Then(@"the user ""([^""]*)"" and ""([^""]*)"" should be updated")]
        public void ThenTheUserAndShouldBeUpdated(string name, string job)
        {
            __updateUserPatch.ValidateUserIsUpdatedByPatchMethod(name, job);
        }

        [Then(@"the user ""([^""]*)"" ""([^""]*)"" should be created")]
        public void ThenTheUserShouldBeCreated(string usename, string userjob)
        {
            _createUser.ValidateUserIsCreated(usename, userjob);
        }

        [Then(@"the user ""([^""]*)"" ""([^""]*)"" should should be created")]
        public void ThenTheUserShouldShouldBeCreated(string name, string job)
        {
            _createUser.ValidateUserIsCreated(name, job);
        }

        [Then(@"the user with ""([^""]*)"" should not be created")]
        public void ThenTheUserWithShouldNotBeCreated(string emailAddress)
        {
            _listUsers.CheckForUserEmailAddress(emailAddress);
        }

        #endregion

    }
}