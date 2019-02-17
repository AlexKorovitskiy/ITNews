using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryModels
{
    public interface IEntityRepository<T>
    {
        void Create(T entity);
        T GetModelById(int id);
        IEnumerable<T> GetModelCollections();
        void Update(T student);
        void Delete(int id);
        IQueryable<T> GetQuery();
    }
}
