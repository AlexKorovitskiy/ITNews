using DomainModels.Section;
using DomainModels.ServiceInterfaces;
using ITNews.Data.Contracts;
using ITNews.Data.Contracts.RepositoryInterfaces;
using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class SectionService : AbstractService<SectionInfo, Section>, ISectionService
    {
        public SectionService(ISectionRepository repository)
            : base(repository)
        {

        }
    }
}
