Feature: Create account
	In order to us my account
	As a foo user
	I want to be able to create an account.

@mytag
Scenario: New account has zero cash.
	Given I want to create an account
	When I create a new account
	Then the account should have 0 cash

Scenario: New account can't take null cash.
	Given I want to create an account
	And I have null cash
	Then Creating an account should throw an argument null exception

Scenario: New account created with some cash.
	Given I create an account with 1 cash
	Then the account should have 1 cash