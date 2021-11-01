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
    public class IngredientImagesController : APIBaseController
    {
        public IngredientImagesController(IUnitOfWork unit, IQueryFilter queryFilter) : base(unit, queryFilter)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientImageViewModel>>> Get()
        {
            return await _filter.getIngredientImages();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IngredientImageViewModel>> GetById([FromRoute] int id)
        {
            return await _filter.getIngredientImageById(id);
        }

        [HttpPost]
        public async Task<ActionResult<IngredientImageViewModel>> Create([FromForm]IngredientImageViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string imagePath = string.Empty;
                    if (model.FormFile != null)
                    {
                        imagePath = await model.FormFile.SaveImage("Ingredients");
                    }
                    IngredientImage IngredientImage = _unit.Mapper.Map<IngredientImage>(model);
                    IngredientImage.ImageUrl = imagePath;
                    await _unit.IngredientImageRepos.Create(IngredientImage);
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
        public async Task<ActionResult<IngredientImageViewModel>> Update([FromRoute] int id, [FromBody] IngredientImageViewModel model)
        {
            if (!ModelState.IsValid || id != model.IngredientId)
            {
                return BadRequest(model);
            }
            try
            {
                string imagePath = string.Empty;
                if (model.FormFile != null)
                {
                    imagePath = await model.FormFile.SaveImage("Ingredients");
                }
                IngredientImage IngredientImage = _unit.Mapper.Map<IngredientImage>(model);
                IngredientImage.ImageUrl = imagePath;
                await _unit.IngredientImageRepos.Update(IngredientImage);
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
            IngredientImage IngredientImage = await _unit.IngredientImageRepos.GetById(id);
            if (IngredientImage == default(IngredientImage))
            {
                return BadRequest("Daily Plate could not be deleted!");
            }
            try
            {
                await _unit.IngredientImageRepos.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
