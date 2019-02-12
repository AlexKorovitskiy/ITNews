using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryModels
{
    public class EntityBaseNamed : EntityBase, IentityBaseName
    {
        public string Name { get; set; }
    }
}
