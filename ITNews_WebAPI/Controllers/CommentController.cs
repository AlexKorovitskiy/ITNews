using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITNews.Domain.Contracts.Comment;
using ITNews.Domain.Contracts.ServiceInterfaces;
using ITNews_WebAPI.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ITNews_WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CommentController : ITNewsBaseController
    {
        public ICommentService commentService;
        IHubContext<CommentsHub, ICommentsHubClient> commentContext;
        public CommentController(ICommentService commentService, IHubContext<CommentsHub, ICommentsHubClient> commentContext)
        {
            this.commentService = commentService;
            this.commentContext = commentContext;
        }

        [HttpPost]
        [Authorize]
        [Route("[action]")]
        public void CreateComment(CommentInfo comment)
        {
            comment.AuthorId = UserId;
            commentService.Create(comment);
            commentContext.Clients.All.AddComment(comment);
        }
    }
}