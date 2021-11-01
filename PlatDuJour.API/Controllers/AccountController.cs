using LearningIdentity.Models;
using LearningIdentity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentityAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable);
            }
            var existedUser = await _userManager.FindByEmailAsync(model.Email);
            if (existedUser != null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Account already registered");
            }
            var user = new ApplicationUser { Name = model.Name, UserName = model.Email, Email = model.Email };
            var created_user = await _userManager.CreateAsync(user, model.Password);
            if (!created_user.Succeeded)
            {
                return BadRequest("Something went wrong while registering your account! Please try again later!");
            }
            var role_created = await _userManager.AddToRoleAsync(user, "User");
            if (!role_created.Succeeded)
            {
                return BadRequest("Failed while adding role to the registered account!");
            }

            //start token generation
            // create secret key
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("here we have to add a key that is larger than 16 characters"));
            
            //get roles of the user
            var roles = await _userManager.GetRolesAsync(user);

            //create Claims 
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email , user.Email ),
                new Claim(ClaimTypes.Name , user.Name),
                new Claim("UID",user.Id)
            };
            // add user role to claims
            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            //generate JWT Security Token
            var token = new JwtSecurityToken(
                issuer: "https://localhost:44330",
                audience: "https://localhost:44330",
                claims:claims,
                notBefore:DateTime.Now,
                expires:DateTime.Now.AddDays(30),
                signingCredentials:new SigningCredentials(secretKey,SecurityAlgorithms.HmacSha256)
                );

            //let the jwt token hander write the token convert from object of jwtSecurityToke to  token of type string
            string JwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return new ObjectResult(JwtToken);

        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginVM model)
        {
            var user = (ApplicationUser)await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return NotFound();
            }
            var signIn = await _signInManager.PasswordSignInAsync(user, model.Password, isPersistent: true, lockoutOnFailure: false);
            if (!signIn.Succeeded)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }
            //secret key
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("here we have to add a key that is larger than 16 characters"));

            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email,model.Email),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim("UID",user.Id)
            };
            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = new JwtSecurityToken(
                issuer: "https://localhost:44330",
                audience: "https://localhost:44330",
                notBefore: DateTime.Now,
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(secretKey, algorithm: SecurityAlgorithms.HmacSha256)
                ) ;

            string handlerSerialized = new JwtSecurityTokenHandler().WriteToken(token);
            return new ObjectResult(handlerSerialized);
        }
    }
}
