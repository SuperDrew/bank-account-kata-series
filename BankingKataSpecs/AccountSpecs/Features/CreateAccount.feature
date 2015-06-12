Feature: Create account
	In order to us my account
	As a foo user
	I want to be able to create an account.

@mytag
Scenario: New account has zero cash.
	Given I want to create an account
	When I create a new account
	Then the account should have zero cash

Scenario: New account can't take null cash.
	Given I want to create an account
	And I have null cash
	Then Creating an account should throw an argument null exception.

Scenario: New account created with my cash.
	Given I have some cash
	And I create an account with my cash
	Then the account total should be the same as my cash.