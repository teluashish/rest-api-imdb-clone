using System;
using System.Collections.Generic;
using IMDBAPI.Models.Request;
using IMDBAPI.Models.Response;

namespace IMDBAPI.Services
{
    public interface IProducerService
    {
        public IEnumerable<ProducerResponse> GetAllProducers();
        public ProducerResponse GetProducerById(int Id);
        public int AddProducer(ProducerRequest producer);
        public void UpdateProducer(int Id, ProducerRequest producer);
        public void DeleteProducer(int Id);
    }
}
