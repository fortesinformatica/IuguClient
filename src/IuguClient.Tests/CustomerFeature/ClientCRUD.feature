Feature: Customer CRUD

Scenario: Customer creation async
	Given a Customer
	When I request the customer to be added
	Then the request should be a POST
	And should send Json object into the body
	And the url should end with "/customers"
	And should send Api Token into the header
	And should return a Customer created

Scenario: Customer creation sync
	Given a Customer
	When I request the customer to be added sync
	Then the request should be a POST 
	And should send Json object into the body
	And the url should end with "/customers"
	And should send Api Token into the header
	And should return a Customer created

Scenario: Customer edit async
	Given a Customer
	When I request the customer to be edited
	Then the request should be a PUT 
	And should send Json object into the body
	And the url should end with "/customers/{id}" with id value equals to 1
	And should send Api Token into the header
	And should return a Customer edited
	
Scenario: Customer edit sync
	Given a Customer
	When I request the customer to be edited sync
	Then the request should be a PUT 
	And should send Json object into the body
	And the url should end with "/customers/{id}" with id value equals to 1
	And should send Api Token into the header
	And should return a Customer edited


Scenario: Customer remove async
	Given a id of the customer
	When I request the customer to be removed
	Then the request should be a DELETE	
	And the url should end with "/customers/{id}" with id value equals to 1
	And should send Api Token into the header
	And should return a customer removed

Scenario: Customer remove sync
	Given a id of the customer
	When I request the customer to be removed sync
	Then the request should be a DELETE	
	And the url should end with "/customers/{id}" with id value equals to 1
	And should send Api Token into the header
	And should return a customer removed


