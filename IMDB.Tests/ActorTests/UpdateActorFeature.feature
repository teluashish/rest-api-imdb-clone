Feature: UpdateActorFeature
	In order to update the actor by Id
	As an API consumer
	I want to be able to update actor's information through the API

Scenario: Updating an Actor with valid data
	Given that an Actor exists in the system
	When I request to update the Actor by Id with details
	| Name     | Bio     | Dob      | Gender      | 
    | TestName | TestBio | 2000-1-1 | TestGender  |
	Then the Actor should be updated
	And the response status code is '200 OK'

Scenario: Updating a non-existing Actor
	Given that an actor does not exist in the system
	When I request to update the Actor by Id with details Name: 'TestName' Bio: 'TestBio' Dob: '2000-1-1' and Gender: 'TestGender'
	Then the response status code is '404 Not Found'

Scenario Outline: Updating an Actor with invalid data
	Given that an Actor exists in the system
	When I request to update the Actor by Id with details Name: '<Name>' Bio: '<Bio>' Dob: '<Dob>' and Gender: '<Gender>'
	Then the response status code is '400 Bad Request'
	Examples: 
	| Name     | Bio     | Dob      | Gender      | 
    | 		   | TestBio | 2000-1-1 | TestGender  |
	| TestName |         | 2000-1-1 | TestGender  |
	| TestName | TestBio |          | TestGender  |
	| TestName | TestBio | 2000-1-1 |             |
	|          |         | 2000-1-1 | TestGender  |
	|          | TestBio |          | TestGender  |
	|          | TestBio | 2000-1-1 |             |
	| TestName |         |          | TestGender  |
	| TestName |         | 2000-1-1 |             |
	| TestName | TestBio |          |             |
	|          |         |          | TestGender  |
	|          |         | 2000-1-1 |             |
	| TestName |         |          |             |
	|          | TestBio |          |             |
	|          |         | 2000-1-1 |             |
	|          |         | 	        |             |