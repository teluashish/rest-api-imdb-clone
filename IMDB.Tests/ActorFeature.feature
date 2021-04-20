Feature: ActorFeature
	In order to manipulate actors information
	As an API consumer
	I want to be able to manipulate actor's information through the API

Scenario: Get actor by Id
	Given I am Client
	When I make GET Request '/actors/2'
	Then response data must look like this '{"Id":2,"Name":"Mila Kunis","Gender":"Female","Bio":"Ukranian","Dob":"1973-06-22"}'
	And the response status code is 200

Scenario: Get non-existing actor
	Given I am Client
	When I make GET Request '/actors/10'
	Then the response status code is 404

Scenario: Get all actors
	Given I am Client
	When I make GET Request '/actors'
	Then response data must look like this '[{"Id":1,"Name":"Christian Bale","Gender":"Male","Bio":"British","Dob":"1979-03-02"},{"Id":2,"Name":"Mila Kunis","Gender":"Female","Bio":"Ukranian","Dob":"1973-06-22"}]'
	And the response status code is 200

Scenario: Get all non-existing actors 
	Given I am Client
	When I make GET Request '/actors'
	Then response data must look like this '[]'
	And the response status code is 404


Scenario: Adding an Actor with valid data
	Given I am Client
	When I make POST Request to endpoint 'actors/1' with body message '{"Id":1,"Name":"Christian Bale","Gender":"Male","Bio":"British","Dob":"1979-03-02"}'
	Then the response status code is 201



Scenario: Updating an Actor with valid data
	Given I am Client
	When I make PUT Request to endpoint 'actors/1' with body message '{"Name":"Christian Bale","Gender":"Male","Bio":"British","Dob":"1979-03-02"}'
	Then the response status code is 200

Scenario: Updating a non-existing Actor
	Given I am Client
	When I make PUT Request to endpoint 'actors/10' with body message '{"Name":"Christian Bale","Gender":"Male","Bio":"British","Dob":"1979-03-02"}'
	Then the response status code is 404



Scenario: Deleting an Actor with valid data
	Given I am Client
	When I make DELETE Request 'actors/1' 
	Then the response status code is 200

Scenario: Deleting a non-existing Actor
	Given I am Client
	When I make DELETE Request '/actors/10'
	Then the response status code is 404

