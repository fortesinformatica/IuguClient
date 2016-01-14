Feature: Client CRUD

Scenario: Client creation
	Given a Client
	When I send the client data
	Then the request should be a POST
	And should send Json object into the body
	And the url should end with "/customers"
	And should return a Client created
