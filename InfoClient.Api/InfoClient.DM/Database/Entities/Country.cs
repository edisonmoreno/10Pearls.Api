using System;
using System.Collections.Generic;

namespace InfoClient.DM.Database
{
    public partial class Country
    {
        public Country()
        {
            State = new HashSet<State>();
        }

        public int IdCountry { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }

        public virtual ICollection<State> State { get; set; }
    }
}
