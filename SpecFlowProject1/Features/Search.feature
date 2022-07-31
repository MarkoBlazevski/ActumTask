Feature: Search

A short summary of the feature

@smoke
Scenario: Type into Search box and perform query
	Given I am on Home Page
	And I type query into search box
		| Query |
		| dress |
	When I press submit search button
	Then Results for query are presented

@smoke
Scenario: Empty search query
	Given I am on Home Page
	When I press submit search button
	Then Please enter a search keyword warning is presented

@smoke
Scenario: Partial search query
	Given I am on Home Page
	When I type query into search box
		| Query |
		| dre   |
	Then Drop down search hints are presented

@smoke
Scenario: Query with no search results
	Given I am on Home Page
	And I type query into search box
		| Query |
		| d |
	When I press submit search button
	Then No results found warning is presented

@smoke
Scenario: Query with caps lock On
	Given I am on Home Page
	And I type query into search box
		| Query |
		| DRESS |
	When I press submit search button
	Then Results for query are presented
