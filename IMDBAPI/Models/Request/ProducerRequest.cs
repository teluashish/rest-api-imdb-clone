using System;
namespace IMDBAPI.Models.Request
{
    public class ProducerRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
    }
}
