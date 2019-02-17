using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryModels
{
    public class Tag : EntityBaseNamed
    {
        public virtual ICollection<NewsTag> NewsTags { get; set; }
    }
}
