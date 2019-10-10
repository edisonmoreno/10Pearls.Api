//####################################################################
// Project:         !0Pearl
// Author:          Jonathan Dávila A.
// DATA:            05/10/2019
// Comment:         interface for bussines layer
//####################################################################
namespace InfoClient.BM.Country
{
    using InfoClient.DT.Client;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public interface IBMCountry
    {
        DTInfoCountry GetAllCountry();
    }
}
