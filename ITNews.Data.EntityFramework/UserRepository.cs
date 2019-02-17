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

        public override void Update(User entity)
        {
            var user = ApplicationContext.Set<User>().Include(x=>x.UserRoles).FirstOrDefault(x => x.Id == entity.Id);
            user.Name = entity.Name;
            user.Email = entity.Email;
            foreach (var item in entity.UserRoles)
            {
                if (user.UserRoles.FirstOrDefault(x => x.RoleId == item.RoleId) == null)
                    user.UserRoles.Add(item);
            }
            foreach (var item in user.UserRoles)
            {
                if (entity.UserRoles.FirstOrDefault(x => x.RoleId == item.RoleId) == null)
                    ApplicationContext.Entry(item).State = EntityState.Deleted;
            }

            ApplicationContext.SaveChanges();
        }
    }
}
