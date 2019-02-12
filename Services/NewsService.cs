using DomainModels.News;
using DomainModels.ServiceInterfaces;
using RepositoryModels;
using RepositoryModels.RepositoryInterfaces;
using Services;
using System;
using System.Collections.Generic;
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

        public IEnumerable<NewsInfo> GetNewsForUser(int userId)
        {
            var news = newsRepository.GetNewsForUser(userId);
            return AutoMapper.Mapper.Map<IEnumerable<NewsInfo>>(news);
        }
    }
}
