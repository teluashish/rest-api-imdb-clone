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

        public void AddActor(Actor actor) =>
            ExecuteProcedure("Insert_Actor", new Actor() { Id = 0, Name = actor.Name, Bio = actor.Bio, Dob = actor.Dob, Gender = actor.Gender });

        public void UpdateActor(int ID, Actor actor) =>
            ExecuteProcedure("Update_Actor", new Actor() { Id = actor.Id, Name = actor.Name, Bio = actor.Bio, Dob = actor.Dob, Gender = actor.Gender });
        

        public void DeleteActor(int ID) => Delete(ID,@"DELETE FROM Actors
                                                       WHERE Actors.ID = @ID");

        IEnumerable<Actor> IActorRepository.GetAllActors() => GetAll(@"SELECT *
                                                                       FROM Actors;");
        
    }

   
}
