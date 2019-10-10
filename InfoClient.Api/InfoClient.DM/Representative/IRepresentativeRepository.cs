//####################################################################
// Project:         10Pearls
// Author:          Jonathan Dávila A.
// DATA:            08/10/2019
// Comment:         Interface repository sales representative
//####################################################################
namespace InfoClient.DM.Representative
{
    using InfoClient.DM.Repository;
    using InfoClient.DM.Database;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IRepresentativeRepository: IBaseRepository<SaleRepresentative>
    {
    }
}
