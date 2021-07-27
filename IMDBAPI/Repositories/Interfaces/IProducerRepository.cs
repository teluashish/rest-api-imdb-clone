using System;
using System.Collections.Generic;
using IMDBAPI.Models.Database;

namespace IMDBAPI.Repositories
{
    public interface IProducerRepository
    {
        public IEnumerable<Producer> GetAllProducers();
        public Producer GetProducerById(int Id);
        public int AddProducer(Producer producer);
        public void UpdateProducer(int Id, Producer producer);
        public void DeleteProducer(int Id);

    }
}
