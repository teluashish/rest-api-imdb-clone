using System;
using IMDBAPI.Repositories;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using System.Collections.Generic;
using IMDBAPI.Models.Database;
using System.Linq;

namespace IMDB.Tests
{
    public class GenreMock
    {
        public static readonly Mock<IGenreRepository> genreRepoMock = new Mock<IGenreRepository>();
        public static List<Genre> genres = new()
        {
            new Genre()
            {
                Id = 1,
                Name = "Thriller",
            },
            new Genre()
            {
                Id = 2,
                Name = "Drama",
            }
        };


        public static void MockInitialize()
        {
            genreRepoMock.Setup(_ => _.GetAllGenres()).Returns(() => { return genres; });
            genreRepoMock.Setup(_ => _.GetGenreById(It.IsAny<int>())).Returns((int i) => genres.Where(x => x.Id == i).Single());
            genreRepoMock.Setup(_ => _.UpdateGenre(It.IsAny<int>(), It.IsAny<Genre>())).Callback((int i, Genre a) =>
            {
                var genre = genres.Where(x => x.Id == i).Single();
                genre.Name = a.Name;

            });

            genreRepoMock.Setup(_ => _.DeleteGenre(It.IsAny<int>())).Callback((int i) => { genres.RemoveAll((x) => x.Id == i); });
            genreRepoMock.Setup(_ => _.AddGenre(It.IsAny<Genre>())).Callback((Genre a) => { genres.Add(a); });

        }

    }
}
