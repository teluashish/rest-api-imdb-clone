using System;
using System.Collections.Generic;
using IMDBAPI.Models.Database;

namespace IMDBAPI.Repositories
{
    public interface IActorRepository
    {
        public IEnumerable<Actor> GetAllActors();
        public Actor GetActorById(int Id);
        public void AddActor(Actor actor);
        public void UpdateActor(int Id, Actor actor);
        public void DeleteActor(int Id);
        public Actor GetActorByName(string name);

    }
}
