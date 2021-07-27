using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using IMDBAPI.Models.Database;
using Microsoft.Extensions.Options;

namespace IMDBAPI.Repositories
{
    public class ActorRepository : BaseRepository<Actor>, IActorRepository
    {
        private readonly ConnectionString _connectionString;
      

        public ActorRepository(IOptions<ConnectionString> connectionString):base(connectionString)
        {
            _connectionString = connectionString.Value;

        }
        
        public Actor GetActorById(int ID) => GetSingle(@"Select *
                                                       FROM Actors A
                                                       WHERE A.ID = " + ID + ";");

        public Actor GetActorByName(string name) => GetSingle(@"Select *
                                                                FROM Actors A
                                                                WHERE A.Name = " + "'" +name +"'" + ";");

        public int AddActor(Actor actor)
        {
            int id;
            using (SqlConnection connection = new SqlConnection(_connectionString.DB))
            using (SqlCommand cmd = new SqlCommand("dbo.Insert_Actor", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.Int);
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@Bio", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@Dob", SqlDbType.Date);
                cmd.Parameters.Add("@Gender", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@Max_ID", SqlDbType.Int).Direction = ParameterDirection.Output;


                cmd.Parameters["@Id"].Value = actor.Id;
                cmd.Parameters["@Name"].Value = actor.Name;
                cmd.Parameters["@Bio"].Value = actor.Bio;
                cmd.Parameters["@Dob"].Value = actor.Dob;
                cmd.Parameters["@Gender"].Value = actor.Gender;

                connection.Open();
                cmd.ExecuteNonQuery();

                id = Convert.ToInt32(cmd.Parameters["@Max_ID"].Value);
      
            }
            return id;
        }

        public void UpdateActor(int ID, Actor actor) =>
            ExecuteProcedure("Update_Actor", new Actor() { Id = actor.Id, Name = actor.Name, Bio = actor.Bio, Dob = actor.Dob, Gender = actor.Gender });
        

        public void DeleteActor(int ID) => Delete(ID,@"DELETE FROM Actors
                                                       WHERE Actors.ID = @ID");

        IEnumerable<Actor> IActorRepository.GetAllActors() => GetAll(@"SELECT *
                                                                       FROM Actors;");
        
    }

   
}
