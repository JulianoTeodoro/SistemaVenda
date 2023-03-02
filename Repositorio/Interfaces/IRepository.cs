using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();
        T GetById(Expression<Func<T, bool>> predicates);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
