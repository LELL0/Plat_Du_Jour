using LearningIdentity.Models;
using LearningIdentity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlatDuJour.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LearningIdentity.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            RegisterVM model = new RegisterVM();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid) { return View(model); }
            ApplicationUser user = new ApplicationUser { UserName = model.Email, Email = model.Email, Name = model.Name };
            var dbUser = await _userManager.FindByEmailAsync(model.Email);
            if (dbUser != null)
            {
                ModelState.AddModelError("Already Existed", string.Format("the following Email {0} already have an account!", model.Email));
                return View(model);
            }
            var registration_action = await _userManager.CreateAsync(user, model.Password);
            if (registration_action.Succeeded)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            else
            {
                ModelState.AddModelError("Error", "Something Went Wrong! try again later");
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Login()
        {
            LoginVM loginVM = new LoginVM();
            return View(loginVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] LoginVM model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return View(model);
            }
            var signInAction = await _signInManager.PasswordSignInAsync(user, model.Password, isPersistent: model.RememberMe, lockoutOnFailure: false);
            if (signInAction.Succeeded)
            {
                return RedirectToAction(nameof(AdminController.Index), "Admin");
            }
            else
            {
                ModelState.AddModelError("Not Authenticated", "User Name Or Password are not correct!");
            }
            return View(model);
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public IActionResult ExternalLogin([FromForm] string provider , [FromQuery] string ReturnUrl = "/Home/Index")
        {
            var redirectUrl = Url.Action("ExternalLoginCallBack", "Account", new { ReturnUrl = ReturnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallBack([FromQuery] string ReturnUrl, string remoteError = null)
        {
            if (remoteError != null)
            {
                ModelState.AddModelError("Error On External Logins", "Something went wrong " + remoteError);
                return View(nameof(Login));
            }
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction(nameof(Login));
            }
            var success_login = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);
            if (success_login.Succeeded)
            {
                await _signInManager.UpdateExternalAuthenticationTokensAsync(info);
                return LocalRedirect(ReturnUrl);
            }
            else
            {
                string email = info.Principal.FindFirstValue(ClaimTypes.Email);
                string name = info.Principal.FindFirstValue(ClaimTypes.Name);
                ApplicationUser user = new ApplicationUser() { Name = name, UserName = email, Email = email };
                var create_user = await _userManager.CreateAsync(user);
                if (create_user.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    var add_login_result = await _userManager.AddLoginAsync(user, info);
                    if (add_login_result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        await _signInManager.UpdateExternalAuthenticationTokensAsync(info);
                        return LocalRedirect(ReturnUrl);
                    }
                }
                ModelState.AddModelError("Error While Registration", "Something went wrong while trying to register from external resources!");
                return RedirectToAction(nameof(Login));
            }
        }


    }
}
