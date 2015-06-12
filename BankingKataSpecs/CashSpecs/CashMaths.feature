Feature: CashMaths
	In order to change the amount of cash
	As a math idiot
	I want to be able to performmaths on my cash

@mytag
Scenario: Add cash
	Given I have 1 cash
	When I add 1 cash
	Then I should have 2 cash

Scenario: Subtract cash
	Given I have 1 cash
	When I subtract 1 cash
	Then I should have 0 cash