Feature: Schedule Appointment
	As a mother
	I want to schedule an appointment
	So I can ask more about my stage

Scenario: Schedule new appointment
	Given I am in my medical appointment
	When Press the option to schedule new appointment
	Then Valid my next appointment 