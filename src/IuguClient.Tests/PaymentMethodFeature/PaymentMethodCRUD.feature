Feature: PaymentMethodCRUD	

Scenario: PaymentMehtod creation async
	Given a PaymentMethod
	When I request the PaymentMethod to be added
	Then the request should be a POST
	And should send Json object into the body
	And the url should end with "customers/{clientId}/payment_methods" with clientId value equal to 2
	And should send Api Token into the header
	And should return a PaymentMethod created

Scenario: PaymentMehtod creation sync
	Given a PaymentMethod
	When I request the PaymentMethod to be added sync
	Then the request should be a POST
	And should send Json object into the body
	And the url should end with "customers/{clientId}/payment_methods" with clientId value equal to 2
	And should send Api Token into the header
	And should return a PaymentMethod created

Scenario: PaymentMehtod edit async
	Given a PaymentMethod
	When I request the PaymentMethod to be edited
	Then the request should be a PUT 
	And should send Json object into the body
	And the url should end with "customers/{clientId}/payment_methods/{id}" with clientId value equals to 22 and id value equals to 1
	And should send Api Token into the header
	And should return a PaymentMethod edited
	
Scenario: PaymentMehtod edit sync
	Given a PaymentMethod
	When I request the PaymentMethod to be edited sync
	Then the request should be a PUT 
	And should send Json object into the body
	And the url should end with "customers/{clientId}/payment_methods/{id}" with clientId value equals to 22 and id value equals to 1
	And should send Api Token into the header
	And should return a PaymentMethod edited

Scenario: PaymentMethod remove async
	Given a id of the paymentMehtod
	When I request the paymentMehtod to be removed
	Then the request should be a DELETE	
	And the url should end with "customers/{clientId}/payment_methods/{id}" with id value equals to 1
	And should send Api Token into the header
	And should return a paymentMehtod removed

Scenario: PaymentMethod remove sync
	Given a id of the paymentMehtod
	When I request the paymentMehtod to be removed sync
	Then the request should be a DELETE	
	And the url should end with "customers/{clientId}/payment_methods/{id}" with id value equals to 1
	And should send Api Token into the header
	And should return a paymentMehtod removed
