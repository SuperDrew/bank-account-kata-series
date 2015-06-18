Feature: Create account
	In order to us my account
	As a foo user
	I want to be able to create an account.

@mytag
Scenario: Creating a new account without cash.
	When I create a new account
	Then the account should have 0 cash
	
Scenario: Creating an account with some cash
	Given I create an account with 1 cash
	Then the account should have 1 cash