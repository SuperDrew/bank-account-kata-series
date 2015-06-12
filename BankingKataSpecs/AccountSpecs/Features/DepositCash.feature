Feature: DepositCash
	In order to deposit cash into my account
	As a foo user
	I want to be able to deposit Cash

@mytag
Scenario: Depositing my cash
	Given I have zero cash
	And I create an account with my cash
	And I have some cash
	When I deposit my cash
	Then My account should have the same Cash as my cash
