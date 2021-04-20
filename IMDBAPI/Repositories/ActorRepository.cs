using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using IMDBAPI.Models.Database;
using Microsoft.Extensions.Options;

namespace IMDBAPI.Repositories
{
    public class ActorRepository : IActorRepository
    {

        private readonly ConnectionString _connectionString;
      

        public ActorRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString.Value;
            
        }
        public IEnumerable<Actor> GetAllActors(){
            using var connection = new SqlConnection(_connectionString.DB);
            return connection.Query<Actor>(@"SELECT * FROM Actors;");
        }
        public Actor GetActorById(int ID){
            using var connection = new SqlConnection(_connectionString.DB);
            return connection.QuerySingle<Actor>(@"Select * FROM Actors A WHERE A.ID = " + ID + ";");
        }
        public void AddActor(Actor actor) { 
            using var connection = new SqlConnection(_connectionString.DB);
            connection.Execute("Insert_Actor", new { actor.Name, actor.Bio, actor.Dob, actor.Gender }, commandType: CommandType.StoredProcedure);
        }

        public void UpdateActor(int ID, Actor actor){
            using var connection = new SqlConnection(_connectionString.DB);
            connection.Execute("Update_Actor", new { ID, actor.Name, actor.Bio, actor.Dob, actor.Gender }, commandType: CommandType.StoredProcedure);
        }
        public void DeleteActor(int ID){
            using var connection = new SqlConnection(_connectionString.DB);
            connection.Execute(@"DELETE FROM Actors WHERE Actors.ID = @ID", new { ID });
        }

   

    }

   
}
