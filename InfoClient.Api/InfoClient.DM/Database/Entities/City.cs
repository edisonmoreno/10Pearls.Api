using System;
using System.Collections.Generic;

namespace InfoClient.DM.Database
{
    public partial class City
    {
        public City()
        {
            Client = new HashSet<Client>();
        }

        public int IdCity { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public int? IdState { get; set; }
        
        public virtual ICollection<Client> Client { get; set; }
    }
}
