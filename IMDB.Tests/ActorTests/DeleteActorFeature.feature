Feature: DeleteActorFeature
	In order to delete an actor by Id
	As an API consumer
	I want to be able to delete actor's information through the API

Scenario: Deleting an Actor with valid data
	Given that an Actor exists in the system
	When I request to delete the Actor by Id 
	Then the Actor should be deleted
	And the response status code is '200 OK'

Scenario: Deleting a non-existing Actor
	Given that an actor does not exist in the system
	When I request to delete the Actor by Id 
	Then the response status code is '404 Not Found'
