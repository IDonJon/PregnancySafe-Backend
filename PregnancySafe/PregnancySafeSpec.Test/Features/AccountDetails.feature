Feature: AccountDetails
	As a user 
	I want to visualize the details of my account
	In order to verify my personal information

Scenario: Verify my account
	Given a verified user
	When the user clicks on his profile icon
	Then the system will show your personal information