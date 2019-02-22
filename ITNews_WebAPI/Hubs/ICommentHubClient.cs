using ITNews.Domain.Contracts.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITNews_WebAPI.Hubs
{
    public interface ICommentsHubClient
    {
        Task AddComment(CommentInfo comment);
    }
}
