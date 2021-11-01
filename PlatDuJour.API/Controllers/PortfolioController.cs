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
    public class PortfolioController : APIBaseController
    {
        public PortfolioController(IUnitOfWork unit, IQueryFilter queryFilter) : base(unit, queryFilter)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PortfolioViewModel>>> Get()
        {
            return await _filter.getPortfolios();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PortfolioViewModel>> GetById([FromRoute] int id)
        {
            return await _filter.getPortfolioById(id);
        }

        [HttpPost]
        public async Task<ActionResult<PortfolioViewModel>> Create([FromForm] PortfolioViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string imagePath = string.Empty;
                    if (model.FormFile != null)
                    {
                        imagePath = await model.FormFile.SaveImage("Portfolios");
                    }
                    Portfolio Portfolio = _unit.Mapper.Map<Portfolio>(model);
                    Portfolio.ImageUrl = imagePath;
                    await _unit.PortfolioRepos.Create(Portfolio);
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
        public async Task<ActionResult<PortfolioViewModel>> Update([FromRoute] int id, [FromBody] PortfolioViewModel model)
        {
            if (!ModelState.IsValid || id != model.Id)
            {
                return BadRequest(model);
            }
            try
            {
                string imagePath = string.Empty;
                if (model.FormFile != null)
                {
                    imagePath = await model.FormFile.SaveImage("Portfolios");
                }
                Portfolio Portfolio = _unit.Mapper.Map<Portfolio>(model);
                Portfolio.ImageUrl = imagePath;
                await _unit.PortfolioRepos.Update(Portfolio);
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
            Portfolio Portfolio = await _unit.PortfolioRepos.GetById(id);
            if (Portfolio == default(Portfolio))
            {
                return BadRequest("Daily Plate could not be deleted!");
            }
            try
            {
                await _unit.PortfolioRepos.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
