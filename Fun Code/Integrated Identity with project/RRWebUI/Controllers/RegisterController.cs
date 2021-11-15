using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RRWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRWebUI.Controllers
{
    public class RegisterController : Controller
    {
        //Required dependencies to create user for us and also authorize them
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public RegisterController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        //The actual form that creates the user
        [HttpPost]
        public async Task<IActionResult> Index(RegisterVM p_register)
        {
            if(ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = p_register.Email,
                    Email = p_register.Email
                };

                var result = await _userManager.CreateAsync(user, p_register.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
    }
}
