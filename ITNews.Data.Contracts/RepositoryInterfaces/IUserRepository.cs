using ITNews.Data.Contracts.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITNews.Data.Contracts.RepositoryInterfaces
{
    public interface IUserRepository: IEntityRepository<User>
    {
        IQueryable<User> GetUser();
    }
}
