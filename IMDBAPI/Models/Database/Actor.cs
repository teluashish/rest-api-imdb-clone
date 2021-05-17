﻿using System;
using System.Collections;
namespace IMDBAPI.Models.Database
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }

    }
}
