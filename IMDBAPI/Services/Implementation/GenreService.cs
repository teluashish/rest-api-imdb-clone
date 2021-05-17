using System;
using System.Collections.Generic;
using IMDBAPI.Models.Database;
using IMDBAPI.Models.Request;
using IMDBAPI.Models.Response;
using IMDBAPI.Repositories;
using System.Linq;


namespace IMDBAPI.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public void AddGenre(GenreRequest genre)
        {
            _genreRepository.AddGenre(new Genre { Id = genre.Id, Name = genre.Name });
        }

        public void DeleteGenre(int Id)
        {
            _genreRepository.DeleteGenre(Id);
        }

        public GenreResponse GetGenreById(int Id)
        {
            var genre = _genreRepository.GetGenreById(Id);
            return new GenreResponse { Id = genre.Id, Name = genre.Name };
        }

        public IEnumerable<GenreResponse> GetAllGenres()
        {
            return _genreRepository.GetAllGenres().Select(genre => new GenreResponse { Id = genre.Id, Name = genre.Name }).ToList<GenreResponse>();
        }

        public void UpdateGenre(int Id, GenreRequest genre)
        {
            _genreRepository.UpdateGenre(Id, new Genre { Id = genre.Id, Name = genre.Name });
        }
    }
}
