Feature: ProducerFeature
	In order to manipulate producer's information
	As an API consumer
	I want to be able to manipulate producers information through the API

Scenario: Get producer by Id
	Given I am Client
	When I make GET Request '/producers/2'
	Then response data must look like this '{"id":2,"name":"Tom","bio":"American","dob":"1973-06-22T00:00:00","gender":"Male"}'
	And the response status code is 200

Scenario: Get all producers
	Given I am Client
	When I make GET Request '/producers'
	Then response data must look like this '[{"id":1,"name":"Arjun","bio":"Indian","dob":"1979-03-02T00:00:00","gender":"Male"},{"id":2,"name":"Tom","bio":"American","dob":"1973-06-22T00:00:00","gender":"Male"}]'
	And the response status code is 200



Scenario: Adding Producer with valid data
	Given I am Client
	When I make POST Request to endpoint '/producers' with body message '{"Id":1,"Name":"Arjun","Bio":"Indian","Dob":"1979-03-02T00:00:00","Gender":"Male"}'
	Then the response status code is 200

   


Scenario: Updating Producer with valid data
	Given I am Client
	When I make PUT Request to endpoint '/producers/1' with body message '{"name":"Arjun","bio":"Indian","dob":"1979-03-02T00:00:00","gender":"Male"}'
	Then the response status code is 200




Scenario: Deleting Producer with valid data
	Given I am Client
	When I make DELETE Request '/producers/1' 
	Then the response status code is 200




