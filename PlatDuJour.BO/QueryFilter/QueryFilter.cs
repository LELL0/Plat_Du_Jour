using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PlatDuJour.BO.ViewModels;
using PlatDuJour.DAL;
using PlatDuJour.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatDuJour.BO.QueryFilter
{
    public class QueryFilter : IQueryFilter
    {
        private readonly IUnitOfWork _unit;
        public QueryFilter(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<List<CategoryViewModel>> getCategories()
        {
            var categories = _unit.CategoryRepos.GetAll();
            List<CategoryViewModel> categoriesvm = await (from c in categories select _unit.Mapper.Map<CategoryViewModel>(c)).ToListAsync();
            return categoriesvm;
        }

        public async Task<CategoryViewModel> getCategoryById(int id)
        {
            return _unit.Mapper.Map<CategoryViewModel>(await _unit.CategoryRepos.GetById(id));
        }

        public async Task<List<DailyPlateViewModel>> getDailyPlates()
        {
            var dailyPlates = _unit.DailyPlateRepos.GetAll();
            List<DailyPlateViewModel> list = await (from dp in dailyPlates select _unit.Mapper.Map<DailyPlateViewModel>(dp)).ToListAsync();
            return list;
        }

        public async Task<IngredientViewModel> getIngredientById(int Id)
        {
            return _unit.Mapper.Map<IngredientViewModel>(await _unit.IngredientRepos.GetById(Id));
        }

        public async Task<IngredientImageViewModel> getIngredientImageById(int id)
        {
            return _unit.Mapper.Map<IngredientImageViewModel>(await _unit.IngredientImageRepos.GetById(id));
        }

        public async Task<List<IngredientImageViewModel>> getIngredientImages()
        {
            return await (from ingredientImage in _unit.IngredientImageRepos.GetAll()
                          select _unit.Mapper.Map<IngredientImageViewModel>(ingredientImage))
                .ToListAsync();
        }

        public async Task<IngredientItemViewModel> getIngredientItemById(int id)
        {
            return _unit.Mapper.Map<IngredientItemViewModel>(await _unit.IngredientItemRepos.GetById(id));
        }

        public async Task<List<IngredientItemViewModel>> getIngredientItemViewModel()
        {
            return await (from ingredientItem in _unit.IngredientItemRepos.GetAll()
                          select _unit.Mapper.Map<IngredientItemViewModel>(ingredientItem))
                .ToListAsync();
        }

        public async Task<List<IngredientViewModel>> getIngredients()
        {
            var ingredients = _unit.IngredientRepos.GetAll();
            return await (from ing in ingredients select _unit.Mapper.Map<IngredientViewModel>(ing)).ToListAsync();

        }

        public async Task<ItemViewModel> getItemById(int id)
        {
            return _unit.Mapper.Map<ItemViewModel>(await _unit.ItemRepos.GetById(id));
        }

        public async Task<ItemImageViewModel> getItemImageById(int id)
        {
            return _unit.Mapper.Map<ItemImageViewModel>(await _unit.ItemImageRepos.GetById(id));
        }

        public async Task<List<ItemImageViewModel>> getItemImages()
        {
            return await (from x in _unit.ItemImageRepos.GetAll()
                          select
_unit.Mapper.Map<ItemImageViewModel>(x)).ToListAsync();
        }

        public async Task<List<ItemViewModel>> getItems()
        {
            return await (from x in _unit.ItemRepos.GetAll()
                          select
_unit.Mapper.Map<ItemViewModel>(x)).ToListAsync();
        }

        public async Task<DailyPlateViewModel> getPlateById(int id)
        {
            return _unit.Mapper.Map<DailyPlateViewModel>(await _unit.DailyPlateRepos.GetById(id));
        }

        public async Task<PortfolioViewModel> getPortfolioById(int id)
        {
            return _unit.Mapper.Map<PortfolioViewModel>(await _unit.PortfolioRepos.GetById(id));
        }

        public async Task<List<PortfolioViewModel>> getPortfolios()
        {

            return await (from x in _unit.PortfolioRepos.GetAll()
                          select _unit.Mapper.Map<PortfolioViewModel>(x)).ToListAsync();
        }

        public async Task<RatingViewModel> getRatingById(int id)
        {
            return _unit.Mapper.Map<RatingViewModel>(await _unit.RatingRepos.GetById(id));
        }

        public async Task<RatingImageViewModel> getRatingImageById(int id)
        {
            return _unit.Mapper.Map<RatingImageViewModel>(await _unit.RatingImageRepos.GetById(id));
        }

        public async Task<List<RatingImageViewModel>> getRatingImages()
        {
            return await (from x in _unit.RatingImageRepos.GetAll() select _unit.Mapper.Map<RatingImageViewModel>(x)).ToListAsync();
        }

        public async Task<List<RatingViewModel>> getRatings()
        {

            return await (from x in _unit.RatingRepos.GetAll()
                          select _unit.Mapper.Map<RatingViewModel>(x)).ToListAsync();
        }

        public UserViewModel getUserById(string id)
        {
            return _unit.UserRepos.GetUserById(id);
        }

        public async Task<List<UserViewModel>> getUsers()
        {
            return await _unit.UserRepos.GetUsers().ToListAsync();
        }
    }
}
