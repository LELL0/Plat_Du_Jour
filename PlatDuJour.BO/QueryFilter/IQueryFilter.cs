using PlatDuJour.BO.ViewModels;
using PlatDuJour.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatDuJour.BO.QueryFilter
{
    public interface IQueryFilter
    {
        Task<List<CategoryViewModel>> getCategories();
        Task<List<DailyPlateViewModel>> getDailyPlates();
        Task<List<IngredientViewModel>> getIngredients();

        Task<List<IngredientImageViewModel>> getIngredientImages();

        Task<List<IngredientItemViewModel>> getIngredientItemViewModel();

        Task<List<ItemViewModel>> getItems();

        Task<List<ItemImageViewModel>> getItemImages();

        Task<List<PortfolioViewModel>> getPortfolios();

        Task<List<RatingViewModel>> getRatings();


        Task<List<RatingImageViewModel>> getRatingImages();

        Task<CategoryViewModel> getCategoryById(int id);
        Task<DailyPlateViewModel> getPlateById(int id);

        Task<IngredientViewModel> getIngredientById(int Id);
        Task<IngredientImageViewModel> getIngredientImageById(int id);

        Task<IngredientItemViewModel> getIngredientItemById(int id);

        Task<ItemViewModel> getItemById(int id);
        Task<ItemImageViewModel> getItemImageById(int id);

        Task<PortfolioViewModel> getPortfolioById(int id);

        Task<RatingViewModel> getRatingById(int id);


        Task<RatingImageViewModel> getRatingImageById(int id);

        Task<List<UserViewModel>> getUsers();
        UserViewModel getUserById(string id);



    }
}
