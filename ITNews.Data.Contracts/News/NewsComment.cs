using System;
using System.Collections.Generic;
using System.Text;

namespace ITNews.Data.Contracts
{
    public class NewsComment
    {
        public int NewsId { get; set; }
        public News News { get; set; }
    }
}
