//####################################################################
// Project:         10Pearls
// Author:          Jonathan Dávila A.
// DATA:            07/10/2019
// Comment:         DTO Cities
//####################################################################
namespace InfoClient.DT.Client
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DTCity
    {
        public int IdCity { get; set; }
        public string Name { get; set; }
        public int? IdState { get; set; }
    }
}
