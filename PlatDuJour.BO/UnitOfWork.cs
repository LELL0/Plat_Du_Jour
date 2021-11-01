using AutoMapper;
using PlatDuJour.BO.Mapper;
using PlatDuJour.BO.QueryFilter;
using PlatDuJour.DAL.IServices;
using PlatDuJour.DAL.Models;
using PlatDuJour.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatDuJour.BO
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {

        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }


        #region private Instances
        private ICategoryRepos categoryRepos;
        private IDailyPlateRepos dailyPlateRepos;
        private IIngredientItemRepos ingredientItemRepos;
        private IIngredientImageRepos ingredientImageRepos;
        private IIngredientRepos ingredientRepos;
        private IItemRepos itemRepos;
        private IPortfolioRepos portfolioRepos;
        private IRatingImageRepos ratingImageRepos;
        private IRatingRepos ratingRepos;
        private IMapper mapper;
        private IUserRepos userRepos;

        #endregion


        #region public instance
        public ICategoryRepos CategoryRepos { get => categoryRepos ?? new CategoryRepos(_context); }

        public IDailyPlateRepos DailyPlateRepos { get => dailyPlateRepos ?? new DailyPlateRepos(_context); }
        public IIngredientItemRepos IngredientItemRepos { get => ingredientItemRepos ?? new IngredientItemRepos(_context); }
        //public IIngredientImageRepos IngredientImageRepos { get => ingredientImageRepos ?? new IngredientImageRepos(_context); }

        public IIngredientImageRepos IngredientImageRepos
        {
            get
            {
                if (categoryRepos == null)
                {
                    return new IngredientImageRepos(_context);
                }
                else
                {
                    return ingredientImageRepos;
                }
            }
        }

        public IIngredientRepos IngredientRepos => ingredientRepos ?? new IngredientRepos(_context);

        public IItemImageRepos ItemImageRepos => ItemImageRepos ?? new ItemImageRepos(_context);

        public IPortfolioRepos PortfolioRepos => portfolioRepos ?? new PortfolioRepos(_context);

        public IRatingImageRepos RatingImageRepos => ratingImageRepos ?? new RatingImageRepos(_context);

        public IRatingRepos RatingRepos => ratingRepos ?? new RatingRepos(_context);

        public IItemRepos ItemRepos => itemRepos ?? new ItemRepos(_context);

        public IUserRepos UserRepos => userRepos ?? new UserRepos(_context);

        public IMapper Mapper
        {
            get
            {
                if (mapper == null)
                {
                    var configurationMapper = new MapperConfiguration(option => option.AddProfile(new UserProfile()));
                    return configurationMapper.CreateMapper();
                }
                else
                {
                    return mapper;
                }
            }
        }


        #endregion




        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
