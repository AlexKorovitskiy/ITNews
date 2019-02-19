using System;
using System.Collections.Generic;
using System.Text;

namespace ITNews.Data.Contracts
{
    public class Tag : EntityBaseNamed
    {
        public virtual ICollection<NewsTag> NewsTags { get; set; }
    }
}
