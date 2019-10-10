//####################################################################
// Project:         Tech & Solve
// Author:          Jonathan Dávila A.
// DATA:            01/10/2019
// Comment:         interfaz encargada de exponer la capa de negocio
//####################################################################
namespace InfoClient.BM.Representative
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AutoMapper;
    using InfoClient.DT.Client;
    using InfoClient.DM.Database;
    using InfoClient.DM.Representative;

    public class BMRepresentative: IBMRepresentative
    {
        private IRepresentativeRepository _ObjRepresentativeRepository;
        private readonly IMapper _Objmapper;

        //Constructor
        public BMRepresentative(IRepresentativeRepository RepRepository, IMapper mapper)
        {
            _ObjRepresentativeRepository = RepRepository;
            _Objmapper = mapper;
        }


        /// <summary>
        /// get all sale representative
        /// </summary>
        /// <param name="objClient"></param>
        /// <returns>DTResponse</returns>
        public List<DTRepresentative> GetAllSaleRe()
        {
            List<DTRepresentative> ListRepresentatives = new List<DTRepresentative>();
            try
            {
                var Query = _ObjRepresentativeRepository.GetAll();
                if (Query != null)
                {
                    foreach (SaleRepresentative item in Query)
                    {
                        DTRepresentative objRepresentative = new DTRepresentative();
                        objRepresentative = _Objmapper.Map<DTRepresentative>(item);
                        ListRepresentatives.Add(objRepresentative);
                    }
                }
                return ListRepresentatives;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
