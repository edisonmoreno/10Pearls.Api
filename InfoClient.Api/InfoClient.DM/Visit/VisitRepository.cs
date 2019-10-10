//####################################################################
// Project:         10Pearls
// Author:          Jonathan Dávila A.
// DATA:            08/10/2019
// Comment:         Class repository visits
//####################################################################
namespace InfoClient.DM.Visit
{
    using InfoClient.DM.Repository;
    using InfoClient.DM.Database;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class VisitRepository : BaseRepository<Visit>, IVisitRepository
    {
        public VisitRepository(_10PearlBDClientContext Db) : base(Db)
        {

        }
    }
}
