//####################################################################
// Project:         !0Pearl
// Author:          Jonathan Dávila A.
// DATA:            05/10/2019
// Comment:         interface for bussines layer
//####################################################################
namespace InfoClient.BM.Client
{
    using InfoClient.DT.Client;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public interface IBMClient
    {
        DTResponse CreateClient(DTClient objClient);
        DTResponse ModifyClient(DTClient objClient);
        DTResponse ModifyCreditandVisits(int IdClient);
        DTResponse DeleteClient(int IdClient);
        List<DTClient> GetAllClients();
    }
}
