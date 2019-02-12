using DomainModels.News;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.ServiceInterfaces
{
    public interface INewsService : IInfoModelService<NewsInfo>
    {
        IEnumerable<NewsInfo> GetNewsForUser(int userId);
    }
}
