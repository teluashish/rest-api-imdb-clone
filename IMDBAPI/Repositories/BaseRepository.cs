using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using IMDBAPI.Models.Database;
using Microsoft.Extensions.Options;

namespace IMDBAPI.Repositories
{
    public class BaseRepository<TClass>
    {
        private readonly ConnectionString _connectionString;


        public BaseRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString.Value;

        }
        public IEnumerable<TClass> GetAll(string query)
        {
            using var connection = new SqlConnection(_connectionString.DB);
            return connection.Query<TClass>(query);
        }
        public TClass GetById(string query)
        {
            using var connection = new SqlConnection(_connectionString.DB);
            return connection.QuerySingle<TClass>(query);
        }

        public void Delete(int ID,string query)
        {
            using var connection = new SqlConnection(_connectionString.DB);
            connection.Execute(query, new { ID });
        }

    }
}
