using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InfoClient.BM.Visit;
using InfoClient.DT.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InfoClient.DT.Utilities.FluentValidators;
using FluentValidation.Results;
using InfoClient.BM.Client;

namespace InfoClient.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitController : ControllerBase
    {
        private IBMVisit _ObjVisit;
        private IBMClient _ObjClient;
        private readonly IMapper _Objmapper;

        public VisitController(IBMVisit IVisit, IBMClient IClient, IMapper mapper)
        {
            _ObjVisit = IVisit;
            _Objmapper = mapper;
            _ObjClient = IClient;
        }

        [HttpGet]
        [Route("GetAllVisits")]
        public ActionResult<List<DTVisit>> GetAllVisits(int IdClient)
        {
            List<DTVisit> objVisits = new List<DTVisit>();
            objVisits = _ObjVisit.GetAllVisits(IdClient);
            return objVisits;
        }

        [HttpPost]
        [Route("CreateVisit")]
        public ActionResult<DTResponse> CreateVisit(DTVisit objVisit)
        {
            DTResponse Resp = new DTResponse();
            DTVisitValidator objVisitValidator = new DTVisitValidator();
            ValidationResult result = new ValidationResult();

            //Validate fields required
            result = objVisitValidator.Validate(objVisit);
            if (result.IsValid)
            {
                Resp = _ObjVisit.CreateVisit(objVisit);
                if (Resp.response)
                {
                    _ObjClient.ModifyCreditandVisits(objVisit.IdClient);
                }
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


    }
}