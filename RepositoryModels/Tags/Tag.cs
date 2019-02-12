using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryModels
{
    public class Tag : EntityBaseNamed
    {
        public virtual IEnumerable<NewsTag> NewsTags { get; set; }
    }
}
