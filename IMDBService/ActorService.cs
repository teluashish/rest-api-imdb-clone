using IMDBRepository;
using IMDBDomain;
using System;
using System.Collections.Generic;

namespace IMDBService
{
    public class ActorService
    {
        private ActorRepository _actorRepo = new ActorRepository();

        public Actor GetActor(int index)
        {
            return _actorRepo.GetActor(index - 1 );
        }

        public void AddActor(string name, string dob)
        {
            DateTime date;

            if (ValidationService.IsValidName(name) && ValidationService.IsValidDateOfBirth(dob, out date))
            {
                Actor actor = new Actor
                {
                    ID = _actorRepo.GetCount() + 1,
                    Name = name,
                    DOB = DateTime.Parse(dob)
                };

                _actorRepo.AddActor(actor);
            }
        }
        public void ShowAllActors()
        {
            int i = 1;
            foreach (var actor in _actorRepo.GetActors())
            {
                Console.WriteLine(i + ": " + actor.Name);
                i++;
            }
        }
        public List<Actor> GetAllActors()
        {
            return _actorRepo.GetAllActors();
        }

    }
}