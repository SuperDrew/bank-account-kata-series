Feature: Account information
	In order to get useful information about an account
	As a math idiot
	I want to be able to get informative about my account.

@mytag
Scenario: Get summary of account
	Given I create an account with 5 cash
	Then The account information should contain 5 cash
