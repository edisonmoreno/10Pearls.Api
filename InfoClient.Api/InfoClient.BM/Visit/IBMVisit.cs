//####################################################################
// Project:         10Pearl
// Author:          Jonathan Dávila A.
// DATA:            08/10/2019
// Comment:         interface for bussines layer
//####################################################################
namespace InfoClient.BM.Visit
{
    using InfoClient.DT.Client;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public interface IBMVisit
    {
        DTResponse CreateVisit(DTVisit objClient);
        bool DeleteVitis(int IdClient);
        List<DTVisit> GetAllVisits(int IdClient);
        List<DTVisitsByCity> GetAllVisitsByCity();
    }
}
