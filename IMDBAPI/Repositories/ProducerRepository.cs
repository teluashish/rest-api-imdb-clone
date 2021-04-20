using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using IMDBAPI.Models.Database;
using Microsoft.Extensions.Options;

namespace IMDBAPI.Repositories
{
    public class ProducerRepository : IProducerRepository
    {

        private readonly ConnectionString _connectionString;
        

        public ProducerRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString.Value;

        }
        public IEnumerable<Producer> GetAllProducers()
        {
            using var connection = new SqlConnection(_connectionString.DB);
            return connection.Query<Producer>(@"SELECT * FROM Producers;");
        }
        public Producer GetProducerById(int ID)
        {
            using var connection = new SqlConnection(_connectionString.DB);
            return connection.QuerySingle<Producer>(@"Select * FROM Producers A WHERE A.ID = " + ID + ";");
        }
        public void AddProducer(Producer producer)
        {
            using var connection = new SqlConnection(_connectionString.DB);
            connection.Execute("Insert_Producer", new { producer.Name, producer.Bio, producer.Dob, producer.Gender }, commandType: CommandType.StoredProcedure);
        }

        public void UpdateProducer(int ID, Producer producer)
        {
            using var connection = new SqlConnection(_connectionString.DB);
            connection.Execute("Update_Producer", new { ID, producer.Name, producer.Bio, producer.Dob, producer.Gender }, commandType: CommandType.StoredProcedure);
        }
        public void DeleteProducer(int ID)
        {
            using var connection = new SqlConnection(_connectionString.DB);
            connection.Execute(@"DELETE FROM Producers A WHERE A.ID = @ID", new { ID });
        }



    }


}
