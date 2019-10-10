//####################################################################
// Project:         10Pearls
// Author:          Jonathan Dávila A.
// DATA:            07/10/2019
// Comment:         DTO Clients
//####################################################################
namespace InfoClient.DT.Client
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class DTClient
    {
        public int IdClient { get; set; }
        public string Nit { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int IdCity { get; set; }
        public int CreditLimit { get; set; }
        public int AvailableCredit { get; set; }
        public int? VisitsPercentage { get; set; }
    }
}
