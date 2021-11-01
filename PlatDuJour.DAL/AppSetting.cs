using Microsoft.Extensions.DependencyInjection;
using PlatDuJour.DAL.IServices;
using PlatDuJour.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatDuJour.DAL
{
    //CLASS EXTENSION 
    public static class AppSetting
    {
        public static void InjectServices(this IServiceCollection services)
        {
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<ICategoryRepos, CategoryRepos>();
            //services.AddScoped<IDailyPlateRepos, DailyPlateRepos>();
            //services.AddScoped<IIngredientImageRepos, IngredientImageRepos>();
            //services.AddScoped<IIngredientItemRepos, IngredientItemRepos>();
            //services.AddScoped<IIngredientRepos, IngredientRepos>();
            //services.AddScoped<IItemImageRepos, ItemImageRepos>();
            //services.AddScoped<IItemRepos, ItemRepos>();
            //services.AddScoped<IPortfolioRepos, PortfolioRepos>();
            //services.AddScoped<IRatingImageRepos, RatingImageRepos>();

        }
    }
}
