Feature: GenreFeature
	In order to manipulate genres information
	As an API consumer
	I want to be able to manipulate genre information through the API

Scenario: Get genre by Id
	Given I am Client
	When I make GET Request '/genres/2'
	Then response data must look like this '{"id":2,"name":"Drama"}'
	And the response status code is 200



Scenario: Get all genres
	Given I am Client
	When I make GET Request '/genres'
	Then response data must look like this '[{"id":1,"name":"Thriller"},{"id":2,"name":"Drama"}]'
	And the response status code is 200




Scenario: Adding Genre with valid data
	Given I am Client
	When I make POST Request to endpoint '/genres' with body message '{"id":1,"name":"Thriller"}'
	Then the response status code is 201

      


Scenario: Updating Genre with valid data
	Given I am Client
	When I make PUT Request to endpoint '/genres/2' with body message '{"name":"Thriller"}'
	Then the response status code is 200




Scenario: Deleting Genre with valid data
	Given I am Client
	When I make DELETE Request '/genres/1' 
	Then the response status code is 200


