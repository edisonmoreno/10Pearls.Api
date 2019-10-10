namespace InfoClient.BM.Visit
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AutoMapper;
    using InfoClient.DM.Visit;
    using InfoClient.DM.Database;
    using InfoClient.DT.Client;
    using System.Linq;

    public class BMVisit : IBMVisit
    {
        private IVisitRepository _ObjVisitRepository;
        private readonly IMapper _Objmapper;

        //Constructor
        public BMVisit(IVisitRepository VisitRepository, IMapper mapper)
        {
            _ObjVisitRepository = VisitRepository;
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
    }
}
