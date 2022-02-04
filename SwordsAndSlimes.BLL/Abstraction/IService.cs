using System.Collections.Generic;

namespace SwordsAndSlimes.BLL.Abstraction
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(string name);
        void Create(T item);
        void Update(T item);
        void Delete(string name);
    }
}