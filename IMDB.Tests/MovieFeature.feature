Feature: MovieFeature
	In order to manipulate Movies information
	As an API consumer
	I want to be able to manipulate Movies information through the API

Scenario: Get Movie by Id
	Given I am Client
	When I make GET Request '/movies/1'
	Then response data must look like this '{"id":1,"name":"Rocky","year":2021,"plot":"Happy Movie","actors":[{"id":1,"name":"Christian Bale","bio":"British","dob":"1979-03-02T00:00:00","gender":"Male"},{"id":2,"name":"Mila Kunis","bio":"Ukranian","dob":"1973-06-22T00:00:00","gender":"Female"}],"genres":[{"id":1,"name":"Thriller"},{"id":2,"name":"Drama"}],"producerId":1,"coverImage":"url"}'
	And the response status code is 200

# Scenario: Get non-existing Movie
# 	Given I am Client
# 	When I make GET Request '/movies/10'
# 	Then response data must look like this ''
# 	And the response status code is 404

Scenario: Get all Movies
	Given I am Client
	When I make GET Request '/movies'
	Then response data must look like this '[]'
	And the response status code is 200

# Scenario: Get all non-existing Movies 
# 	Given I am Client
# 	When I make GET Request '/movies'
# 	Then response data must look like this '[]'
# 	And the response status code is 404


Scenario: Adding Movie with valid data
	Given I am Client
	When I make POST Request to endpoint '/movies' with body message '{"id":1,"name":"Rocky","year":2021,"plot":"Happy Movie","actors":[{"id":1,"name":"Christian Bale","bio":"British","dob":"1979-03-02T00:00:00","gender":"Male"},{"id":2,"name":"Mila Kunis","bio":"Ukranian","dob":"1973-06-22T00:00:00","gender":"Female"}],"genres":[{"id":1,"name":"Thriller"},{"id":2,"name":"Drama"}],"producerId":1,"coverImage":"url"}'
	Then the response status code is 201



Scenario: Updating Movie with valid data
	Given I am Client
	When I make PUT Request to endpoint 'movies/1' with body message '{"Name":"Mila Kunis","Gender":"Female","Bio":"Ukranian","Dob":"1973-06-22"}'
	Then the response status code is 200

# Scenario: Updating a non-existing Movie
# 	Given I am Client
# 	When I make PUT Request to endpoint 'movies/10' with body message '{"Name":"Mila Kunis","Gender":"Female","Bio":"Ukranian","Dob":"1973-06-22"}'
# 	Then the response status code is 404



Scenario: Deleting Movie with valid data
	Given I am Client
	When I make DELETE Request '/movies/1' 
	Then the response status code is 200

# Scenario: Deleting a non-existing Movie
# 	Given I am Client
# 	When I make DELETE Request '/movies/10'
# 	Then the response status code is 404

