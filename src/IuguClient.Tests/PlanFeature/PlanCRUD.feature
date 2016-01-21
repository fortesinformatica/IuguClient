Feature: Plan CRUD

Scenario: Plan creation async
	Given a Plan
	When I request the plan to be added
	Then the request should be a POST
	And should send Json object into the body
	And the url should end with "/plans"
	And should send Api Token into the header
	And should return a Plan created

Scenario: Plan creation sync
	Given a Plan
	When I request the plan to be added sync
	Then the request should be a POST 
	And should send Json object into the body
	And the url should end with "/plans"
	And should send Api Token into the header
	And should return a Plan created

Scenario: Plan edit async
	Given a Plan
	When I request the plan to be edited
	Then the request should be a PUT 
	And should send Json object into the body
	And the url should end with "/plans/{id}" with id value equals to 1
	And should send Api Token into the header
	And should return a Plan edited
	
Scenario: Plan edit sync
	Given a Plan
	When I request the plan to be edited sync
	Then the request should be a PUT 
	And should send Json object into the body
	And the url should end with "/plans/{id}" with id value equals to 1
	And should send Api Token into the header
	And should return a Plan edited

Scenario: Plan remove async
	Given a id of the plan
	When I request the plan to be removed
	Then the request should be a DELETE	
	And the url should end with "/plans/{id}" with id value equals to 1
	And should send Api Token into the header
	And should return a plan removed

Scenario: Plan remove sync
	Given a id of the plan
	When I request the plan to be removed sync
	Then the request should be a DELETE	
	And the url should end with "/plans/{id}" with id value equals to 1
	And should send Api Token into the header
	And should return a plan removed


Scenario: Get Plan async
	Given a id of the plan
	When I request the plan to be got
	Then the request should be a GET	
	And the url should end with "/plans/{id}" with id value equals to 1
	And should send Api Token into the header
	And should return a plan got

Scenario: Get Plan sync
	Given a id of the plan
	When I request the plan to be got sync
	Then the request should be a GET
	And the url should end with "/plans/{id}" with id value equals to 1
	And should send Api Token into the header
	And should return a plan got