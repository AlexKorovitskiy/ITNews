using DomainModels.ServiceInterfaces;
using DomainModels.Users;
using RepositoryModels.RepositoryInterfaces;
using RepositoryModels.Users;
using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class RoleService : AbstractService<RoleInfo, Role>, IRoleService
    {
        IRoleRepository repository;
        public RoleService(IRoleRepository repository)
            : base(repository)
        {
            this.repository = repository;
        }
    }
}
