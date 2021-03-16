using IMDBRepository;
using IMDBDomain;
using System;
using System.Collections.Generic;

namespace IMDBService
{
    public class ProducerService
    {
        private ProducerRepository _producerRepo = new ProducerRepository();

        public Producer GetProducer(int index)
        {
            Console.WriteLine(index+""+_producerRepo.GetCount());
            return _producerRepo.GetProducer(index);
        }

        public void AddProducer(string name, string dob) {
            DateTime date ;
            if (ValidationService.IsValidName(name) && ValidationService.IsValidDateOfBirth(dob, out date)) {
                Producer producer = new Producer
                {
                    ID = _producerRepo.GetCount() + 1,
                    Name = name,
                    DOB = DateTime.Parse(dob)
            };
               _producerRepo.AddProducer(producer);
            }
         
           
        }
        public void ShowAllProducers()
        {
            int i = 1;
            foreach (var producer in _producerRepo.GetProducers())
            {
                Console.WriteLine(i+": "+producer.Name);
                i++;
            }
        }

        public List<Producer> GetAllProducers()
        {
            return _producerRepo.GetAllProducers();
        }

    }
}
