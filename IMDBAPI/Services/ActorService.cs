﻿using System;
using System.Collections.Generic;
using IMDBAPI.Models.Database;
using IMDBAPI.Models.Request;
using IMDBAPI.Models.Response;
using IMDBAPI.Repositories;
using System.Linq;


namespace IMDBAPI.Services
{
    public class ActorService:IActorService
    {
        private readonly IActorRepository _actorRepository;
        public ActorService(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public void AddActor(ActorRequest actor)
        {
            _actorRepository.AddActor(new Actor { Id = actor.Id, Bio = actor.Bio, Dob = actor.Dob, Gender = actor.Gender, Name = actor.Name });
        }

        public void DeleteActor(int Id)
        {
            _actorRepository.DeleteActor(Id);
        }

        public ActorResponse GetActorById(int Id)
        {
            var actor = _actorRepository.GetActorById(Id);
            return new ActorResponse { Id = actor.Id, Bio = actor.Bio, Dob = actor.Dob, Gender = actor.Gender, Name = actor.Name };
        }

        public IEnumerable<ActorResponse> GetAllActors()
        {
            return _actorRepository.GetAllActors().Select(actor => new ActorResponse { Id = actor.Id, Bio = actor.Bio, Dob = actor.Dob, Gender = actor.Gender, Name = actor.Name }).ToList<ActorResponse>();
        }

        public void UpdateActor(int Id, ActorRequest actor)
        {
            _actorRepository.UpdateActor(Id,new Actor { Id = actor.Id, Bio = actor.Bio, Dob = actor.Dob, Gender = actor.Gender, Name = actor.Name });
        }
    }  
}
