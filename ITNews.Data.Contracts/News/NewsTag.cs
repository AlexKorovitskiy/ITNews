using System;
using System.Collections.Generic;
using System.Text;

namespace ITNews.Data.Contracts
{
    public class NewsTag
    {
        public int NewsId { get; set; }
        public virtual News News { get; set; }
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
