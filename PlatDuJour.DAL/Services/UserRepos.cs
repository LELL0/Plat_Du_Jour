using Microsoft.AspNetCore.Identity;
using PlatDuJour.DAL.IServices;
using PlatDuJour.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatDuJour.DAL.Services
{
    public class UserRepos : GenericRepos<ApplicationUser>, IUserRepos
    {
        public UserRepos(ApplicationDbContext context) : base(context)
        {
        }

        public UserViewModel GetUserById(string Id)
        {
            IQueryable<UserViewModel> viewmodel = (from user in _context.ApplicationUsers
                                                   where user.Id.Equals(Id)
                                                   select new UserViewModel
                                                   {
                                                       Name = user.Name,
                                                       UserName = user.UserName,
                                                       PhoneNumber = user.PhoneNumber,
                                                       EmailAddress = user.Email,
                                                       Role = string.Join(",", _context.UserRoles
                                                       .Where(x => x.UserId == Id)
                                                       .Select(x => x.RoleId).ToArray())
                                                   });
            return viewmodel.FirstOrDefault();
        }

        public IQueryable<UserViewModel> GetUsers()
        {

            return _context.Users.Select(x => new UserViewModel { EmailAddress = x.Email, PhoneNumber = x.PhoneNumber, UserName = x.UserName, IsActive = x.EmailConfirmed });
            //return (from user in _context.ApplicationUsers
            //        select new UserViewModel
            //        {
            //            Name = user.Name,
            //            UserName = user.UserName,
            //            PhoneNumber = user.PhoneNumber,
            //            EmailAddress = user.Email,
            //            //Role = string.Join(",", _context.UserRoles
            //            //.Where(x => x.UserId == user.Id)
            //            //.Select(x => x.RoleId).ToArray())
            //        });
        }
    }

    public class UserViewModel
    {
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string Name { get; set; }

        public string PhoneNumber { get; set; }
        public string Role { get; set; }

        public bool IsActive { get; set; }
    }
}
