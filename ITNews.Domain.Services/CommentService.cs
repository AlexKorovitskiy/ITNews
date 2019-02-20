using ITNews.Data.Contracts.Comments;
using ITNews.Data.Contracts.RepositoryInterfaces;
using ITNews.Domain.Contracts.Comment;
using ITNews.Domain.Contracts.ServiceInterfaces;
using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITNews.Domain.Services
{
    public class CommentService : AbstractService<CommentInfo, Comment>, ICommentService
    {
        ICommentRepository repository;
        public CommentService(ICommentRepository repository)
            : base(repository)
        {

        }
    }
}
