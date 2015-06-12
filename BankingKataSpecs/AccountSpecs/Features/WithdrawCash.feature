Feature: WithdrawCash
	In order to get cash out of my account
	As a math idiot
	I want to be able to withdraw cash

@mytag
Scenario: Withdrawing my cash
	Given I have some cash
	And I create an account with my cash
	When I withdraw my cash
	Then the account should have zero cash
