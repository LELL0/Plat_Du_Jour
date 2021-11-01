using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlatDuJour.BO;
using PlatDuJour.BO.QueryFilter;
using PlatDuJour.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatDuJour.API.Controllers
{

    public class ItemsController : APIBaseController
    {
        public ItemsController(IUnitOfWork unit, IQueryFilter queryFilter) : base(unit, queryFilter)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemViewModel>>> Get()
        {
            return await _filter.getItems();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ItemViewModel>> GetById([FromRoute] int id)
        {
            return await _filter.getItemById(id);
        }

        [HttpPost]
        public async Task<ActionResult<ItemViewModel>> Create([FromBody] ItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Item Ingredient = _unit.Mapper.Map<Item>(model);
                    await _unit.ItemRepos.Create(Ingredient);
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
        public async Task<ActionResult<ItemViewModel>> Update([FromRoute] int id, [FromBody] ItemViewModel model)
        {
            if (!ModelState.IsValid || id != model.ItemId)
            {
                return BadRequest(model);
            }
            try
            {
                Item item = _unit.Mapper.Map<Item>(model);
                await _unit.ItemRepos.Update(item);
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
            Item Ingredient = await _unit.ItemRepos.GetById(id);
            if (Ingredient == default(Item))
            {
                return BadRequest("Daily Plate could not be deleted!");
            }
            try
            {
                await _unit.ItemRepos.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
