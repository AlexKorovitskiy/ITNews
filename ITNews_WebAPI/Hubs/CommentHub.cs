using ITNews.Domain.Contracts.Comment;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITNews_WebAPI.Hubs
{
    public class CommentsHub : Hub<ICommentsHubClient>
    {
        public void AddComment(CommentInfo comment)
        {
            Clients.All.AddComment(comment);
        }
    }
}
