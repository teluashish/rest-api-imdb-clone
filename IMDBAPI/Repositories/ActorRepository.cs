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
        
        
        public Actor GetActorById(int ID) => GetById(@"Select * FROM Actors A WHERE A.ID = " + ID + ";");
     
        public void AddActor(Actor actor) { 
            using var connection = new SqlConnection(_connectionString.DB);
            connection.Execute("Insert_Actor", new { actor.Name, actor.Bio, actor.Dob, actor.Gender }, commandType: CommandType.StoredProcedure);
        }

        public void UpdateActor(int ID, Actor actor){
            using var connection = new SqlConnection(_connectionString.DB);
            connection.Execute("Update_Actor", new { ID, actor.Name, actor.Bio, actor.Dob, actor.Gender }, commandType: CommandType.StoredProcedure);
        }
        public void DeleteActor(int ID) => Delete(ID,@"DELETE FROM Actors WHERE Actors.ID = @ID");

        IEnumerable<Actor> IActorRepository.GetAllActors() => GetAll(@"SELECT * FROM Actors;");
        
    }

   
}
