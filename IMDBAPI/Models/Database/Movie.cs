using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMDBAPI.Models.Database
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Plot { get; set; }
        public int ProducerId { get; set; }
        public string CoverImage { get; set; }



    }
}
