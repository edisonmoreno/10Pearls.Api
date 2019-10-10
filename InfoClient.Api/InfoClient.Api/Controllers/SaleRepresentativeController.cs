using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using InfoClient.BM.Representative;
using InfoClient.DT.Client;

namespace InfoClient.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleRepresentativeController : ControllerBase
    {
        private IBMRepresentative _ObjRepresentative;
        private readonly IMapper _Objmapper;

        public SaleRepresentativeController(IBMRepresentative IRepresentative, IMapper mapper)
        {
            _ObjRepresentative = IRepresentative;
            _Objmapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<DTRepresentative>> GetallRepresentative()
        {
            List<DTRepresentative> Resp = new List<DTRepresentative>();
            Resp = _ObjRepresentative.GetAllSaleRe();
            return Resp;
        }

    }
}