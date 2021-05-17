using System;
using System.Collections.Generic;
using IMDBAPI.Models.Database;

namespace IMDBAPI.Repositories
{
    public interface IGenreRepository
    {
        public IEnumerable<Genre> GetAllGenres();
        public Genre GetGenreById(int Id);
        public void AddGenre(Genre genre);
        public void UpdateGenre(int Id, Genre genre);
        public void DeleteGenre(int Id);

    }
}
