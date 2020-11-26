Feature: ActivateAppointment
	As a mother
	I want to join an appointment
	In order to verify my pregnancy stage

Scenario: ActivateAppointment
	Given a mother has an appointment
	When the mother clicks on join appointment
	Then the system changes appointment to in progress