using System;
using System.Collections.Generic;
using System.Text;

namespace ITNews.Data.Contracts.Comments
{
    public class Comment: EntityBase
    {
        public string Content { get; set; }
    }
}
