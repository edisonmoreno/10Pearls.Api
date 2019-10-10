//####################################################################
// Project:         10Pearls
// Author:          Jonathan Dávila A.
// DATA:            07/10/2019
// Comment:         DTO Visitis
//####################################################################
namespace InfoClient.DT.Client
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DTVisit
    {
        public int IdVisit { get; set; }
        public int IdClient { get; set; }
        public DateTime VisitDate { get; set; }
        public int IdSrepresentative { get; set; }
        public int? Net { get; set; }
        public int? VisitTotal { get; set; }
        public string Description { get; set; }
    }
}
