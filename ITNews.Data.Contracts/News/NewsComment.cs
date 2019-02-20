using ITNews.Data.Contracts.Comments;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITNews.Data.Contracts
{
    public class NewsComment
    {
        public int NewsId { get; set; }
        public virtual News News { get; set; }
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
