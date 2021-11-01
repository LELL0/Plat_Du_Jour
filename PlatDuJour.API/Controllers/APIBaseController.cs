using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlatDuJour.BO;
using PlatDuJour.BO.QueryFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatDuJour.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class APIBaseController : ControllerBase
    {
        protected readonly IUnitOfWork _unit;
        protected readonly IQueryFilter _filter;
        public APIBaseController(IUnitOfWork unit,IQueryFilter queryFilter)
        {
            _unit = unit;
            _filter = queryFilter;
        }
    }
}
