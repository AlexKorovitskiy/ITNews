using ITNews.Data.Contracts.Comments;
using ITNews.Data.Contracts.RepositoryInterfaces;
using Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITNews.Data.EntityFramework
{
    public class CommentRepository: AbstractRepository<Comment>, ICommentRepository
    {
    }
}
