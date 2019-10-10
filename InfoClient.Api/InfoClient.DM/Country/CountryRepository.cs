//####################################################################
// Project:         10Pearls
// Author:          Jonathan Dávila A.
// DATA:            07/10/2019
// Comment:         Class repository country
//####################################################################
namespace InfoClient.DM.Country
{
    using InfoClient.DM.Database;
    using InfoClient.DM.Repository;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CountryRepository: BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(_10PearlBDClientContext Db) : base(Db)
        {

        }
    }
}
