using Microsoft.EntityFrameworkCore;
using RepositoryModels;
using RepositoryModels.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public class NewsRepository : AbstractRepository<News>, INewsRepository
    {
        public override void Update(News entity)
        {            //var sudent = GetModelById(entity.Id);
            //ApplicationContext.DbSet<T>().Attach(entity);
            //var list = ApplicationContext.Set<News>().ToList();
            var dbObject = ApplicationContext.Set<News>().Find(entity.Id);
            dbObject.Content = entity.Content;
            dbObject.Description = entity.Description;
            dbObject.Name = entity.Name;
            dbObject.NewsTags = entity.NewsTags;
            //ApplicationContext.Entry(n).CurrentValues.SetValues(entity);

            //ApplicationContext.Entry(entity).State = EntityState.Modified;
            ApplicationContext.SaveChanges();

            return;
        }

        public IEnumerable<News> GetNewsForUser(int userId)
        {
            return ApplicationContext.Set<News>()
                .Where(x => x.AuthorId == userId)
                .Include(x => x.Author)
                .Include(x => x.Section)
                .Include(x => x.NewsTags)
                    .ThenInclude(x => x.Tag)
                .ToList();
        }
    }
}
