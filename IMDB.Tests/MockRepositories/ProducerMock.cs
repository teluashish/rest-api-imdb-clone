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
        public static readonly Mock<IProducerRepository> producerRepoMock = new();
        public static List<Producer> producerList = new();


        public static void MockInitialize()
        {

            producerRepoMock.Setup(_ => _.GetAllProducers())
                .Returns(() => {
                    return producerList;
                });


            producerRepoMock.Setup(_ => _.GetProducerById(It.IsAny<int>()))
                .Returns((int i) => producerList.Where(x => x.Id == i).SingleOrDefault());


            producerRepoMock.Setup(_ => _.UpdateProducer(It.IsAny<int>(), It.IsAny<Producer>()))
                .Callback((int i, Producer p) => {
                    var producer = producerList.Where(x => x.Id == i).Single();
                    producer.Name = p.Name;
                    producer.Bio = p.Bio;
                    producer.Dob = p.Dob;
                    producer.Gender = p.Gender;

                });


            producerRepoMock.Setup(_ => _.DeleteProducer(It.IsAny<int>()))
                .Callback((int i) => {
                    producerList.RemoveAll((x) => x.Id == i);
                });


            producerRepoMock.Setup(_ => _.AddProducer(It.IsAny<Producer>()))
                .Callback((Producer p) => {
                    producerList.Add(p);
                });

        }


    }
}
