Feature: GetActorFeature
	In order to get an actor by Id
	As an API consumer
	I want to be able to get the actor's information through the API
	

Scenario: Get actor by Id
	Given that an actor exists in the system
	When I request to get the actor by Id
	Then the actor is returned in the response
	And the status code is '200 OK'

Scenario: Get non-existing actor by Id
	Given that an actor does not exist in the system
	When I request to get the actor by Id
	Then no actor is returned in the response
	And the status code is '404 NOT FOUND'
