Feature: Subscription CRUD

Scenario: Subscription creation async
	Given a Subscription
	When I request the subscription to be added
	Then the request should be a POST
	And should send Json object into the body
	And the url should end with "/subscriptions"
	And should send Api Token into the header
	And should return a Subscription created

Scenario: Subscription creation sync
	Given a Subscription
	When I request the subscription to be added sync
	Then the request should be a POST 
	And should send Json object into the body
	And the url should end with "/subscriptions"
	And should send Api Token into the header
	And should return a Subscription created

Scenario: Subscription edit async
	Given a Subscription
	When I request the subscription to be edited
	Then the request should be a PUT 
	And should send Json object into the body
	And the url should end with "/subscriptions/{id}" with id value equals to 1
	And should send Api Token into the header
	And should return a Subscription edited
	
Scenario: Subscription edit sync
	Given a Subscription
	When I request the subscription to be edited sync
	Then the request should be a PUT 
	And should send Json object into the body
	And the url should end with "/subscriptions/{id}" with id value equals to 1
	And should send Api Token into the header
	And should return a Subscription edited

Scenario: Subscription remove async
	Given a id of the subscription
	When I request the subscription to be removed
	Then the request should be a DELETE	
	And the url should end with "/subscriptions/{id}" with id value equals to 1
	And should send Api Token into the header
	And should return a subscription removed

Scenario: Subscription remove sync
	Given a id of the subscription
	When I request the subscription to be removed sync
	Then the request should be a DELETE	
	And the url should end with "/subscriptions/{id}" with id value equals to 1
	And should send Api Token into the header
	And should return a subscription removed


Scenario: Get Subscription async
	Given a id of the subscription
	When I request the subscription to be got
	Then the request should be a GET	
	And the url should end with "/subscriptions/{id}" with id value equals to 1
	And should send Api Token into the header
	And should return a subscription got

Scenario: Get Subscription sync
	Given a id of the subscription
	When I request the subscription to be got sync
	Then the request should be a GET
	And the url should end with "/subscriptions/{id}" with id value equals to 1
	And should send Api Token into the header
	And should return a subscription got

Scenario: Suspend Subscription async
	Given a id of the subscription
	When I request the subscription to be suspended
	Then the request should be a POST	
	And the url should end with "/subscriptions/{id}/suspend" with id value equals to 1
	And should send Api Token into the header
	And should return a Subscription edited

Scenario: Suspend Subscription sync
	Given a id of the subscription
	When I request the subscription to be suspended sync
	Then the request should be a POST
	And the url should end with "/subscriptions/{id}/suspend" with id value equals to 1
	And should send Api Token into the header
	And should return a Subscription edited

Scenario: Activate Subscription async
	Given a id of the subscription
	When I request the subscription to be activated
	Then the request should be a POST	
	And the url should end with "/subscriptions/{id}/activate" with id value equals to 1
	And should send Api Token into the header
	And should return a Subscription edited

Scenario: Activate Subscription sync
	Given a id of the subscription
	When I request the subscription to be activated sync
	Then the request should be a POST
	And the url should end with "/subscriptions/{id}/activate" with id value equals to 1
	And should send Api Token into the header
	And should return a Subscription edited