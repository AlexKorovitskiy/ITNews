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
using Newtonsoft.Json;

namespace ITNews_WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class NewsController : ITNewsBaseController
    {
        INewsService newsService;
        NewsHub newsHub;
        public NewsController(INewsService newsService)
        {
            this.newsService = newsService;
            this.newsHub = new NewsHub();
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
            newsHub.AddNews(news).Start();
        }

        [Authorize(Roles = "admin,writer")]
        [Route("EditNews")]
        [HttpPost]
        public void EditNews(NewsInfo news)
        {
            newsService.Update(news);
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
        }
    }
}