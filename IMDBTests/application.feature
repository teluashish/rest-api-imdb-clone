Feature: IMDB
	Display of movies and associated Name, Year of Release, Plot, Producer and a list of Actors.

@listMovies
Scenario: List all movies in Movies
	Given I have a list of movies
	When I fetch my movielist
	Then I should have the following movies
    | id | Name           | Year | Plot      | 
    | 1  | Ford v Ferrari | 2019 | Car Movie |  
	And My Actor List Should Look Like This
    | id | Name		 | DOB        |
    | 1  | Brad Pitt | 12/18/1963 |
	| 2	 | Leon      | 11/18/1966 |
	And Producer Looks Like This
	| id  | Name          | DOB        |
    | 1   | James Mangold | 12/16/1963 |

                                                                       

@addActor
Scenario: Adding an actor to the actor list
	Given I have an actor with name "Brad Pitt"
	And Date of Birth of Actor is "12/18/1963"
	When I add the actor 
	Then my actorlist should look like this
    | id  | Name      | DOB        |
    | 1   | Brad Pitt | 12/18/1963 |



@addProducer
Scenario: Adding a producer to the producer list
	Given I have a producer with name "James Mangold"
	And Date of Birth of producer is "12/16/1963"
	When I add the producer 
	Then my producerlist should look like this
    | id  | Name          | DOB        |
    | 1   | James Mangold | 12/16/1963 |



@addMovie	
Scenario: Adding a movie to the list
	Given I have a movie with name "Ford v Ferrari"
	And Year of Release is 2019
	And plot is "Car Movie"
	And ID of the producer is 1
	And Id of the actor is "1 2"
	When I add the movie to movielist
	Then my movielist should look like this
    | id  | Name           | Year | Plot      |
    | 1   | Ford v Ferrari | 2019 | Car Movie |
	And My Actorr List Should Look Like This
    | id | Name		 | DOB        |
    | 1  | Brad Pitt | 12/18/1963 |
	| 2	 | Leon      | 11/18/1966 |




   


