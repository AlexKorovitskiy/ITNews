using DomainModels.Section;
using DomainModels.Tag;
using DomainModels.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.News
{
    public class NewsInfo : DomainBaseNamed
    {
        public string Description { get; set; }
        public int SectionId { get; set; }
        public SectionInfo Section { get; set; }
        public IEnumerable<TagInfo> Tags { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public UserInfo Author { get; set; }
    }
}
