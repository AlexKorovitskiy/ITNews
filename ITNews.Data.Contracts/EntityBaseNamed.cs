using System;
using System.Collections.Generic;
using System.Text;

namespace ITNews.Data.Contracts
{
    public class EntityBaseNamed : EntityBase, IentityBaseName
    {
        public string Name { get; set; }
    }
}
