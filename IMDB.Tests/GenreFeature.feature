Feature: GenreFeature
	In order to manipulate genres information
	As an API consumer
	I want to be able to manipulate genre information through the API

Scenario: Get genre by Id
	Given I am Client
	When I make GET Request '/genres/2'
	Then response data must look like this '{"Id":2,"Name":"Drama"}'
	And the response status code is "200"

Scenario: Get non-existing genre
	Given I am Client
	When I make GET Request '/genres/10'
	Then response data must look like this ''
	And the response status code is "404"

Scenario: Get all genres
	Given I am Client
	When I make GET Request '/genres'
	Then response data must look like this '[{"Id":1,"Name":"Thriller"}{"Id":2,"Name":"Drama"}]'
	And the response status code is "200"

Scenario: Get all non-existing genres 
	Given I am Client
	When I make GET Request '/genres'
	Then response data must look like this '[]'
	And the response status code is "404"


Scenario: Adding Genre with valid data
	Given I am Client
	When I make POST Request to endpoint 'genres/1' with body message '{"Id":1,"Name":"Thriller"}'
	And the response status code is "200"

      


Scenario: Updating Genre with valid data
	Given I am Client
	When I make PUT Request to endpoint 'genres/1' with body message '{"Name":"Drama"}'
	And the response status code is "200"

Scenario: Updating a non-existing Genre
	Given I am Client
	When I make PUT Request to endpoint 'genres/10' with body message '{"Name":"Drama"}'
	Then the response status code is "404"




Scenario: Deleting Genre with valid data
	Given I am Client
	When I make DELETE Request 'genres/1' 
	And the response status code is "200"

Scenario: Deleting a non-existing Genre
	Given I am Client
	When I make DELETE Request '/genres/10'
	Then the response status code is "404"

