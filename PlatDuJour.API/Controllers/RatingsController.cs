using Microsoft.AspNetCore.Mvc;
using PlatDuJour.BO;
using PlatDuJour.BO.QueryFilter;
using PlatDuJour.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlatDuJour.API.Controllers
{

    public class RatingsController : APIBaseController
    {
        public RatingsController(IUnitOfWork unit, IQueryFilter queryFilter) : base(unit, queryFilter)
        {
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<RatingViewModel>>> Get()
        {
            return await _filter.getRatings();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<RatingViewModel>> GetById([FromRoute] int id)
        {
            return await _filter.getRatingById(id);
        }

        [HttpPost]
        public async Task<ActionResult<RatingViewModel>> Create([FromBody] RatingViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Rating rate = _unit.Mapper.Map<Rating>(model);
                    await _unit.RatingRepos.Create(rate);
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
        public async Task<ActionResult<RatingViewModel>> Update([FromRoute] int id, [FromBody] RatingViewModel model)
        {
            if (!ModelState.IsValid || id != model.RatingId)
            {
                return BadRequest(model);
            }
            try
            {
                Rating Rating = _unit.Mapper.Map<Rating>(model);
                await _unit.RatingRepos.Update(Rating);
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
            Rating Ingredient = await _unit.RatingRepos.GetById(id);
            if (Ingredient == default(Rating))
            {
                return BadRequest("Daily Plate could not be deleted!");
            }
            try
            {
                await _unit.RatingRepos.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
