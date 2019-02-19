using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ITNews.Data.Contracts.RepositoryInterfaces
{
    public interface INewsRepository : IEntityRepository<News>
    {
        IEnumerable<News> GetNews(Expression<Func<News, bool>> conditions, params Expression<Func<News, object>>[] includes);
    }
}
