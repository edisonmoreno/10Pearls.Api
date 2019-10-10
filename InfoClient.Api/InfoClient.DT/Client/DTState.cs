//####################################################################
// Project:         10Pearls
// Author:          Jonathan Dávila A.
// DATA:            05/10/2019
// Comment:         DTO States
//####################################################################
namespace InfoClient.DT.Client
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DTState
    {
        public int IdState { get; set; }
        public string Name { get; set; }
        public int? IdCountry { get; set; }
        public List<DTCity> City { get; set; }
    }
}
