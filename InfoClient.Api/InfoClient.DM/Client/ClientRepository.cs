//####################################################################
// Project:         10Pearls
// Author:          Jonathan Dávila A.
// DATA:            05/10/2019
// Comment:         Class repository client
//####################################################################
namespace InfoClient.DM.Client
{
    using InfoClient.DM.Repository;
    using InfoClient.DM.Database;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(_10PearlBDClientContext Db) : base(Db)
        {

        }
    }
}
