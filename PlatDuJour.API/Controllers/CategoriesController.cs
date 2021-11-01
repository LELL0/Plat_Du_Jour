using AutoMapper;
using IdentityAPI;
using Microsoft.AspNetCore.Mvc;
using PlatDuJour.BO;
using PlatDuJour.BO.QueryFilter;
using PlatDuJour.BO.ViewModels;
using PlatDuJour.DAL.IServices;
using PlatDuJour.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlatDuJour.API.Controllers
{

    public class CategoriesController : APIBaseController
    {

        public CategoriesController(IUnitOfWork unit, IQueryFilter filter) : base(unit, filter)
        {

        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryViewModel>>> Get([FromQuery] QueryParameters query)
        {
            return await _filter.getCategories();
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<CategoryViewModel> Get(int id)
        {
            return await _filter.getCategoryById(id);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task Post([FromForm] CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                Category cat = _unit.Mapper.Map<Category>(categoryViewModel);
                await _unit.CategoryRepos.Create(cat);
            }
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromForm] CategoryViewModel categoryVM)
        {
            if (ModelState.IsValid && id == categoryVM.CategoryId)
            {
                Category cat = _unit.Mapper.Map<Category>(categoryVM);
                await _unit.CategoryRepos.Update(cat);
            }
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _unit.CategoryRepos.Delete(id);
        }
    }
}
