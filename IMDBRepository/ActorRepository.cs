using System.Collections.Generic;
using IMDBDomain;
using System.Linq;

namespace IMDBRepository
{
    public class producerRepository
    {
        private readonly List<producer> _producerList;
        public producerRepository()
        {
            _producerList = new List<producer>();
        }
        public void Addproducer(producer producer)
        {
            _producerList.Add(producer);
        }
        public producer Getproducer(int idx)
        {
            return _producerList[idx];
        }
        public int GetCount()
        {
            return _producerList.Count;
        }
        public IEnumerable<producer> Getproducers()
        {
            foreach(var producer in _producerList)
                yield return producer;
        }

        public List<producer> GetAllproducers()
        {
            return _producerList.ToList();
        }

    }
}
