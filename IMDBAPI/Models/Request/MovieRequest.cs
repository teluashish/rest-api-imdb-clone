using System;
using System.Collections.Generic;
using IMDBAPI.Models.Database;

namespace IMDBAPI.Models.Request
{
    public class MovieRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Plot { get; set; }
        public string MovieActorMappingString { get; set; }
        public string MovieGenreMappingString { get; set; }
        public int ProducerId { get; set; }
        public string CoverImage { get; set; }

    }
}
