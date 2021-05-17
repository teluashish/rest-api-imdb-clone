using System;
using System.Collections.Generic;
using IMDBAPI.Models.Database;
using IMDBAPI.Models.Request;
using IMDBAPI.Models.Response;

namespace IMDBAPI.Repositories
{
    public interface IMovieRepository
    {
        public IEnumerable<MovieResponse> GetAllMovies();
        public MovieResponse GetMovieById(int Id);
        public int AddMovie(Movie movie, string MovieActorMappingString, string MovieGenreMappingString);
        public void UpdateMovie(int Id, Movie movie, string MovieActorMappingString, string MovieGenreMappingString);
        public void DeleteMovie(int Id);
        public MovieResponse GetMovieByName(string name);

    }
}
