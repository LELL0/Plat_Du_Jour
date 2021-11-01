using AutoMapper;
using PlatDuJour.BO.QueryFilter;
using PlatDuJour.DAL.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatDuJour.BO
{
    public interface IUnitOfWork
    {
        ICategoryRepos CategoryRepos { get; }

        IDailyPlateRepos DailyPlateRepos { get; }

        IIngredientItemRepos IngredientItemRepos { get; }

        IIngredientImageRepos IngredientImageRepos { get; }

        IIngredientRepos IngredientRepos { get; }

        IItemImageRepos ItemImageRepos { get; }

        IPortfolioRepos PortfolioRepos { get; }

        IRatingImageRepos RatingImageRepos { get; }

        IRatingRepos RatingRepos { get; }

        IItemRepos ItemRepos { get; }

        IUserRepos UserRepos { get; }

        IMapper Mapper { get; }



    }
}
