Feature: ToStringOverride
	In order to get useful information about an account
	As a math idiot
	I want to be able to get an informative ToStirng for an account.

@mytag
Scenario: Get summary of account
	Given I create an account with 5 cash
	Then The ToString should have 5 cash
