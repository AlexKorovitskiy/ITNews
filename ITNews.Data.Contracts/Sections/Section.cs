using System;
using System.Collections.Generic;
using System.Text;

namespace ITNews.Data.Contracts
{
    public class Section : EntityBaseNamed
    {
        public virtual IEnumerable<News> News { get; set; }
    }
}
