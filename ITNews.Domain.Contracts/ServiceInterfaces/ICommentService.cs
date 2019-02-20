using DomainModels;
using ITNews.Domain.Contracts.Comment;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITNews.Domain.Contracts.ServiceInterfaces
{
    public interface ICommentService : IInfoModelService<CommentInfo>
    {
    }
}
