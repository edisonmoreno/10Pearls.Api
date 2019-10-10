namespace InfoClient.BM.Visit
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AutoMapper;
    using InfoClient.DM.Visit;
    using InfoClient.DM.Client;
    using InfoClient.DM.Database;
    using InfoClient.DT.Client;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public class BMVisit : IBMVisit
    {
        private IVisitRepository _ObjVisitRepository;
        private IClientRepository _ObjClientRepository;
        private readonly IMapper _Objmapper;

        //Constructor
        public BMVisit(IVisitRepository VisitRepository, IClientRepository ClientRepository, IMapper mapper)
        {
            _ObjVisitRepository = VisitRepository;
            _ObjClientRepository = ClientRepository;
            _Objmapper = mapper;
        }


        /// <summary>
        /// Insert new visits
        /// </summary>
        /// <param name="objvisit"></param>
        /// <returns>DTResponse</returns>
        public DTResponse CreateVisit(DTVisit objvisit)
        {
            DTResponse Resp = new DTResponse();
            try
            {
                Visit VisitBD = new Visit();
                VisitBD = _Objmapper.Map<Visit>(objvisit);
                _ObjVisitRepository.Create(VisitBD);
                Resp.response = true;
                Resp.message = "Success";
            }
            catch (Exception ex)
            {
                Resp.message = ex.Message;
            }
            return Resp;
        }
        
        /// <summary>
        /// Dele visits by client
        /// </summary>
        /// <param name="IdClient"></param>
        /// <returns></returns>
        public bool DeleteVitis(int IdClient) {
            try
            {
                var Query = _ObjVisitRepository.GetAllBy(i => i.IdClient == IdClient).ToList();
                if (Query != null)
                {
                    foreach (Visit item in Query)
                    {
                        _ObjVisitRepository.Delete(item);
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Get all visits of data base
        /// </summary>
        /// <returns>List<DTVisit></returns>
        public List<DTVisit> GetAllVisits(int IdClient)
        {
            List<DTVisit> ListVisits = new List<DTVisit>();
            try
            {
                var Query = _ObjVisitRepository.GetAllBy(i => i.IdClient == IdClient).ToList();
                if (Query != null)
                {
                    foreach (Visit item in Query)
                    {
                        DTVisit objClient = new DTVisit();
                        objClient = _Objmapper.Map<DTVisit>(item);
                        ListVisits.Add(objClient);
                    }
                }
                return ListVisits;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all visits of data base by city
        /// </summary>
        /// <returns>List<DTVisit></returns>
        public List<DTVisitsByCity> GetAllVisitsByCity()
        {
            List<DTVisitsByCity> VisitsByCity = new List<DTVisitsByCity>();
            try
            {
               var Query = _ObjVisitRepository.GetAll().Join(_ObjClientRepository.GetAll(),
                   visit => visit.IdClient,
                   client => client.IdClient,
                   (visit, client) => new { Visit = visit, client = client }).ToList();

                if (Query != null)
                {
                    List<int> cities = new List<int>();
                    foreach (var item in Query)
                    {
                       cities.Add(item.client.IdCity);
                    }

                    var result = cities.GroupBy(n => n)
                                 .Select(c => new DTVisitsByCity { idcity = c.Key, totalvisits = c.Count() }).ToList();
                    VisitsByCity = result;
                }
                return VisitsByCity; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
