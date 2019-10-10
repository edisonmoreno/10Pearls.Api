//####################################################################
// Project:         10Pearls
// Author:          Jonathan Dávila A.
// DATA:            07/10/2019
// Comment:         Interface repository Country
//####################################################################
namespace InfoClient.DM.Country
{
    using InfoClient.DM.Database;
    using InfoClient.DM.Repository;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ICountryRepository : IBaseRepository<Country>
    {
    }
}
