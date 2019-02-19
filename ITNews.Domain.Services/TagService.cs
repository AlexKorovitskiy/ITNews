using DomainModels.ServiceInterfaces;
using DomainModels.Tag;
using ITNews.Data.Contracts;
using ITNews.Data.Contracts.RepositoryInterfaces;
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
