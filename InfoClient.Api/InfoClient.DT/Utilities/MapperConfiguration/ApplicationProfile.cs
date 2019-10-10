//####################################################################
// Project:         10Pearls
// Author:          Jonathan Dávila A.
// DATA:            07/10/2019
// Comment:         Mapper profiles
//####################################################################
using InfoClient.DM.Database;
using InfoClient.DT.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoClient.DT.Utilities
{
    public class ApplicationProfile : AutoMapper.Profile
    {
        public ApplicationProfile() {

            CreateMap<Country, DTCountry>().ReverseMap();
            CreateMap<State, DTState>().ReverseMap();
            CreateMap<City, DTCity>().ReverseMap();
            CreateMap<DM.Database.Client, DTClient>().ReverseMap();
            CreateMap<SaleRepresentative, DTRepresentative>().ReverseMap();
            CreateMap<Visit, DTVisit>().ReverseMap();
        }
    }
}
