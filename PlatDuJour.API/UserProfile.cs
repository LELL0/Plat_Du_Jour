using AutoMapper;
using PlatDuJour.BO.ViewModels;
using PlatDuJour.DAL.Models;
using System;
using System.Collections.Generic;

namespace IdentityAPI
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<List<Category>, List<CategoryViewModel>>()
                .ReverseMap();
            CreateMap<Category, CategoryViewModel>()
                .ReverseMap();
        }
    }
}
