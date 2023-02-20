AutomationFrameworkSpecflow Project

Overview - This framework uses SpecFlow which is a testing framework that supports Behaviour Driven Development (BDD).
In order to consume API I have used REST Sharp available as a NuGet package, it provides methods to send 
and receive data from the server, the project version is .Net6.0. This framework covers the following scenarios -
	
	Scenario 1 - Verify that the user exists by querying the "LIST USERS" endpoint using GET method.
	Scenario 2 - Search for a user using UserID by querying the "SINGLE USER" endpoint using GET method.
	Scenario 3 - Create a user using Post method on "CREATE" endpoint
	Scenario 4 - Update a user using Put method on "UPDATE" endpoint
	Scenario 5 - Update a user using Patch method on "UPDATE" endpoint
	Negative Scenario - Attempting to create a user that already exists
	
Framework Structure-

	1. Feature files - I have defined all the test scenarios using the Gherkin syntax (Given – When – Then) 
	in the feature files, used Scenario Outline to provide multiple outputs with minimal changes
	2. Pages - It has methods to test - CreateUser, ListUsers, SingleUser, UpdateUser
	3. Helpers - Common methods are kept under the helper folder, these methods are reusable and used in the entire framework
	4. StepDefinition - It has all the implementation of test scenarios available under feature file 
	5. Configuration - Driver initialization, before and after hooks are defined in the Hooks folder
	6. AppConfig - It has all the environments configuration, testdata and connection string. I have used Slow Cheetah extension to have 
	different appSettings for debug, Test, SIT, PreProd and release.

Nuget Packages installed
![image](https://user-images.githubusercontent.com/125847607/220032418-0c3675b7-c0ee-4b10-ada8-b8307e039fac.png)

![image](https://user-images.githubusercontent.com/125847607/220035249-95db9b1d-1f1d-4840-9c3e-d46b4562ec56.png)

