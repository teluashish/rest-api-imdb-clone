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
        public static readonly Mock<IActorRepository> actorRepoMock = new Mock<IActorRepository>();
        public static List<Actor> actorss = new()
        {
                    new Actor()
                    {
                        Id = 1,
                        Name = "Christian Bale",
                        Gender = "Male",
                        Bio = "British",
                        Dob = new DateTime(1979, 03, 02)
                        
                    },
                    new Actor()
                    {
                        Id = 2,
                        Name = "Mila Kunis",
                        Gender = "Female",
                        Bio = "Ukranian",
                        Dob = new DateTime(1973, 06, 22)
                    } };


        public static void MockInitialize() {
                actorRepoMock.Setup(_ => _.GetAllActors()).Returns(() => { return actorss; });
                actorRepoMock.Setup(_ => _.GetActorById(It.IsAny<int>())).Returns((int i) => actorss.Where(x => x.Id == i).Single());
                actorRepoMock.Setup(_ => _.UpdateActor(It.IsAny<int>(), It.IsAny<Actor>())).Callback((int i, Actor a) =>
                {
                    var actor = actorss.Where(x => x.Id == i).Single();
                    actor.Name = a.Name;
                    actor.Bio = a.Bio;
                    actor.Dob = a.Dob;
                    actor.Gender = a.Gender;

                });

            actorRepoMock.Setup(_ => _.DeleteActor(It.IsAny<int>())).Callback((int i) => { actorss.RemoveAll((x) => x.Id == i); });
            actorRepoMock.Setup(_ => _.AddActor(It.IsAny<Actor>())).Callback((Actor a) => { actorss.Add(a); });
  

        }

    }
}
