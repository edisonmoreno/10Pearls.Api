namespace InfoClient.DT.Client
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DTInfoCountry
    {
       public DTInfoCountry() {
            Countries = new List<DTCountry>();
            States = new List<DTState>();
            Cities = new List<DTCity>();
        }

        public List<DTCountry> Countries { get; set; }
        public List<DTState> States { get; set; }
        public List<DTCity> Cities { get; set; }
    }
}
