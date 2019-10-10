//####################################################################
// Project:         10perals
// Author:          Jonathan Dávila A.
// DATA:            07/10/2019
//####################################################################
namespace InfoClient.BM.Country
{
    using InfoClient.DM.Country;
    using InfoClient.DM.Database;
    using InfoClient.DT.Client;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using AutoMapper;

    public class BMCountry: IBMCountry
    {
        private ICountryRepository _ObjCountryRepository;
        private readonly IMapper _Objmapper;

        //Constructur
        public BMCountry(ICountryRepository CountryRepository, IMapper mapper)
        {
            _ObjCountryRepository = CountryRepository;
            _Objmapper = mapper;
        }
        /// <summary>
        /// Get all information of countries states and cities
        /// </summary>
        /// <returns></returns>
        public DTInfoCountry GetAllCountry()
        {
            DTInfoCountry infocontry = new DTInfoCountry();
            try
            {
                //Query for get all contries states and cities in the same query.
                var Buscar = _ObjCountryRepository.Get(q => q
                                                .Include(x => x.State)
                                                    .ThenInclude(y => y.City));
                if (Buscar != null)
                {
                    List<DTCountry> Countries = new List<DTCountry>();
                    List<DTState> States = new List<DTState>();
                    List<DTCity> Cities = new List<DTCity>();

                    foreach (Country item in Buscar)
                    {
                        DTCountry objcountry = new DTCountry();
                        objcountry = _Objmapper.Map<DTCountry>(item);
                        Countries.Add(objcountry);
                        foreach (State stat in item.State)
                        {
                            DTState objstate = new DTState();
                            objstate = _Objmapper.Map<DTState>(stat);
                            States.Add(objstate);
                            foreach (City cit in stat.City)
                            {
                                DTCity objcity = new DTCity();
                                objcity = _Objmapper.Map<DTCity>(cit);
                                Cities.Add(objcity);
                            }
                        }
                    }

                    infocontry.Countries = Countries;
                    infocontry.States = States;
                    infocontry.Cities = Cities;
                }
                return infocontry;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
