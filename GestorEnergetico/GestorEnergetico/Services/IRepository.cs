using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorEnergetico.Services
{
    public interface IRepository<T> where T : class
    {
        void Insert(T obj);
        void Update(T obj);
        T Get(Guid id);
        T Get(int id);
        IEnumerable<T> GetAll();
        void Delete(Guid id);
    }
}
