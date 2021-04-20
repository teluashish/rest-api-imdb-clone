﻿using System;
using System.Collections.Generic;
using IMDBAPI.Models.Request;
using IMDBAPI.Models.Response;

namespace IMDBAPI.Services
{
    public interface IActorService
    {
        public IEnumerable<ActorResponse> GetAllActors();
        public ActorResponse GetActorById(int Id);
        public void AddActor(ActorRequest actor);
        public void UpdateActor(int Id,ActorRequest actor);
        public void DeleteActor(int Id);

        
    }
}
