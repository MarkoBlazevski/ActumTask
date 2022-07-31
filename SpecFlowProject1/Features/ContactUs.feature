Feature: Contact Us

A short summary of the feature

@smoke
Scenario: Send a message to customer service
	Given I am on Contact Us page
	And I choose Customer Service from Subject Heading
	And I enter following details
		| Email         | OrderReference | Message              |
		| test@test.com | 1234567        | Hello, this is test. |
	When I click on Send button
	Then Success message is presented

@smoke
Scenario: Send message to a Webmaster
	Given I am on Contact Us page
	And I choose Webmaster from Subject Heading
	And I enter following details
		| Email         | OrderReference | Message              |
		| test@test.com | 1234567        | Hello, this is test. |
	When I click on Send button
	Then Success message is presented

@smoke
Scenario: Invalid Email format
	Given I am on Contact Us page
	And I choose Customer Service from Subject Heading
	And I enter following details
		| Email | OrderReference | Message |
		| test  | 1234567        | Hello.  |
	When I click on Send button
	Then Invalid email address Error message is presented

@smoke
Scenario: Not choose any option from Subject Heading
	Given I am on Contact Us page
	And I do NOT choose any option from Subject Heading
	And I enter following details
		| Email			 | OrderReference  | Message |
		| test@test.com  | 1234567         | Hello.  |
	When I click on Send button
	Then Please select a subject from the list provided Error message is presented

@smoke
Scenario: Click Send button without any required field populated
	Given I am on Contact Us page
	When I click on Send button
	Then Invalid email address Error message is presented

@smoke
Scenario: Send empty message
	Given I am on Contact Us page
	And I choose Webmaster from Subject Heading
	And I enter following details
		| Email         | OrderReference | Message |
		| test@test.com | 1234567        |         |
	When I click on Send button
	Then The message can not be blank Error message is presented

@smoke
Scenario: Home button 
	Given I am on Contact Us page
	When I click on Home button
	Then Home page is presented
