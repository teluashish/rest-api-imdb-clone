using System.Collections.Generic;
using IMDBDomain;
using System;
using System.Linq;

namespace IMDBRepository
{
    public class ProducerRepository
    {
        private readonly List<Producer> _producerList;
        public ProducerRepository()
        {
            _producerList = new List<Producer>();
        }
        public void AddProducer(Producer producer)
        {
            _producerList.Add(producer);
        }
        public Producer GetProducer(int idx) {

            return _producerList[idx];
        }

        public IEnumerable<Producer> GetProducers()
        {
            foreach (var producer in _producerList)
                yield return producer;

        }
        public int GetCount()
        {
            return _producerList.Count;
        }

        public List<Producer> GetAllProducers()
        {
            return _producerList.ToList();
        }

    }
}