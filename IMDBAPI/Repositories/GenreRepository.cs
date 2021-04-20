using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using IMDBAPI.Models.Database;
using Microsoft.Extensions.Options;

namespace IMDBAPI.Repositories
{
    public class GenreRepository : IGenreRepository
    {

        private readonly ConnectionString _connectionString;

        public GenreRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString.Value;
           
        }
        public IEnumerable<Genre> GetAllGenres()
        {
            using var connection = new SqlConnection(_connectionString.DB);
            return connection.Query<Genre>(@"SELECT * FROM Genres;");
        }
        public Genre GetGenreById(int ID)
        {
            using var connection = new SqlConnection(_connectionString.DB);
            return connection.QuerySingle<Genre>(@"Select * FROM Genres A WHERE A.ID = " + ID + ";");
        }
        public void AddGenre(Genre genre)
        {
            using var connection = new SqlConnection(_connectionString.DB);
            connection.Execute("Insert_Genre", new { genre.Name }, commandType: CommandType.StoredProcedure);
        }

        public void UpdateGenre(int ID, Genre genre)
        {
            using var connection = new SqlConnection(_connectionString.DB);
            connection.Execute("Update_Genre", new { ID, genre.Name }, commandType: CommandType.StoredProcedure);
        }

        public void DeleteGenre(int ID)
        {
            using var connection = new SqlConnection(_connectionString.DB);
            connection.Execute(@"DELETE FROM Genres WHERE Genres.ID = @ID", new { ID });
        }



    }


}
