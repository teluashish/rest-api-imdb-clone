using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using IMDBAPI.Models.Database;
using Microsoft.Extensions.Options;

namespace IMDBAPI.Repositories
{
    public class GenreRepository : BaseRepository<Genre>,IGenreRepository
    {

        private readonly ConnectionString _connectionString;

        public GenreRepository(IOptions<ConnectionString> connectionString):base(connectionString)
        {
            _connectionString = connectionString.Value;
           
        }
        public IEnumerable<Genre> GetAllGenres() => GetAll(@"SELECT *
                                                             FROM Genres;");
   
        public Genre GetGenreById(int ID) => GetSingle(@"Select *
                                                       FROM Genres A
                                                       WHERE A.ID = " + ID + ";");
      
        public void AddGenre(Genre genre) =>
            ExecuteProcedure("Insert_Genre", new Genre() {  Name = genre.Name });
        

        public void UpdateGenre(int ID, Genre genre) =>
            ExecuteProcedure("Update_Genre", new Genre() { Id = genre.Id, Name = genre.Name });
        

        public void DeleteGenre(int ID) => Delete(ID,@"DELETE FROM Genres
                                                       WHERE Genres.ID = @ID");
        
    }


}
