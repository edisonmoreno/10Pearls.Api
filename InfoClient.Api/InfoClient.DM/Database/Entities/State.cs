using System;
using System.Collections.Generic;

namespace InfoClient.DM.Database
{
    public partial class State
    {
        public State()
        {
            City = new HashSet<City>();
        }

        public int IdState { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public int? IdCountry { get; set; }
        
        public virtual ICollection<City> City { get; set; }
    }
}
