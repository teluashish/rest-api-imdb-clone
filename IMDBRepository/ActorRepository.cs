using System.Collections.Generic;
using IMDBDomain;
using System.Linq;

namespace IMDBRepository
{
    public class ActorRepository
    {
        private readonly List<Actor> _actorList;
        public ActorRepository()
        {
            _actorList = new List<Actor>();
        }
        public void AddActor(Actor actor)
        {
            _actorList.Add(actor);
        }
        public Actor GetActor(int idx)
        {
            return _actorList[idx];
        }
        public int GetCount()
        {
            return _actorList.Count;
        }
        public IEnumerable<Actor> GetActors()
        {
            foreach(var actor in _actorList)
                yield return actor;
        }

        public List<Actor> GetAllActors()
        {
            return _actorList.ToList();
        }

    }
}
