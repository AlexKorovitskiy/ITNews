using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels
{
    public class DomainBaseNamed : DomainInfoBase, IDomainBaseName
    {
        public virtual string Name { get; set; }
    }
}
