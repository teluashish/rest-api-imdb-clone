using System;
using System.Collections.Generic;
using IMDBRepository;
using IMDBDomain;

namespace IMDBService
{
    public class MovieService
    {

        private MovieRepository _movieRepo = new MovieRepository();
        public ProducerService _producerService = new ProducerService();
        

        public void AddMovie(string name, string plot, int year, int producerIdx, int[] producerIdx)
        {
            
            Movie movie = new Movie
            {
                ID = _movieRepo.GetMovieCount() + 1,
                Name = name,
                Plot = plot,
                Year = year,
                Producer = _producerService.GetProducer(producerIdx)

            };
            foreach (var idx in producerIdx)
            {
   
                movie.producerList.Add(_producerService.Getproducer(idx));
            }

            _movieRepo.AddMovie(movie);

        }

        public void ShowAllMovies()
        {
            foreach(var movie in _movieRepo.GetMovies())
            {
                Console.WriteLine("Movie Details:");
                Console.WriteLine("Movie ID: "+movie.ID);
                Console.WriteLine("Name of the Movie is: "+movie.Name);
                Console.WriteLine("Plot of the Movie is: "+movie.Plot);
                Console.WriteLine("Movie year of release: "+movie.Year);
                Console.WriteLine("Movie Producer: "+movie.Producer.Name);
                Console.WriteLine("Movie Cast:");
                foreach (var producer in movie.producerList)
                {
                    Console.WriteLine(producer.Name);
                }

            }
        }

        public void DeleteMovie(int index)
        {
            _movieRepo.DeleteMovie(index);
        }
        public List<Movie> GetAllMovies()
        {
            return _movieRepo.GetAllMovies();
        }


    }
}
