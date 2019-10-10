//####################################################################
// Project:         10Pearl
// Author:          Jonathan Dávila A.
// DATA:            05/10/2019
// Comment:         interface for bussines layer
//####################################################################
namespace InfoClient.BM.Representative
{
    using InfoClient.DT.Client;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IBMRepresentative
    {
        List<DTRepresentative> GetAllSaleRe();
    }
}
