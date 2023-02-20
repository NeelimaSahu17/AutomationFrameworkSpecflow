Feature: User verification

Scenario 1 - Verify that the user exists by quering the "LIST USERS" endpoint using GET method.
Scenario 2 - Search for a user using UserID by quering the "SINGLE USER" endpoint using GET method.
Scenario 3 - Create a user using Post method on "CREATE" endpoint
Scenario 4 - Update a user using Put method on "UPDATE" endpoint
Scenario 5 - Update a user using Patch method on "UPDATE" endpoint
Negative Scenario - Attempting to create a user that already exists

@verifyuser
Scenario Outline: Verify that user exists in “List Users” endpoint
	Given I have connected to Reqresclient
	When  I make a GET request to LIST USERS endpoint
	Then  the user <Firstname> <Lastname> should be found
		
	Examples:
	| Firstname  | Lastname   |
	| "Lindsay"  | "Ferguson" |

@singleuser
Scenario Outline: Search for a User using UserID in "SINGLE USER" endpoint
	Given I have connected to Reqresclient
	When  I make a GET request to SINGLE USER endpoint by <UserId>
	Then  the user with <UserId> should be found
	Examples:
	| UserId  |
	| 2       |

@createuser
Scenario Outline: Create a user using Post method on "CREATE" endpoint
	Given I have connected to Reqresclient
	When  I create a user <Name> <Job> using POST method on CREATE endpoint
	Then  the user <Name> <Job> should be created
	Examples:
	| Name       | Job		|
	| "morpheus" | "leader" |

@updateuserbyputmethod
Scenario Outline: Update a user using Put method on "Update" endpoint
	Given I have connected to Reqresclient
	When  I have updated a user  <Name> <Job> using PUT method on UPDATE endpoint
	Then  the user <Name> <Job> should be updated
	Examples:
	| Name       | Job			   |
	| "morpheus" | "zion resident" |


@updateuserbypatchmethod
Scenario Outline: Update a user using Patch method on "Update" endpoint
	Given I have connected to Reqresclient
	When  I have updated a user <Name> <Job> using Patch method on UPDATE endpoint
	Then  the user <Name> and <Job> should be updated
	Examples:
	| Name       | Job			   |
	| "morpheus" | "zion resident" |


@negativescenario
Scenario Outline: Negative Scenario - create a user with email address already exits
	Given I have connected to Reqresclient
	When  I create a user with already existing <EmailAddress>
	Then  the user with <EmailAddress> should not be created
	Examples:
	| EmailAddress			  |
	| "byron.fields@reqres.in"|
