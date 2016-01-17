Feature: PaymentMethodCRUD	

Scenario: PaymentMehtod creation async
	Given a PaymentMethod
	When I request the PaymentMethod to be added
	Then the Request should be a POST
	And should send Json object into the body
	And the url should end with "/payment_methods"
	And should return a PaymentMethod created
