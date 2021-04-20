using System;
using System.Collections.Generic;
using IMDBAPI.Models.Request;
using IMDBAPI.Models.Response;

namespace IMDBAPI.Services
{
    public interface IMovieService
    {
        public IEnumerable<MovieResponse> GetAllMovies();
        public MovieResponse GetMovieById(int Id);
        public void AddMovie(MovieRequest movie);
        public void UpdateMovie(int Id, MovieRequest movie);
        public void DeleteMovie(int Id);
    }
}
