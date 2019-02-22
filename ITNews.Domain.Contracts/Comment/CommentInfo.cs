using DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITNews.Domain.Contracts.Comment
{
    public class CommentInfo : DomainInfoBase
    {
        public string Content { get; set; }
        public int NewsId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int AuthorId { get; set; }
    }
}
