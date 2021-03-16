using System.Collections.Generic;
using IMDBDomain;
using System.Linq;
namespace IMDBRepository
{
    public class MovieRepository
    {
        private readonly List<Movie> _movieList; 
        public MovieRepository()
        {
            _movieList = new List<Movie>();
        }
        public void AddMovie(Movie movie) {
            _movieList.Add(movie);
        }
        public void DeleteMovie(int index)
        {
            _movieList.RemoveAt(index);
        }
        public Movie GetMovie(int index)
        {
            return _movieList[index];
        }
        public IEnumerable<Movie> GetMovies()
        {
            foreach (var movie in _movieList)
                yield return movie;

        }
        public int GetMovieCount()
        {
            return _movieList.Count;
        }
        public List<Movie> GetAllMovies()
        {
            return _movieList.ToList();
        }
    }
}
