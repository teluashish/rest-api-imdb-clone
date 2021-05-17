using System;
using IMDBAPI.Repositories;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using System.Collections.Generic;
using IMDBAPI.Models.Database;
using System.Linq;
using IMDBAPI.Models.Response;
using IMDBAPI.Models.Request;

namespace IMDB.Tests
{
    public class MovieMock
    {
        public static readonly Mock<IMovieRepository> movieRepoMock = new();
        public static readonly Mock<IActorRepository> actorRepoMock = ActorMock.actorRepoMock;
        public static readonly Mock<IGenreRepository> genreRepoMock = GenreMock.genreRepoMock;

        public static List<MovieResponse> movies = new();
       

        public static void MockInitialize()
        {

            movieRepoMock.Setup(_ => _.GetAllMovies())
                .Returns(() => {
                    return movies;
                });


            movieRepoMock.Setup(_ => _.GetMovieById(It.IsAny<int>()))
                .Returns((int i) => movies.Where(x => x.Id == i).Single());


            movieRepoMock.Setup(_ => _.UpdateMovie(It.IsAny<int>(), It.IsAny<Movie>(),It.IsAny<string>(),It.IsAny<string>()))
                .Callback((int i, Movie a,string ma,string mg) =>
            {
                var movie = movies.Where(x => x.Id == i).Single();
                movie.Name = a.Name;
                movie.Year = a.Year;
                movie.Plot = a.Plot;
                movie.ProducerId = a.ProducerId;
                movie.CoverImage = a.CoverImage;

            });


            movieRepoMock.Setup(_ => _.DeleteMovie(It.IsAny<int>()))
                .Callback((int i) =>{
                    movies.RemoveAll((x) => x.Id == i);
                });


            movieRepoMock.Setup(_ => _.AddMovie(It.IsAny<Movie>(), It.IsAny<string>(), It.IsAny<string>()))
                .Callback((Movie movie,string ma,string mg) => {
                    
                    movies.Add( new() {
                        Id = movie.Id,
                        Name = movie.Name,
                        Year = movie.Year,
                        Plot = movie.Plot,
                        Actors = ma.Split(',').Select(x => actorRepoMock.Object.GetActorById(Convert.ToInt32(x))).ToList(),
                        Genres = mg.Split(',').Select(x => genreRepoMock.Object.GetGenreById(Convert.ToInt32(x))).ToList(),
                        ProducerId = movie.ProducerId,
                        CoverImage = movie.CoverImage

                    });
                });

        }


    }
}

