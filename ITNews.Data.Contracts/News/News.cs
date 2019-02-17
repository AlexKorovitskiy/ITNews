using RepositoryModels.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryModels
{
    public class News : EntityBaseNamed
    {
        public string Description { get; set; }
        public int SectionId { get; set; }
        public virtual Section Section { get; set; }
        public virtual ICollection<NewsTag> NewsTags { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public virtual User Author { get; set; }
    }
}
