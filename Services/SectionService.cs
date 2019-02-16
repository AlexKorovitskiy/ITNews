using DomainModels.Section;
using DomainModels.ServiceInterfaces;
using RepositoryModels;
using RepositoryModels.RepositoryInterfaces;
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
