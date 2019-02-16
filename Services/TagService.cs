using DomainModels.ServiceInterfaces;
using DomainModels.Tag;
using RepositoryModels;
using RepositoryModels.RepositoryInterfaces;
using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class TagService : AbstractService<TagInfo, Tag>, ITagService
    {
        private ITagRepository repository;
        public TagService(ITagRepository repository)
            : base(repository)
        {

        }
    }
}
