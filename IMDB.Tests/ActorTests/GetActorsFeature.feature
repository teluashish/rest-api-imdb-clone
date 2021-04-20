Feature: GetActorsFeature
	In order to get all the actors
	As an API consumer
	I want to be able to get all the actor's information through the API
	

Scenario: Get all the actors
	Given that atleast one actor exists in the system
	When I request to get all the actors
	Then the list of actors is returned in the response
	And the status code is '200 OK'

Scenario: Get all non-existing actors 
	Given that no actor exist in the system
	When I request to get all the actors
	Then no actor is returned in the response
	And the status code is '404 NOT FOUND'
