Feature: Client CRUD

Scenario: Client creation async
	Given a Client
	When I request the client to be added
	Then the request should be a POST
	And should send Json object into the body
	And the url should end with "/customers"
	And should return a Client created

Scenario: Client creation sync
	Given a Client
	When I request the client to be added sync
	Then the request should be a POST 
	And should send Json object into the body
	And the url should end with "/customers"
	And should return a Client created

Scenario: Client edit async
	Given a Client
	When I request the client to be edited
	Then the request should be a PUT 
	And should send Json object into the body
	And the url should end with "/customers/{id}" with id value equals to 1
	And should return a Client edited
	
Scenario: Client edit sync
	Given a Client
	When I request the client to be edited sync
	Then the request should be a PUT 
	And should send Json object into the body
	And the url should end with "/customers/{id}" with id value equals to 1
	And should return a Client edited


Scenario: Client remove async
	Given a id of the client
	When I request the client to be removed
	Then the request should be a DELETE	
	And the url should end with "/customers/{id}" with id value equals to 1
	And should send Api Token into the header
	And should return a client removed

Scenario: Client remove sync
	Given a id of the client
	When I request the client to be removed sync
	Then the request should be a DELETE	
	And the url should end with "/customers/{id}" with id value equals to 1
	And should send Api Token into the header
	And should return a client removed


