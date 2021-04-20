using System;
using System.Collections.Generic;
using IMDBAPI.Models.Request;
using IMDBAPI.Models.Response;

namespace IMDBAPI.Services
{
    public interface IGenreService
    {
        public IEnumerable<GenreResponse> GetAllGenres();
        public GenreResponse GetGenreById(int Id);
        public void AddGenre(GenreRequest genre);
        public void UpdateGenre(int Id, GenreRequest genre);
        public void DeleteGenre(int Id);

    }
}
