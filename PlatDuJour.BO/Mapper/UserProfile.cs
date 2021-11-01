using AutoMapper;
using PlatDuJour.BO.QueryFilter;
using PlatDuJour.BO.ViewModels;
using PlatDuJour.DAL.Models;
using System;
using System.Collections.Generic;

namespace PlatDuJour.BO.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<List<Category>, List<CategoryViewModel>>()
                .ReverseMap();
            CreateMap<Category, CategoryViewModel>()
                .ReverseMap();
            CreateMap<DailyPlate, DailyPlateViewModel>()
                .ReverseMap();
            CreateMap<Ingredient, IngredientViewModel>().ReverseMap();
            CreateMap<IngredientImage, IngredientImageViewModel>().ReverseMap();
            CreateMap<ItemImage, ItemImageViewModel>().ReverseMap();
            CreateMap<Item, ItemViewModel>().ReverseMap();
            CreateMap<DailyPlate, DailyPlateViewModel>().ReverseMap();
            CreateMap<Rating, RatingViewModel>().ReverseMap();
            CreateMap<RatingImage, RatingImageViewModel>().ReverseMap();
            CreateMap<Portfolio, PortfolioViewModel>().ReverseMap();
        }
    }
}
