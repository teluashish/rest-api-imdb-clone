using System;
using System.Collections.Generic;
using IMDBAPI.Models.Database;

namespace IMDBAPI.Models.Response
{
    public class MovieResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Plot { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Genre> Genres { get; set; }
        public int ProducerId { get; set; }
        public string CoverImage { get; set; }
    }
}
