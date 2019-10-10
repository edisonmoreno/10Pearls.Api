//####################################################################
// Project:         10Pearls
// Author:          Jonathan Dávila A.
// DATA:            07/10/2019
// Comment:         Class repository sale representative
//####################################################################
namespace InfoClient.DM.Representative
{
    using InfoClient.DM.Repository;
    using InfoClient.DM.Database;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class RepresentativeRepository : BaseRepository<SaleRepresentative>, IRepresentativeRepository
    {
        public RepresentativeRepository(_10PearlBDClientContext Db) : base(Db)
        {

        }
    }
}
