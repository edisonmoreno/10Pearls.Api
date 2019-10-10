//####################################################################
// Project:         10Pearls
// Author:          Jonathan Dávila A.
// DATA:            07/10/2019
// Comment:        DTO Countries
//####################################################################
namespace InfoClient.DT.Client
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DTCountry
    {
        public int IdCountry { get; set; }
        public string Name { get; set; }
        public List<DTState> State { get; set; }
    }
}
