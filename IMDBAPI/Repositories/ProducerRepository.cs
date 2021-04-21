using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using IMDBAPI.Models.Database;
using Microsoft.Extensions.Options;

namespace IMDBAPI.Repositories
{
    public class ProducerRepository : BaseRepository<Producer>, IProducerRepository
    {

        private readonly ConnectionString _connectionString;


        public ProducerRepository(IOptions<ConnectionString> connectionString) : base(connectionString)
        {
            _connectionString = connectionString.Value;

        }


        public Producer GetProducerById(int ID) => GetById(@"Select * FROM Producers A WHERE A.ID = " + ID + ";");

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
        public void DeleteProducer(int ID) => Delete(ID, @"DELETE FROM Producers WHERE Producers.ID = @ID");

        IEnumerable<Producer> IProducerRepository.GetAllProducers() => GetAll(@"SELECT * FROM Producers;");

    }


}
