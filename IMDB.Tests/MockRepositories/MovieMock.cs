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
        public static List<MovieResponse> movies = new()

        {
            new MovieResponse
            {
                Id = 1,
                Name = "Rocky",
                Year = 2021,
                Plot = "Happy Movie",
                Actors = new()
                {
                    new Actor()
                    {
                        Id = 1,
                        Name = "Christian Bale",
                        Gender = "Male",
                        Bio = "British",
                        Dob = new DateTime(1979, 03, 02)
                    },
                    new Actor()
                    {
                        Id = 2,
                        Name = "Mila Kunis",
                        Gender = "Female",
                        Bio = "Ukranian",
                        Dob = new DateTime(1973, 06, 22)
                    }
                }
,
                Genres = new() {
                    new Genre() { Id=1,Name="Thriller"},
                    new Genre() { Id = 2, Name = "Drama" }

                },
                ProducerId = 1,
                CoverImage = "url"
            }
        };
       


        public static void MockInitialize()
        {
            movieRepoMock.Setup(_ => _.GetAllMovies()).Returns(() => { return movies; });
            movieRepoMock.Setup(_ => _.GetMovieById(It.IsAny<int>())).Returns((int i) => movies.Where(x => x.Id == i).Single());
            movieRepoMock.Setup(_ => _.UpdateMovie(It.IsAny<int>(), It.IsAny<Movie>(),It.IsAny<string>(),It.IsAny<string>())).Callback((int i, Movie a,string ma,string mg) =>
            {
                var movie = movies.Where(x => x.Id == i).Single();
                movie.Name = a.Name;
                movie.Year = a.Year;
                movie.Plot = a.Plot;
                movie.ProducerId = a.ProducerId;
                movie.CoverImage = a.CoverImage;

            });

            movieRepoMock.Setup(_ => _.DeleteMovie(It.IsAny<int>())).Callback((int i) => { movies.RemoveAll((x) => x.Id == i); });
            movieRepoMock.Setup(_ => _.AddMovie(It.IsAny<Movie>(), It.IsAny<string>(), It.IsAny<string>())).Callback((Movie a,string ma,string mg) => {

            });

        }

    }
}

