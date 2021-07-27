using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using IMDBAPI.Models.Database;
using Microsoft.Extensions.Options;

namespace IMDBAPI.Repositories
{
    public class BaseRepository<TClass>: IBaseRepository<TClass>
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
        public TClass GetSingle(string query)
        {
            using var connection = new SqlConnection(_connectionString.DB);
            return connection.QuerySingle<TClass>(query);
        }


        public void Delete(int ID,string query)
        {
            using var connection = new SqlConnection(_connectionString.DB);
            connection.Execute(query, new { ID });
        }

        public int ExecuteProcedure(string procedureName, TClass ob)
        {
            using var connection = new SqlConnection(_connectionString.DB);
            return connection.Execute(procedureName, ob, commandType: CommandType.StoredProcedure);
        }



    }
}
