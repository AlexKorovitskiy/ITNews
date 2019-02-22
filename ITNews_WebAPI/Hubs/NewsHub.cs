using DomainModels.News;
using ITNews.Domain.Contracts.Comment;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITNews_WebAPI.Hubs
{
    public class NewsHub : Hub<INewsHubClient>
    {
        public void AddNews(NewsInfo news)
        {
            Clients.All.AddNews(news);
        }

        public void UpdateNews(NewsInfo news)
        {
            Clients.All.UpdateNews(news);
        }

        public void RemoveNews(int id)
        {
            Clients.All.RemoveNews(id);
        }
    }
}
