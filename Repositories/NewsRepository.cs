using Microsoft.EntityFrameworkCore;
using RepositoryModels;
using RepositoryModels.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repositories
{
    public class NewsRepository : AbstractRepository<News>, INewsRepository
    {
        public override void Update(News entity)
        {
            var dbObject = ApplicationContext.Set<News>()
                .Include(x => x.NewsTags)
                .ThenInclude(x => x.Tag)
                .FirstOrDefault(x => x.Id == entity.Id);
            dbObject.Content = entity.Content;
            dbObject.Description = entity.Description;
            dbObject.Name = entity.Name;

            DeleteUnselectedItems(dbObject, entity);
            AddNewsTagsToDataBaseEntity(dbObject, entity);

            ApplicationContext.SaveChanges();

            return;
        }

        public override void Create(News entity)
        {
            foreach (var newsTag in entity.NewsTags)
            {
                ReplaceExistingTagWithNullIfNecessary(newsTag);
            }
            base.Create(entity);
        }

        public IEnumerable<News> GetNews(Expression<Func<News, bool>> conditions, 
            params Expression<Func<News, object>>[] includes)
        {
            var newsQuery = ApplicationContext.Set<News>().AsQueryable();
            newsQuery = newsQuery.Where(conditions ?? (x => true));
            foreach (var item in includes)
            {
                newsQuery = newsQuery.Include(item);
            }
            newsQuery = newsQuery.Include(x => x.NewsTags)
                    .ThenInclude(x => x.Tag);
            return newsQuery.ToList();

            return ApplicationContext.Set<News>()
                .Include(x => x.Author)
                .Include(x => x.Section)
                .Include(x => x.NewsTags)
                    .ThenInclude(x => x.Tag)
                .ToList();
        }

        private void DeleteUnselectedItems(News entityFromDataBase, News entityFromService)
        {
            foreach (var newsTag in entityFromDataBase.NewsTags)
            {
                var sameItemInNewCollection = entityFromService.NewsTags.FirstOrDefault(x => x.TagId == newsTag.TagId);
                if (sameItemInNewCollection == null)
                {
                    ApplicationContext.Entry(newsTag).State = EntityState.Deleted;
                }
            }
        }

        private void AddNewsTagsToDataBaseEntity(News entityFromDataBase, News entityFromService)
        {
            foreach (var newsTag in entityFromService.NewsTags)
            {
                ReplaceExistingTagWithNullIfNecessary(newsTag);
                var newsTagInDataBase = entityFromDataBase.NewsTags.FirstOrDefault(x => x.TagId > 0 && x.TagId == newsTag.TagId);
                if (newsTagInDataBase == null)
                    entityFromDataBase.NewsTags.Add(newsTag);
            }
        }
        private void ReplaceExistingTagWithNullIfNecessary(NewsTag newsTag)
        {
            newsTag.Tag = newsTag.TagId > 0 ? null : newsTag.Tag;
        }
    }
}
