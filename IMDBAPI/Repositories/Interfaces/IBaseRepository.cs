using System;
using System.Collections.Generic;

namespace IMDBAPI.Repositories
{
    public interface IBaseRepository<TClass>
    {
        public IEnumerable<TClass> GetAll(string query);
        public TClass GetSingle(string query);
        public void Delete(int ID, string query);
        public void ExecuteProcedure(string procedureName, TClass ob);
    }
}
