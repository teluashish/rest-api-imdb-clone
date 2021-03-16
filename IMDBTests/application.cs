using System;
using IMDBService;
using TechTalk.SpecFlow;
using IMDBRepository;
using System.Linq;
using TechTalk.SpecFlow.Assist;
using IMDBDomain;

namespace IMDBTests
{
    [Binding]
    public class application
    {
        private readonly ScenarioContext _scenarioContext;

        public application(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        private string mname, aname, pname, adob, pdob, plot,actors;
        private int year, aid, pid;
        private ApplicationService _applicationService = new ApplicationService();
        private ProducerRepository _producerRepo = new ProducerRepository();
        private ActorRepository _actorRepo = new ActorRepository();
        private MovieRepository _movieRepo = new MovieRepository();

        [Given(@"I have a movie with name ""(.*)""")]
        public void GivenIHaveAMovieWithName(string p0)
        {
            mname = p0;
        }

        [Given(@"Year of Release is (.*)")]
        public void GivenYearOfReleaseIs(int p0)
        {
            year = p0;
        }

        [Given(@"plot is ""(.*)""")]
        public void GivenPlotIs(string p0)
        {
            plot = p0;
        }

        [Given(@"ID of the producer is (.*)")]
        public void GivenIDOfTheProducerIs(int p0)
        {
            pid = p0;
        }

        [Given(@"Id of the actor is ""(.*)""")]
        public void GivenIdOfTheActorIs(string p0)
        {
            actors = p0;
        }

        [When(@"I add the movie to movielist")]
        public void WhenIAddTheMovieToMovielist()
        {
            _applicationService.AddActor("Brad Pitt", "12/18/1963");
            _applicationService.AddActor("Leon", "11/18/1966");
            _applicationService.AddProducer("James Mangold", "12/16/1963");
            _applicationService.AddMovie(mname,plot,year,pid,actors);
        }


        [Then(@"my movielist should look like this")]
        public void ThenMyMovielistShouldLookLikeThis(Table table)
        {
            var movie = _applicationService.GetAllMovies();
            table.CompareToSet(movie.Select(movie=>new Movie { ID=movie.ID , Name = movie.Name, Plot = movie.Plot, Year = movie.Year, Producer = movie.Producer}));
        }
        [Then(@"My Actorr List Should Look Like This")]
        public void ThenMyActorrListShouldLookLikeThis(Table table)
        {
            var actors = _applicationService.GetAllActors();
            table.CompareToSet(actors.Select(actors => new Actor { ID = actors.ID, Name = actors.Name, DOB = actors.DOB }));
        }




        //addActor
        [Given(@"I have an actor with name ""(.*)""")]
        public void GivenIHaveAnActorWithName(string p0)
        {
            aname = p0;
        }

        [Given(@"Date of Birth of Actor is ""(.*)""")]
        public void GivenDateOfBirthOfActorIs(string p0)
        {
            adob = p0;
        }

        [When(@"I add the actor")]
        public void WhenIAddTheActor()
        {
            _applicationService.AddActor(aname,adob);
        }

        [Then(@"my actorlist should look like this")]
        public void ThenMyActorlistShouldLookLikeThis(Table table)
        {
            var actors = _applicationService.GetAllActors();
            table.CompareToSet(actors.Select(actors => new Actor { ID = actors.ID, Name = actors.Name, DOB = actors.DOB }));
        }

        //addProducer
        [Given(@"I have a producer with name ""(.*)""")]
        public void GivenIHaveAProducerWithName(string p0)
        {
            pname = p0;
        }

        [Given(@"Date of Birth of producer is ""(.*)""")]
        public void GivenDateOfBirthOfProducerIs(string p0)
        {
            pdob = p0;
        }

        [When(@"I add the producer")]
        public void WhenIAddTheProducer()
        {
            _applicationService.AddProducer(pname,pdob);
        }

        [Then(@"my producerlist should look like this")]
        public void ThenMyProducerlistShouldLookLikeThis(Table table)
        {
            var pro = _applicationService.GetAllProducers();
            table.CompareToSet(pro.Select(pro => new Actor { ID = pro.ID, Name = pro.Name, DOB = pro.DOB }));
        }


        //listMovies
        [Given(@"I have a list of movies")]
        public void GivenIHaveAListOfMovies()
        {
            _applicationService.AddActor("Brad Pitt", "12/18/1963");
            _applicationService.AddActor("Leon", "11/18/1966");
            _applicationService.AddProducer("James Mangold", "12/16/1963");
        }

        [When(@"I fetch my movielist")]
        public void WhenIFetchMyMovielist()
        {
            _applicationService.AddMovie("Ford v Ferrari", "Car Movie",2019,1,"1 2");
        }

        [Then(@"I should have the following movies")]
        public void ThenIShouldHaveTheFollowingMovies(Table table)
        {
            var movie = _applicationService.GetAllMovies();
            table.CompareToSet(movie.Select(movie => new Movie { ID = movie.ID, Name = movie.Name, Plot = movie.Plot, Year = movie.Year, Producer = movie.Producer }));
        }

        [Then(@"My Actor List Should Look Like This")]
        public void ThenMyActorListShouldLookLikeThis(Table table)
        {
            var actors = _applicationService.GetAllActors();
            table.CompareToSet(actors.Select(actors => new Actor { ID = actors.ID, Name = actors.Name, DOB = actors.DOB }));
        }

        [Then(@"Producer Looks Like This")]
        public void ThenProducerLooksLikeThis(Table table)
        {
            var producer = _applicationService.GetAllProducers();
            table.CompareToSet(producer);
        }



    }
}
