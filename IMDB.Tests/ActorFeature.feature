Feature: ActorFeature
	In order to manipulate actors information
	As an API consumer
	I want to be able to manipulate actor's information through the API

Scenario: Get actor by Id
	Given I am Client
	When I make GET Request '/actors/2'
	Then response data must look like this '{"id":2,"name":"Mila Kunis","bio":"Ukranian","dob":"1973-06-22T00:00:00","gender":"Female"}'
	And the response status code is 200



Scenario: Get all actors
	Given I am Client
	When I make GET Request '/actors'
	Then response data must look like this '[{"id":1,"name":"Christian Bale","bio":"British","dob":"1979-03-02T00:00:00","gender":"Male"},{"id":2,"name":"Mila Kunis","bio":"Ukranian","dob":"1973-06-22T00:00:00","gender":"Female"}]'
	And the response status code is 200



Scenario: Adding an Actor with valid data
	Given I am Client
	When I make POST Request to endpoint '/actors' with body message '{"Id":1,"Name":"Christian Bale","Bio":"British","Dob":"1979-03-02T00:00:00","Gender":"Male"}'
	Then the response status code is 200



Scenario: Updating an Actor with valid data
	Given I am Client
	When I make PUT Request to endpoint '/actors/1' with body message '{"Name":"Christian Bale","Bio":"British","Dob":"1979-03-02T00:00:00","Gender":"Male"}'
	Then the response status code is 200




Scenario: Deleting an Actor with valid data
	Given I am Client
	When I make DELETE Request '/actors/1' 
	Then the response status code is 200


