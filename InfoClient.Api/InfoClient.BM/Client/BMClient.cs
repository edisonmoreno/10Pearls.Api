//####################################################################
// Project:         10Pearls
// Author:          Jonathan Dávila A.
// DATA:            01/10/2019
// Comment:         layer of businnes
//####################################################################
namespace InfoClient.BM.Client
{
    using AutoMapper;
    using InfoClient.DM.Client;
    using InfoClient.DT.Client;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using InfoClient.DM.Database;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class BMClient: IBMClient
    {
        private IClientRepository _ObjClientRepository;
        private readonly IMapper _Objmapper;

        //Constructor
        public BMClient(IClientRepository ClientRepository, IMapper mapper)
        {
            _ObjClientRepository = ClientRepository;
            _Objmapper = mapper;
        }

        //Encode nit
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        //Decode nit
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

      
        /// <summary>
        /// Insert new clients
        /// </summary>
        /// <param name="objClient"></param>
        /// <returns>DTResponse</returns>
        public DTResponse CreateClient(DTClient objClient) {
            DTResponse Resp = new DTResponse();
            try
            {
                objClient.Nit = Base64Encode(objClient.Nit);
                Client ClientBD = new Client();
                ClientBD = _Objmapper.Map<Client>(objClient);
                _ObjClientRepository.Create(ClientBD);
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
        /// Modify all data of client
        /// </summary>
        /// <param name="objClient"></param>
        /// <returns></returns>
        public DTResponse ModifyClient(DTClient objClient)
        {
            DTResponse Resp = new DTResponse();
            try
            {
                objClient.Nit = Base64Encode(objClient.Nit);
                Client ClientBD = new Client();
                ClientBD = _Objmapper.Map<Client>(objClient);
                _ObjClientRepository.Update(ClientBD);

                Resp.response = true;
                Resp.message = "Success";
            }
            catch (Exception ex)
            {
                Resp.response = false;
                Resp.message = ex.Message;
            }
            return Resp;
        }

        ///Modify avilable credit and number visits
        public DTResponse ModifyCreditandVisits(int IdClient)
        {
            DTResponse Resp = new DTResponse();
            try
            {
                Client ObjClient =  _ObjClientRepository.GetAllBy(i => i.IdClient == IdClient).FirstOrDefault();
                if (ObjClient != null)
                {
                    ObjClient.AvailableCredit = ObjClient.AvailableCredit - 1;
                    _ObjClientRepository.Update(ObjClient);
                }
                Resp.response = true;
                Resp.message = "Success";
            }
            catch (Exception ex)
            {
                Resp.response = false;
                Resp.message = ex.Message;
            }
            return Resp;
        }
        /// <summary>
        /// Delete all data of a client
        /// </summary>
        /// <param name="objClient"></param>
        /// <returns></returns>
        public DTResponse DeleteClient(int IdClient)
        {
            DTResponse Resp = new DTResponse();
            try
            {
                Client Query = _ObjClientRepository.GetAllBy(i => i.IdClient == IdClient).FirstOrDefault();
                if (Query != null)
                {
                   _ObjClientRepository.Delete(Query);
                }

                Resp.response = true;
                Resp.message = "Success";
            }
            catch (Exception ex)
            {
                Resp.response = false;
                Resp.message = ex.Message;
            }
            return Resp;
        }

        /// <summary>
        /// Get all clients of data base
        /// </summary>
        /// <returns>List<DTClient></returns>
        public List<DTClient> GetAllClients()
        {
            List<DTClient> ListClient = new List<DTClient>();
            try
            {
                var Query = _ObjClientRepository.GetAll();
                if (Query != null)
                {
                    foreach (Client item in Query)
                    {
                        DTClient objClient = new DTClient();
                        item.Nit = Base64Decode(item.Nit);
                        objClient = _Objmapper.Map<DTClient>(item);
                        ListClient.Add(objClient);
                    }
                }

                return ListClient;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
