using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlatDuJour.BO;
using PlatDuJour.BO.QueryFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlatDuJour.DAL.Models;

namespace PlatDuJour.API.Controllers
{

    public class IngredientsController : APIBaseController
    {
        public IngredientsController(IUnitOfWork unit, IQueryFilter queryFilter) : base(unit, queryFilter)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientViewModel>>> Get()
        {
            return await _filter.getIngredients();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IngredientViewModel>> GetById([FromRoute] int id)
        {
            return await _filter.getIngredientById(id);
        }

        [HttpPost]
        public async Task<ActionResult<IngredientViewModel>> Create([FromBody] IngredientViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Ingredient Ingredient = _unit.Mapper.Map<Ingredient>(model);
                    await _unit.IngredientRepos.Create(Ingredient);
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
        public async Task<ActionResult<IngredientViewModel>> Update([FromRoute] int id, [FromBody] IngredientViewModel model)
        {
            if (!ModelState.IsValid || id != model.IngredientId)
            {
                return BadRequest(model);
            }
            try
            {
                Ingredient Ingredient = _unit.Mapper.Map<Ingredient>(model);
                await _unit.IngredientRepos.Update(Ingredient);
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
            Ingredient Ingredient = await _unit.IngredientRepos.GetById(id);
            if (Ingredient == default(Ingredient))
            {
                return BadRequest("Daily Plate could not be deleted!");
            }
            try
            {
                await _unit.IngredientRepos.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
