Feature: Sign In

A short summary of the feature

@smoke
Scenario: Create an Account
	Given I am on Sign In page
	And I create new account with following details
	And I click Create an Account button
	And I type my personal information
	When I press Register button
	Then My Account page is presented

@smoke
Scenario: Create an Account with email that is already registered
	Given I am on Sign In page
	And I create an account with following details
		| Email         |
		| test@test.com |
	When I click Create an Account button
	Then Valid error message is presented

@smoke
Scenario: Forgot your pasword link 
	Given I am on Sign In page
	When I click on Forgot your password link
	Then Forgot your password page is presented

@smoke
Scenario: Empty email and password for Sign In 
	Given I am on Sign In page
	When I click on Sign In button
	Then Email address is required error message is presented

@smoke
Scenario: Invalid email format
	Given I am on Sign In page
	And I type invalid email format
		| Email |
		| test  |
	When I click on Sign In button
	Then Invalid email address error message is presented

@smoke
Scenario: Wrong password for Sign In 
	Given I am on Sign In page
	And I type valid email
		| Email         |
		| test@test.com |
	And I type in invalid password
		| Password |
		| qwerty   |
	When I click on Sign In button
	Then Authentcation error message is presented

@smoke
Scenario: Empty password for Sign In 
	Given I am on Sign In page
	And I type valid email
		| Email         |
		| test@test.com |
	And I type in invalid password
		| Password |
		|          |
	When I click on Sign In button
	Then Invalid password error message is presented

