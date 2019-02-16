using Microsoft.Extensions.Configuration;
using RepositoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public abstract class AbstractRepository<T> : IDisposable, IEntityRepository<T> where T : class, IEntityBaseId, new()
    {
        protected ApplicationDbContext ApplicationContext { get; set; }

        public AbstractRepository()
        {
            ApplicationContext = new ApplicationDbContext();
        }

        public virtual void Create(T entity)
        {
            ApplicationContext.Set<T>().Add(entity);
            ApplicationContext.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            T localEntity = ApplicationContext.Set<T>().Local.FirstOrDefault(x => x.Id == id);
            if (localEntity == null)
            {
                localEntity = new T() { Id = id };
                ApplicationContext.Set<T>().Attach(localEntity);
            }
            ApplicationContext.Set<T>().Remove(localEntity);
            ApplicationContext.SaveChanges();
        }

        public virtual T GetModelById(int id)
        {
            return ApplicationContext.Set<T>().FirstOrDefault(t => t.Id.Equals(id));
        }

        public virtual IEnumerable<T> GetModelCollections()
        {
            return ApplicationContext.Set<T>().ToList();
        }

        public virtual void Update(T entity)
        {
            //var sudent = GetModelById(entity.Id);
            //ApplicationContext.DbSet<T>().Attach(entity);
            //var list = ApplicationContext.Set<T>().ToList();
            var findedEntity = ApplicationContext.Set<T>().Find(entity.Id);
            var entry = ApplicationContext.Entry(findedEntity);
            entry.CurrentValues.SetValues(entity);

            //ApplicationContext.Entry(entity).State = EntityState.Modified;
            ApplicationContext.SaveChanges();

            return;
        }

        public IQueryable<T> GetQuery()
        {
            return ApplicationContext.Set<T>().AsQueryable();
        }

        public void Dispose()
        {
            ApplicationContext.Dispose();
        }
    }
}
