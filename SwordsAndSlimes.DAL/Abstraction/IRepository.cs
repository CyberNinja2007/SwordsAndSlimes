using System.Collections.Generic;

namespace SwordsAndSlimes.DAL.Abstraction
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(string name);
        //IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(string name);
    }
}