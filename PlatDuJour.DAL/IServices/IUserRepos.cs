using Microsoft.AspNetCore.Identity;
using PlatDuJour.DAL.Models;
using PlatDuJour.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatDuJour.DAL.IServices
{
    public interface IUserRepos : IGenericRepos<ApplicationUser>
    {
        IQueryable<UserViewModel> GetUsers();

        UserViewModel GetUserById(string Id);
    }
}
