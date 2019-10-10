using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.Results;
using InfoClient.BM.Client;
using InfoClient.BM.Visit;
using InfoClient.DM.Database;
using InfoClient.DT.Client;
using InfoClient.DT.Utilities.FluentValidators;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfoClient.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IBMClient _ObjClient;
        private IBMVisit _ObjVisit;
        private readonly IMapper _Objmapper;

        public ClientController(IBMClient IClient, IBMVisit IVisit , IMapper mapper)
        {
            _ObjClient = IClient;
            _Objmapper = mapper;
            _ObjVisit = IVisit;
        }

        [HttpPost]
        [Route("CreateClient")]
        public ActionResult<DTResponse> CreateClient(DTClient objClient)
        {
            DTResponse Resp = new DTResponse();
            DTClientValidator objClientValidator = new DTClientValidator();
            ValidationResult result = new ValidationResult();

            //Validate fields required
            result = objClientValidator.Validate(objClient);
            if (result.IsValid)
            {   
                Resp = _ObjClient.CreateClient(objClient);
            }
            else
            {
                Resp.response = false;
                foreach (var failure in result.Errors)
                {
                    Resp.message += "Error was: " + failure.ErrorMessage + "-> ";
                }
            }

            return Resp;
        }


        [HttpPost]
        [Route("ModifyClient")]
        public ActionResult<DTResponse> ModifyClient(DTClient objClient)
        {
            DTResponse Resp = new DTResponse();
            DTClientValidator objClientValidator = new DTClientValidator();
            ValidationResult result = new ValidationResult();

            //Validate fields required
            result = objClientValidator.Validate(objClient);
            if (result.IsValid)
            {
                Resp = _ObjClient.ModifyClient(objClient);
            }
            else
            {
                Resp.response = false;
                foreach (var failure in result.Errors)
                {
                    Resp.message += "Error was: " + failure.ErrorMessage + "-> ";
                }
            }

            return Resp;
        }

        [HttpGet]
        [Route("DeleteClient")]
        public ActionResult<DTResponse> DeleteClient(int IdClient)
        {
            DTResponse Resp = new DTResponse();

            //DeleteVisits
            bool resp = _ObjVisit.DeleteVitis(IdClient);
            //DeleteClient
            if (resp)
            {
                Resp = _ObjClient.DeleteClient(IdClient);
            }
            return Resp;
        }


        [HttpGet]
        [Route("GetAllClients")]
        public ActionResult<List<DTClient>> GetAllClients()
        {
            List<DTClient> objClients = new List<DTClient>();

            objClients = _ObjClient.GetAllClients();

            return objClients;
        }

    }
}