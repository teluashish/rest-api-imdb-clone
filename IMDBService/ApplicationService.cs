using System;
using System.Linq;
using System.Collections.Generic;
using IMDBDomain;

namespace IMDBService
{
    public class ApplicationService
    {
        private readonly MovieService _movieService = new MovieService();


        public void ListMovies()
        {
            _movieService.ShowAllMovies();
        }

        public void AddMovie(string name,string plot,int year,int producerIdx,string actors)
        {
            var actorsArray = actors.Split(' ').Select(Int32.Parse).ToList();
            _movieService.AddMovie(name, plot, year, producerIdx - 1, actorsArray.ToArray());
        }

        public void AddActor(string name,string dob)
        {
            _movieService._actorService.AddActor(name,dob);
        }

        public void AddProducer(string name, string dob)
        {
            _movieService._producerService.AddProducer(name,dob);
        }

        public void DeleteMovie(int index)
        {
            _movieService.DeleteMovie(index);
        }

        public void ShowAllProducers()
        {
            _movieService._producerService.ShowAllProducers();
        }

        public void ShowAllActors()
        {
            _movieService._actorService.ShowAllActors();
        }

        public void ShowAllMovies()
        {
            _movieService.ShowAllMovies();
        }

        public List<Actor> GetAllActors()
        {
            return _movieService._actorService.GetAllActors();
        }
        public List<Producer> GetAllProducers()
        {
            return _movieService._producerService.GetAllProducers();
        }
        public List<Movie> GetAllMovies()
        {
            return _movieService.GetAllMovies();
        }

    }
}
