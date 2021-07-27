using System;
using System.Collections.Generic;
using IMDBAPI.Models.Database;
using IMDBAPI.Models.Request;
using IMDBAPI.Models.Response;
using IMDBAPI.Repositories;
using System.Linq;


namespace IMDBAPI.Services
{
    public class ProducerService : IProducerService
    {
        private readonly IProducerRepository _producerRepository;
        public ProducerService(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }

        public int AddProducer(ProducerRequest producer)
        {
           return _producerRepository.AddProducer(new Producer { Id = producer.Id, Bio = producer.Bio, Dob = producer.Dob, Gender = producer.Gender, Name = producer.Name });
        }

        public void DeleteProducer(int Id)
        {
            _producerRepository.DeleteProducer(Id);
        }

        public ProducerResponse GetProducerById(int Id)
        {
            var producer = _producerRepository.GetProducerById(Id);
            return new ProducerResponse { Id = producer.Id, Bio = producer.Bio, Dob = producer.Dob, Gender = producer.Gender, Name = producer.Name };
        }

        public IEnumerable<ProducerResponse> GetAllProducers()
        {
            return _producerRepository.GetAllProducers().Select(producer => new ProducerResponse { Id = producer.Id, Bio = producer.Bio, Dob = producer.Dob, Gender = producer.Gender, Name = producer.Name }).ToList<ProducerResponse>();
        }

        public void UpdateProducer(int Id, ProducerRequest producer)
        {
            _producerRepository.UpdateProducer(Id, new Producer { Id = producer.Id, Bio = producer.Bio, Dob = producer.Dob, Gender = producer.Gender, Name = producer.Name });
        }
    }
}
