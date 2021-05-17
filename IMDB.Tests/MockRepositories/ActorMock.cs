using System;
using IMDBAPI.Repositories;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using System.Collections.Generic;
using IMDBAPI.Models.Database;
using System.Linq;

namespace IMDB.Tests
{
    public class ActorMock
    {
        public static readonly Mock<IActorRepository> actorRepoMock;
        public static readonly List<Actor> actorList;

        static ActorMock() {
            actorRepoMock = new();
            actorList = new();

        }

        public static void MockInitialize() {

            actorRepoMock.Setup(_ => _.GetAllActors())
                .Returns(() => {
                    return actorList;
                });


            actorRepoMock.Setup(_ => _.GetActorById(It.IsAny<int>()))
                .Returns((int i) => actorList.Where(x => x.Id == i).SingleOrDefault());


            actorRepoMock.Setup(_ => _.UpdateActor(It.IsAny<int>(), It.IsAny<Actor>()))
                .Callback((int i, Actor a) => {
                    var actor = actorList.Where(x => x.Id == i).Single();
                    actor.Name = a.Name;
                    actor.Bio = a.Bio;
                    actor.Dob = a.Dob;
                    actor.Gender = a.Gender;

                });


            actorRepoMock.Setup(_ => _.DeleteActor(It.IsAny<int>()))
                .Callback((int i) => {
                    actorList.RemoveAll((x) => x.Id == i);
                });


            actorRepoMock.Setup(_ => _.AddActor(It.IsAny<Actor>()))
                .Callback((Actor a) => {
                    actorList.Add(a);
                    
                });

        }


    }
}
