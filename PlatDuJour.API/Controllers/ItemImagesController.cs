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
    [Route("api/[controller]")]
    [ApiController]
    public class ItemImagesController : APIBaseController
    {
        public ItemImagesController(IUnitOfWork unit, IQueryFilter queryFilter) : base(unit, queryFilter)
        {
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemImageViewModel>>> Get()
        {
            return await _filter.getItemImages();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ItemImageViewModel>> GetById([FromRoute] int id)
        {
            return await _filter.getItemImageById(id);
        }

        [HttpPost]
        public async Task<ActionResult<ItemImageViewModel>> Create([FromForm] ItemImageViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string imagePath = string.Empty;
                    if (model.FormFile != null)
                    {
                        imagePath = await model.FormFile.SaveImage("Items");
                    }
                    ItemImage ItemImage = _unit.Mapper.Map<ItemImage>(model);
                    ItemImage.ImageUrl = imagePath;
                    await _unit.ItemImageRepos.Create(ItemImage);
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
        public async Task<ActionResult<ItemImageViewModel>> Update([FromRoute] int id, [FromForm] ItemImageViewModel model)
        {
            if (!ModelState.IsValid || id != model.ItemId)
            {
                return BadRequest(model);
            }
            try
            {
                string imagePath = string.Empty;
                if (model.FormFile != null)
                {
                    imagePath = await model.FormFile.SaveImage("Items");
                }
                ItemImage ItemImage = _unit.Mapper.Map<ItemImage>(model);
                ItemImage.ImageUrl = imagePath;
                await _unit.ItemImageRepos.Update(ItemImage);
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
            ItemImage ItemImage = await _unit.ItemImageRepos.GetById(id);
            if (ItemImage == default(ItemImage))
            {
                return BadRequest("Daily Plate could not be deleted!");
            }
            try
            {
                await _unit.ItemImageRepos.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
