using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlatDuJour.BO;
using PlatDuJour.BO.QueryFilter;
using PlatDuJour.BO.ViewModels;
using PlatDuJour.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatDuJour.API.Controllers
{

    public class DailyPlatesController : APIBaseController
    {
        public DailyPlatesController(IUnitOfWork unit, IQueryFilter queryFilter) : base(unit, queryFilter)
        {

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DailyPlateViewModel>>> Get()
        {
            return await _filter.getDailyPlates();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DailyPlateViewModel>> GetById([FromRoute] int id)
        {
            return await _filter.getPlateById(id);
        }

        [HttpPost]
        public async Task<ActionResult<DailyPlateViewModel>> Create([FromForm] DailyPlateViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DailyPlate dailyPlate = _unit.Mapper.Map<DailyPlate>(model);
                    await _unit.DailyPlateRepos.Create(dailyPlate);
                    return Ok(model);
                }
                catch
                {
                    return BadRequest(model);
                }
            }
            return BadRequest(model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DailyPlateViewModel>> Update([FromRoute] int id, [FromBody] DailyPlateViewModel model)
        {
            if (!ModelState.IsValid || id != model.DailyPlateId)
            {
                return BadRequest(model);
            }
            try
            {
                DailyPlate dailyPlate = _unit.Mapper.Map<DailyPlate>(model);
                await _unit.DailyPlateRepos.Update(dailyPlate);
                return Ok(model);
            }
            catch
            {
                return BadRequest(model);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            if (id == default(int))
            {
                return BadRequest();
            }
            DailyPlate dailyPlate = await _unit.DailyPlateRepos.GetById(id);
            if (dailyPlate == default(DailyPlate))
            {
                return BadRequest("Daily Plate could not be deleted!");
            }
            try
            {
                await _unit.DailyPlateRepos.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }


    }
}
