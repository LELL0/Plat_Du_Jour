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
    public class RatingImagesController : APIBaseController
    {
        public RatingImagesController(IUnitOfWork unit, IQueryFilter queryFilter) : base(unit, queryFilter)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RatingImageViewModel>>> Get()
        {
            return await _filter.getRatingImages();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<RatingImageViewModel>> GetById([FromRoute] int id)
        {
            return await _filter.getRatingImageById(id);
        }

        [HttpPost]
        public async Task<ActionResult<RatingImageViewModel>> Create([FromForm] RatingImageViewModel model)
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
                    RatingImage RatingImage = _unit.Mapper.Map<RatingImage>(model);
                    RatingImage.ImageUrl = imagePath;
                    await _unit.RatingImageRepos.Create(RatingImage);
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
        public async Task<ActionResult<RatingImageViewModel>> Update([FromRoute] int id, [FromForm] RatingImageViewModel model)
        {
            if (!ModelState.IsValid || id != model.RatingId)
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
                RatingImage RatingImage = _unit.Mapper.Map<RatingImage>(model);
                RatingImage.ImageUrl = imagePath;
                await _unit.RatingImageRepos.Update(RatingImage);
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
            RatingImage RatingImage = await _unit.RatingImageRepos.GetById(id);
            if (RatingImage == default(RatingImage))
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
