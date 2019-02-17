using DomainModels.News;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.ServiceInterfaces
{
    public interface INewsService : IInfoModelService<NewsInfo>
    {
        IEnumerable<NewsInfo> GetNews(int userId = 0, int sectionId = 0);
    }
}
