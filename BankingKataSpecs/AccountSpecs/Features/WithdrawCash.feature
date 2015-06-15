Feature: WithdrawCash
	In order to get cash out of my account
	As a math idiot
	I want to be able to withdraw cash

@mytag
Scenario: Withdrawing my cash
	Given I create an account with 1 cash
	When I withdraw 1 cash
	Then the account should have 0 cash
