Feature: InvoiceCRUD

Scenario: Invoice creation async
	Given a Invoice
	When I request the Invoice to be added
	Then the request should be a POST
	And should send Json object into the body
	And the url should end with "/invoices"
	And should send Api Token into the header
	And should return a Invoice created

Scenario: Invoice creation sync
	Given a Invoice
	When I request the Invoice to be added sync
	Then the request should be a POST
	And should send Json object into the body
	And the url should end with "/invoices"
	And should send Api Token into the header
	And should return a Invoice created

Scenario: Invoice edit async
	Given a Invoice
	When I request the Invoice to be edited
	Then the request should be a PUT 
	And should send Json object into the body
	And the url should end with "/invoices/{id}" with id value equals to 0958D2AAD34049AB889583E26DFA0BF1
	And should send Api Token into the header
	And should return a Invoice edited

Scenario: Invoice edit sync
	Given a Invoice
	When I request the Invoice to be edited sync
	Then the request should be a PUT 
	And should send Json object into the body
	And the url should end with "/invoices/{id}" with id value equals to 0958D2AAD34049AB889583E26DFA0BF1
	And should send Api Token into the header
	And should return a Invoice edited

Scenario: Invoice remove async
	Given a id of the invoice
	When I request the invoice to be removed
	Then the request should be a DELETE	
	And the url should end with "/invoices/{id}" with id value equals to 0958D2AAD34049AB889583E26DFA0BF1
	And should send Api Token into the header
	And should return a invoice removed

Scenario: Invoice remove sync
	Given a id of the invoice
	When I request the invoice to be removed sync
	Then the request should be a DELETE	
	And the url should end with "/invoices/{id}" with id value equals to 0958D2AAD34049AB889583E26DFA0BF1
	And should send Api Token into the header
	And should return a invoice removed

Scenario: Invoices duplicate
	Given a Invoice
	When I request the invoice to be duplicated
	Then the request should be a POST	
	And the url should end with "/invoices/{id}/duplicate" with id value equals to 0958D2AAD34049AB889583E26DFA0BF1
	And should send Api Token into the header
	And should return a invoice duplicated

Scenario: Invoices duplicate sync
	Given a Invoice
	When I request the invoice to be duplicated sync
	Then the request should be a POST	
	And the url should end with "/invoices/{id}/duplicate" with id value equals to 0958D2AAD34049AB889583E26DFA0BF1
	And should send Api Token into the header
	And should return a invoice duplicated

Scenario: Invoice cancel
	Given a id of the invoice
	When I request the invoice to be canceled
	Then the request should be a PUT	
	And the url should end with "/invoices/{id}/cancel" with id value equals to 0958D2AAD34049AB889583E26DFA0BF1
	And should send Api Token into the header
	And should return a invoice canceled

Scenario: Invoice cancel sync
	Given a id of the invoice
	When I request the invoice to be canceled sync
	Then the request should be a PUT	
	And the url should end with "/invoices/{id}/cancel" with id value equals to 0958D2AAD34049AB889583E26DFA0BF1
	And should send Api Token into the header
	And should return a invoice canceled

Scenario: Invoice refund
	Given a id of the invoice
	When I request the invoice to be refunded
	Then the request should be a POST	
	And the url should end with "/invoices/{id}/refund" with id value equals to 0958D2AAD34049AB889583E26DFA0BF1
	And should send Api Token into the header
	And should return a invoice canceled

Scenario: Invoice refund sync
	Given a id of the invoice
	When I request the invoice to be refunded sync
	Then the request should be a POST	
	And the url should end with "/invoices/{id}/refund" with id value equals to 0958D2AAD34049AB889583E26DFA0BF1
	And should send Api Token into the header
	And should return a invoice canceled

Scenario: Invoice retrieve
	Given a id of the invoice
	When I request the invoice to be retrieved
	Then the request should be a GET
	And the url should end with "/invoices/{id}"
	And should send Api Token into the header
	And should return a invoice retrieved

Scenario: Invoice retrieve sync
	Given a id of the invoice
	When I request the invoice to be retrieved sync
	Then the request should be a GET
	And the url should end with "/invoices/{id}"
	And should send Api Token into the header
	And should return a invoice retrieved
