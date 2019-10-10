//####################################################################
// Project:         10Pearls
// Author:          Jonathan Dávila A.
// DATA:            05/10/2019
// Comment:         Interface repository client
//####################################################################
namespace InfoClient.DM.Client
{
    using InfoClient.DM.Database;
    using InfoClient.DM.Repository;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IClientRepository : IBaseRepository<Client>
    {
    }
}
