using Microsoft.EntityFrameworkCore;
using RepositoryModels.RepositoryInterfaces;
using RepositoryModels.Users;
using System;
using System.Linq;

namespace Repositories
{
    public class UserRepository : AbstractRepository<User>, IUserRepository
    {
        public IQueryable<User> GetUser()
        {
            return ApplicationContext.Set<User>()
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role);
        }
        public override User GetModelById(int id)
        {
            return ApplicationContext.Set<User>()
                .Where(t => t.Id.Equals(id))
                .Include(x => x.News)
                .Include(x => x.UserRoles).ThenInclude(x => x.Role)
                .FirstOrDefault();
        }
    }
}
