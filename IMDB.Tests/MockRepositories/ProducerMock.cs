using System;
using IMDBAPI.Repositories;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using System.Collections.Generic;
using IMDBAPI.Models.Database;
using System.Linq;

namespace IMDB.Tests
{
    public class ProducerMock
    {
        public static readonly Mock<IProducerRepository> producerRepoMock = new Mock<IProducerRepository>();
        public static List<Producer> producers = new()
        {
            new Producer{ Id = 1, Name = "Arjun", Gender = "Male", Bio = "Indian", Dob = new DateTime(1979,03,02) },
            new Producer{ Id = 2, Name = "Tom", Gender = "Male", Bio = "American", Dob = new DateTime(1973, 06, 22) }
        };


        public static void MockInitialize()
        {
            producerRepoMock.Setup(_ => _.GetAllProducers()).Returns(() => { return producers; });
            producerRepoMock.Setup(_ => _.GetProducerById(It.IsAny<int>())).Returns((int i) => producers.Where(p => p.Id == i).Single());
            producerRepoMock.Setup(_ => _.UpdateProducer(It.IsAny<int>(), It.IsAny<Producer>())).Callback((int i, Producer p) =>
            {
                var producer = producers.Where(x => x.Id == i).Single();
                producer.Name = p.Name;
                producer.Bio = p.Bio;
                producer.Dob = p.Dob;
                producer.Gender = p.Gender;

            });

            producerRepoMock.Setup(_ => _.DeleteProducer(It.IsAny<int>())).Callback((int i) => { producers.RemoveAll((p) => p.Id == i); });
            producerRepoMock.Setup(_ => _.AddProducer(It.IsAny<Producer>())).Callback((Producer p) => { producers.Add(p); });

        }

    }
}
