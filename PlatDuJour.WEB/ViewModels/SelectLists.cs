using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlatDuJour.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatDuJour.WEB.ViewModels
{
    public class SelectLists
    {
        private readonly IUnitOfWork _uow;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public SelectLists(IUnitOfWork uow, UserManager<IdentityUser> user, RoleManager<IdentityRole> role)
        {
            _userManager = user;
            _uow = uow;
            _roleManager = role;
        }

        public async Task<SelectList> RoleList(string role = "")
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var selectedRole = roles.FirstOrDefault();
            if (string.IsNullOrEmpty(role))
            {
                selectedRole = roles.FirstOrDefault(x => x.Name.ToLower().Equals(role.ToLower()));
            }
            return new SelectList(roles, nameof(IdentityRole.Name), nameof(IdentityRole.Name), selectedRole);
        }
    }
}
