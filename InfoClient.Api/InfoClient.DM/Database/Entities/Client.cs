using System;
using System.Collections.Generic;

namespace InfoClient.DM.Database
{
    public partial class Client
    {
        public Client()
        {
            Visit = new HashSet<Visit>();
        }

        public int IdClient { get; set; }
        public virtual string Nit { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int IdCity { get; set; }
        public int CreditLimit { get; set; }
        public int AvailableCredit { get; set; }
        public int? VisitsPercentage { get; set; }
        
        public virtual ICollection<Visit> Visit { get; set; }
    }
}
