using Atividade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade.Services
{
    public interface IGenericMethods<T> where T:class
    {
        void Insert(T obj);
        void Update(T obj);
        T Get(Guid id);
        IEnumerable<T> GetAll();
        void Delete(Guid id);
    }
}
