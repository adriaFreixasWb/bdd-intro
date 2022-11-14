Feature: A token needs to be fetch in order to be authorized

A request with user and password must be sent to get a token

Scenario: A request with wrong credentials is rejected
	Given That we have a wrong user and a password
	When We log request a new token
	Then We should get unauthorized

Scenario: A request with right credentials is granted access
	Given That we have correct credentials
	When We log request a new token
	Then We should get success