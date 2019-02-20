using ITNews.Data.Contracts.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITNews.Data.Contracts.Comments
{
    public class Comment : EntityBase
    {
        public string Content { get; set; }
        public virtual NewsComment NewsComment { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual User Author { get; set; }
        public int AuthorId { get; set; }
    }
}
