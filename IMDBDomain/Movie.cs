using System.Collections.Generic;


namespace IMDBDomain
{
    public class Movie
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Plot { get; set; }
        public int Year { get; set; }
        public List<Actor> ActorList { get; set; }
        public Producer Producer { get; set; }

        public Movie()
        {
            ActorList = new List<Actor>();
        }


    }
}
