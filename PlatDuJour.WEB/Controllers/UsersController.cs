using LearningIdentity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlatDuJour.BO;
using PlatDuJour.BO.QueryFilter;
using PlatDuJour.BO.ViewModels;
using PlatDuJour.DAL.Services;
using PlatDuJour.WEB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatDuJour.WEB.Controllers
{
    public class UsersController : BaseMVCController
    {
        // GET: UsersController
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IUnitOfWork uow,
            IQueryFilter query,
            SelectLists select
            ) : base(uow, query, select)
        {
            _roleManager = roleManager;
            _signInManager = signInManager;
            _userManager = userManager;
        }


        private async Task CheckRolesCreate()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            if (roles.Count() == 0)
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
                await _roleManager.CreateAsync(new IdentityRole { Name = "Chef" });
                await _roleManager.CreateAsync(new IdentityRole { Name = "User" });
            }

        }

        public async Task<ActionResult> Index()
        {
            await CheckRolesCreate();
            List<UserViewModel> users = await _query.getUsers();
            ViewData["UserList"] = users;
            return View();
        }


        [HttpGet]
        public async Task<ActionResult> _PartialUserTable([FromQuery] QueryParameters queryParameters)
        {
            List<UserViewModel> users = await _query.getUsers();
            return PartialView(users);
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersController/Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            ViewData["Roles"] = await _select.RoleList();
            UserViewModel user = new UserViewModel();
            return View(user);
        }




        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] UserViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existedUser = await _userManager.FindByEmailAsync(model.EmailAddress);
                    if (existedUser != null)
                    {
                        ModelState.AddModelError("", "User already created!");
                        return View(model);
                    }
                    ApplicationUser user = new ApplicationUser { Name = model.Name, Email = model.EmailAddress, PhoneNumber = model.PhoneNumber, UserName = model.UserName, EmailConfirmed = true };
                    var createdUser = await _userManager.CreateAsync(user, "P@$$w0rd");
                    if (createdUser.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, model.Role);
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Deactivate([FromQuery] string emailAddress)
        {
            var user = await _userManager.FindByEmailAsync(emailAddress);
            user.EmailConfirmed = false;
            await _userManager.UpdateAsync(user);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> Activate([FromQuery] string emailAddress)
        {
            var user = await _userManager.FindByEmailAsync(emailAddress);
            user.EmailConfirmed = true;
            await _userManager.UpdateAsync(user);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> Edit([FromQuery] string emailAddress)
        {

            var user = await _userManager.FindByEmailAsync(emailAddress);
            if (user != null)
            {
                IList<string> roles = await _userManager.GetRolesAsync(user);
                ViewData["Roles"] = await _select.RoleList();
                UserViewModel model = new UserViewModel { EmailAddress = user.Email, UserName = user.UserName, PhoneNumber = user.PhoneNumber };
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
