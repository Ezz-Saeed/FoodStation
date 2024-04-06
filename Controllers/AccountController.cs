using FoodCorner.Models;
//using FoodCorner.Services.IServices;
//using FoodCorner.Settings;
using FoodCorner.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FoodCorner.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<TypeUser> _userManager;
        private readonly SignInManager<TypeUser> _signInManager;
        //private readonly IEmailService _mailService;
        //private readonly ConfirmEmail _confirmEmail;
        public AccountController(UserManager<TypeUser> userManager, SignInManager<TypeUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            //_mailService = mailService;
            //_confirmEmail = new ConfirmEmail();
        }
        public IActionResult Index()
        {
            return View();
        }

       

        public async Task<IActionResult> ConfirmEmail(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            user!.EmailConfirmed = true;
            await _userManager.UpdateAsync(user);
            return NoContent();
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignInViewMdel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if(user is not null)
                {
                    bool isFound = await _userManager.CheckPasswordAsync(user, model.Password);
                    if (isFound)
                    {                       
                        await _signInManager.SignInAsync(user, model.RemeberMe);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(model.Password, "Invalid user password.");
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError(model.UserName, "Invalid user name.");
                    return View(model);
                }
            }
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index),"Home");
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                if (await _userManager.FindByEmailAsync(model.Email) is not null ||
                    await _userManager.FindByNameAsync(model.UserName) is not null)
                {
                    ModelState.AddModelError("", "Already registered account");
                    return View(model);
                }

                TypeUser user = new()
                {
                    UserName = model.UserName,
                    Address = model.Address,
                    Email = model.Email,
                };
                IdentityResult identityResult = await _userManager.CreateAsync(user, model.Password);
                if (!identityResult.Succeeded)
                {
                    var errors = identityResult.Errors;
                    foreach (var error in errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);

                }
                else
                {
                    user.Cart = new Cart()
                    {
                        UserID = user.Id
                    };
                    List<Claim> claims = new()
                    {
                        new Claim("CartId", user.Cart.Id),
                        new Claim("UserId", user.Id),
                    };
                    await _userManager.AddClaimsAsync(user, claims);
                    await _userManager.AddToRoleAsync(user, "User");
                    //await _mailService.SendEmailAsyncWithMimeKit(user.Email, "Confirm", _confirmEmail.GetEmailBody(),null);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult NewAdmin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewAdmin(RegisterationViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user is not null)
            {
                if (!await _userManager.IsInRoleAsync(user, "Admin"))
                    await _userManager.AddToRoleAsync(user, "Admin");

            }

            else
            {
                user = new TypeUser()
                {
                    UserName = model.UserName,
                    Address = model.Address,
                    Email = model.Email,
                };
                var authResult = await _userManager.CreateAsync(user, model.Password);
                if(!authResult.Succeeded)
                {
                    
                    var errors = string.Empty;
                    foreach (var error in authResult.Errors)
                        errors += $"{error.Description}, ";
                    ModelState.AddModelError(errors, "");
                    return View(model);
                }
                user.Cart = new Cart()
                {
                    UserID = user.Id
                };
                List<Claim> claims = new()
                    {
                        new Claim("CartId", user.Cart.Id),
                        new Claim("UserId", user.Id),
                    };
                await _userManager.AddClaimsAsync(user, claims);
                await _userManager.AddToRolesAsync(user, new List<string>() { "User", "Admin" });
                await _signInManager.SignInAsync(user, isPersistent: false);
            }
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
