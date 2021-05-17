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

        public Producer GetProducerById(int ID) => GetSingle(@"Select *
                                                       FROM Producers P
                                                       WHERE P.ID = " + ID + ";");

        public Producer GetProducerByName(string name) => GetSingle(@"Select *
                                                                FROM Producers P
                                                                WHERE P.Name = " + "'" + name + "'" + ";");

        public void AddProducer(Producer producer) =>
            ExecuteProcedure("Insert_Producer", new Producer() { Name = producer.Name, Bio = producer.Bio, Dob = producer.Dob, Gender = producer.Gender });

        public void UpdateProducer(int ID, Producer producer) =>
            ExecuteProcedure("Update_Producer", new Producer() { Id = producer.Id, Name = producer.Name, Bio = producer.Bio, Dob = producer.Dob, Gender = producer.Gender });


        public void DeleteProducer(int ID) => Delete(ID, @"DELETE FROM Producers
                                                       WHERE Producers.ID = @ID");

        IEnumerable<Producer> IProducerRepository.GetAllProducers() => GetAll(@"SELECT *
                                                                       FROM Producers;");

    }


}
