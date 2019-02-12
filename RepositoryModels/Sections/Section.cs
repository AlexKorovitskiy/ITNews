using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryModels
{
    public class Section : EntityBaseNamed
    {
        public virtual IEnumerable<News> News { get; set; }
    }
}
