Feature: Rate Appointment
	As a mother
	I want to rate an appointment
	In order to generate a score

Scenario: Rate an appointment
	Given The Mother wants to rate an appointment 
	When The Mother clicks on my appointments page
	Then The system will show a message asking for a rate between 1 to 5