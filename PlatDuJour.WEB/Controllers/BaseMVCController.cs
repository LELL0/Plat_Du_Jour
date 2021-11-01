using Microsoft.AspNetCore.Mvc;
using PlatDuJour.BO;
using PlatDuJour.BO.QueryFilter;
using PlatDuJour.WEB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatDuJour.WEB.Controllers
{
    public class BaseMVCController : Controller
    {

        protected readonly IUnitOfWork _unit;
        protected readonly IQueryFilter _query;
        protected readonly SelectLists _select;
        public BaseMVCController(IUnitOfWork uow, IQueryFilter query,SelectLists select)
        {
            _unit = uow;
            _query = query;
            _select = select;
        }
    
    }
}
