using DomainModels.News;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.Section
{
    public class SectionInfo:DomainBaseNamed
    {
        public IEnumerable<NewsInfo> News { get; set; }
    }
}
