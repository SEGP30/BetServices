Feature: Register Clients

Scenario: Successful client register
	Given the Id 123456, names "Luis", surnames "Bayona Farfan" and gender 0
	When the client is registered in the system
	Then the response code should be 200