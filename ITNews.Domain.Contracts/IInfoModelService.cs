using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModels
{
    public interface IInfoModelService<T>
    {
        IEnumerable<T> GetModelCollections();
        void Create(T student);
        T GetModelById(int id);
        void Update(T model);
        void Delete(int id);
    }
}
