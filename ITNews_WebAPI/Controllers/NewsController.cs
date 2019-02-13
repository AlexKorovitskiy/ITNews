using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels;
using DomainModels.News;
using DomainModels.ServiceInterfaces;
using ITNews_WebAPI.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace ITNews_WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class NewsController : ITNewsBaseController
    {
        INewsService newsService;
        IHubContext<NewsHub, INewsHubClient> newsContext;

        public NewsController(INewsService newsService, IHubContext<NewsHub, INewsHubClient> newsContext)
        {
            this.newsService = newsService;
            this.newsContext = newsContext;
        }

        [Route("GetAllNews")]
        [HttpGet]
        public IEnumerable<NewsInfo> GetAllNews()
        {
            var news = newsService.GetModelCollections();

            return news;
        }

        [Authorize]
        [Route("getnews")]
        [HttpGet]
        public IActionResult GetNews(int id)
        {
            if (id <= 0)
            {
                throw new Exception();
            }
            var news = newsService.GetModelById(id);
            return Json(JsonConvert.SerializeObject(news, Formatting.Indented,
                new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects }));
        }

        [Authorize(Roles = "admin,writer")]
        [HttpPost]
        [Route("AddNews")]
        public void AddNews(NewsInfo news)
        {
            news.AuthorId = UserId;
            newsService.Create(news);
            newsContext.Clients.All.AddNews(news);
        }

        [Authorize(Roles = "admin,writer")]
        [Route("EditNews")]
        [HttpPost]
        public void EditNews(NewsInfo news)
        {
            newsService.Update(news);
            newsContext.Clients.All.UpdateNews(news);
        }

        [HttpGet]
        [Authorize(Roles = "admin,writer")]
        [Route("DeleteNews")]
        public void DeleteNews(int id)
        {
            if (!CurrentUserHasRole("admin"))
            {
                var news = newsService.GetModelById(id);
                if (news == null)
                {
                    return;
                }
                if (news.AuthorId != UserId)
                {
                    throw new UnauthorizedAccessException();
                }
            }
            newsService.Delete(id);
            newsContext.Clients.All.RemoveNews(id);
        }
    }
}