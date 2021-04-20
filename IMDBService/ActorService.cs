using IMDBRepository;
using IMDBDomain;
using System;
using System.Collections.Generic;

namespace IMDBService
{
    public class producerService
    {
        private producerRepository _producerRepo = new producerRepository();

        public producer Getproducer(int index)
        {
            return _producerRepo.Getproducer(index - 1 );
        }

        public void Addproducer(string name, string dob)
        {
            DateTime date;

            if (ValidationService.IsValidName(name) && ValidationService.IsValidDateOfBirth(dob, out date))
            {
                producer producer = new producer
                {
                    ID = _producerRepo.GetCount() + 1,
                    Name = name,
                    DOB = DateTime.Parse(dob)
                };

                _producerRepo.Addproducer(producer);
            }
        }
        public void ShowAllproducers()
        {
            int i = 1;
            foreach (var producer in _producerRepo.Getproducers())
            {
                Console.WriteLine(i + ": " + producer.Name);
                i++;
            }
        }
        public List<producer> GetAllproducers()
        {
            return _producerRepo.GetAllproducers();
        }

    }
}