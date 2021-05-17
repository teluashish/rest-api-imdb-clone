using System;
using System.Collections.Generic;
using IMDBAPI.Models.Database;
using IMDBAPI.Models.Request;
using IMDBAPI.Models.Response;
using IMDBAPI.Repositories;
using System.Linq;
using Dapper;
using System.Data.SqlClient;

namespace IMDBAPI.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public int AddMovie(MovieRequest movie)
        { 
            return  _movieRepository.AddMovie(new Movie { Id = movie.Id, Name = movie.Name, Year = movie.Year, Plot = movie.Plot, ProducerId = movie.ProducerId, CoverImage = movie.CoverImage }, movie.MovieActorMappingString, movie.MovieGenreMappingString);

        }

        public void DeleteMovie(int Id)
        {
            _movieRepository.DeleteMovie(Id);
        }

        public MovieResponse GetMovieById(int Id)
        {
            return _movieRepository.GetMovieById(Id);
        }

        public MovieResponse GetMovieByName(string name)
        {
            return _movieRepository.GetMovieByName(name);
        }

        public IEnumerable<MovieResponse> GetAllMovies()
        {

            return _movieRepository.GetAllMovies();
        }

        public void UpdateMovie(int Id, MovieRequest movie)
        {
            _movieRepository.UpdateMovie(Id, new Movie { Id = movie.Id, Name = movie.Name, Year = movie.Year, Plot = movie.Plot, ProducerId = movie.ProducerId, CoverImage = movie.CoverImage }, movie.MovieActorMappingString, movie.MovieGenreMappingString);
        }


    }
}
