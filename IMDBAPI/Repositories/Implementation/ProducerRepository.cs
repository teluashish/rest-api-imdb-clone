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

        public int AddProducer(Producer producer) {
            int id;
            using (SqlConnection connection = new SqlConnection(_connectionString.DB))
            using (SqlCommand cmd = new SqlCommand("dbo.Insert_Producer", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.Int);
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@Bio", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@Dob", SqlDbType.Date);
                cmd.Parameters.Add("@Gender", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@Max_ID", SqlDbType.Int).Direction = ParameterDirection.Output;


                cmd.Parameters["@Id"].Value = producer.Id;
                cmd.Parameters["@Name"].Value = producer.Name;
                cmd.Parameters["@Bio"].Value = producer.Bio;
                cmd.Parameters["@Dob"].Value = producer.Dob;
                cmd.Parameters["@Gender"].Value = producer.Gender;

                connection.Open();
                cmd.ExecuteNonQuery();

                id = Convert.ToInt32(cmd.Parameters["@Max_ID"].Value);

            }
            return id;
        }

        public void UpdateProducer(int ID, Producer producer) =>
            ExecuteProcedure("Update_Producer", new Producer() { Id = producer.Id, Name = producer.Name, Bio = producer.Bio, Dob = producer.Dob, Gender = producer.Gender });


        public void DeleteProducer(int ID) => Delete(ID, @"DELETE FROM Producers
                                                       WHERE Producers.ID = @ID");

        IEnumerable<Producer> IProducerRepository.GetAllProducers() => GetAll(@"SELECT *
                                                                       FROM Producers;");

    }


}
