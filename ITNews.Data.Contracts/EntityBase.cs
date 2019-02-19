using System;
using System.Collections.Generic;
using System.Text;

namespace ITNews.Data.Contracts
{
    public class EntityBase : IEntityBaseId
    {
        public int Id { get; set; }
    }
}
