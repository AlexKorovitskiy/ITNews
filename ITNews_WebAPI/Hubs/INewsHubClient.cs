using DomainModels.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITNews_WebAPI.Hubs
{
    public interface INewsHubClient
    {
        Task AddNews(NewsInfo user);
        Task UpdateNews(NewsInfo user);
        Task RemoveNews(int id);
    }
}
