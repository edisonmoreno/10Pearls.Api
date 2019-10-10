using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InfoClient.BM.Country;
using InfoClient.DT.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfoClient.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private IBMCountry _ObjCountry;
        private readonly IMapper _Objmapper;

        public CountryController(IBMCountry Icountry, IMapper mapper)
        {
            _ObjCountry = Icountry;
            _Objmapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<DTInfoCountry> GetallCountry()
        {

            DTInfoCountry Resp = new DTInfoCountry();
            Resp = _ObjCountry.GetAllCountry();

            return Resp;
        }

    }
}