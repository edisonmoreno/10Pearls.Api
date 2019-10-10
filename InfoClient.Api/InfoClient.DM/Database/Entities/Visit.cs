using System;
using System.Collections.Generic;

namespace InfoClient.DM.Database
{
    public partial class Visit
    {
        public int IdVisit { get; set; }
        public int IdClient { get; set; }
        public DateTime VisitDate { get; set; }
        public int IdSrepresentative { get; set; }
        public int? Net { get; set; }
        public int? VisitTotal { get; set; }
        public string Description { get; set; }

        public virtual Client IdClientNavigation { get; set; }
        public virtual SaleRepresentative IdSrepresentativeNavigation { get; set; }
    }
}
