using RepositoryModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryModels.RepositoryInterfaces
{
    public interface IUserRepository: IEntityRepository<User>
    {
        IQueryable<User> GetUser();
    }
}
