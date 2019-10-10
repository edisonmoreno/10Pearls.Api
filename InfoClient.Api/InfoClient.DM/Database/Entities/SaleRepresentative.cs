using System;
using System.Collections.Generic;

namespace InfoClient.DM.Database
{
    public partial class SaleRepresentative
    {
        public SaleRepresentative()
        {
            Visit = new HashSet<Visit>();
        }

        public int IdSrepresentative { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Visit> Visit { get; set; }
    }
}
