using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryModels.RepositoryInterfaces
{
    public interface INewsRepository : IEntityRepository<News>
    {
        IEnumerable<News> GetNewsForUser(int userId);
    }
}
