using DomainModels.News;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITNews_WebAPI.Hubs
{
    public class NewsHub : Hub
    {
        public async Task AddNews(NewsInfo news)
        {
            await Clients.All.SendAsync("addNewsFromServer", news);
        }

        public async Task RemoveNews(int id)
        {
            await Clients.All.SendAsync("deleteNewsFromServer", id );
        }
    }
}
