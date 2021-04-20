Feature: MovieFeature
	In order to manipulate Movies information
	As an API consumer
	I want to be able to manipulate Movies information through the API

Scenario: Get Movie by Id
	Given I am Client
	When I make GET Request '/movies/1'
	Then response data must look like this '{"Id":1,"Name":"Rocky","Year":"2021","Plot":"Happy Movie","Actors":[{"Id":1,"Name":"Christian Bale","Gender":"Male","Bio":"British","Dob":"1979-03-02"},{"Id":2,"Name":"Mila Kunis","Gender":"Female","Bio":"Ukranian","Dob":"1973-06-22"}],"Genres":"[{"Id":1, "Name":"Thriller"},{"Id":2, "Name":"Drama"}]", "ProducerId":"1", "CoverImage":"url"}'
	And the response status code is "200"

Scenario: Get non-existing Movie
	Given I am Client
	When I make GET Request '/movies/10'
	Then response data must look like this ''
	And the response status code is "404"

Scenario: Get all Movies
	Given I am Client
	When I make GET Request '/movies'
	Then response data must look like this '[{"Id":1,"Name":"Rocky","Year":"2021","Plot":"Happy Movie","Actors":[{"Id":1,"Name":"Christian Bale","Gender":"Male","Bio":"British","Dob":"1979-03-02"},{"Id":2,"Name":"Mila Kunis","Gender":"Female","Bio":"Ukranian","Dob":"1973-06-22"}],"Genres":"[{"Id":1, "Name":"Thriller"},{"Id":2, "Name":"Drama"}]", "ProducerId":"1", "CoverImage":"url"}]'
	And the response status code is "200"

Scenario: Get all non-existing Movies 
	Given I am Client
	When I make GET Request '/movies'
	Then response data must look like this '[]'
	And the response status code is "404"


Scenario: Adding Movie with valid data
	Given I am Client
	When I make POST Request to endpoint 'movies/1' with body message '{"Id":1,"Name":"Rocky","Year":"2021","Plot":"Happy Movie","Actors":"1,2","Genres":"1,2", "ProducerId":"1", "CoverImage":"url"}'
	And the response status code is "200"



Scenario: Updating Movie with valid data
	Given I am Client
	When I make PUT Request to endpoint 'movies/1' with body message '{"Name":"Mila Kunis","Gender":"Female","Bio":"Ukranian","Dob":"1973-06-22"}'
	And the response status code is "200"

Scenario: Updating a non-existing Movie
	Given I am Client
	When I make PUT Request to endpoint 'movies/10' with body message '{"Name":"Mila Kunis","Gender":"Female","Bio":"Ukranian","Dob":"1973-06-22"}'
	Then the response status code is "404"



Scenario: Deleting Movie with valid data
	Given I am Client
	When I make DELETE Request to endpoint 'movies/1' 
	And the response status code is "200"

Scenario: Deleting a non-existing Movie
	Given I am Client
	When I make DELETE Request '/movies/10'
	Then the response status code is "404"

