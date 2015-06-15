Feature: DepositCash
	In order to deposit cash into my account
	As a foo user
	I want to be able to deposit Cash

@mytag
Scenario: Depositing my cash
	Given I create an account with 0 cash
	When I deposit 1 cash
	Then the account should have 1 cash
