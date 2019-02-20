using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITNews.Domain.Contracts.Comment;
using ITNews.Domain.Contracts.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITNews_WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CommentController : Controller
    {
        public ICommentService commentService;
        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpPost]
        [Authorize]
        [Route("[action]")]
        public void CreateComment(CommentInfo comment)
        {
            commentService.Create(comment);
        }
    }
}