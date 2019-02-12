using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryModels
{
    public class EntityBase : IEntityBaseId
    {
        public int Id { get; set; }
    }
}
