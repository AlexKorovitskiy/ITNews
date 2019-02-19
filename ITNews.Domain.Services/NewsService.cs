using DomainModels.News;
using DomainModels.ServiceInterfaces;
using ITNews.Data.Contracts;
using ITNews.Data.Contracts.RepositoryInterfaces;
using Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain
{
    public class NewsService : AbstractService<NewsInfo, News>, INewsService
    {
        INewsRepository newsRepository;
        public NewsService(INewsRepository repository)
            : base(repository)
        {
            this.newsRepository = repository;
        }

        public IEnumerable<NewsInfo> GetNews(int userId = 0, int sectionId = 0)
        {
            Expression<Func<News, bool>> conditionExpression = (x =>
            (userId == 0 || x.AuthorId == userId)
            && (sectionId == 0 || x.SectionId == sectionId));

            var news = newsRepository.GetNews(conditionExpression,
                x => x.Author);
            return AutoMapper.Mapper.Map<IEnumerable<NewsInfo>>(news);
        }
        
    }
}
