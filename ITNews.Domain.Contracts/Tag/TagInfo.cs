using DomainModels.News;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.Tag
{
    public class TagInfo : DomainBaseNamed
    {
        public IEnumerable<NewsInfo> News { get; set; }
    }
}
