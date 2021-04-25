using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VegeFoodsBO.Interface;
using VegeFoodsEntities.Entities;

namespace Vegefoods.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {

        private readonly IVegeBusinessAccess _vegeBusinessAccess;

        public AccountController(IVegeBusinessAccess vegeBusinessAccess)
        {
            _vegeBusinessAccess = vegeBusinessAccess;
        }

        public IActionResult Login()
        {
                return View("Index");
        }

        //return RedirectToAction("DisplayList", "Home");

        public string getRoleType(int id)
        {
            switch (id)
            {
                case 1:
                    return "user";
                    break;

                case 2:
                    return "admin";
                    break;


                default:
                    return "user";

            }
        }

        [HttpPost]
        public async Task<IActionResult> HandleLogin(Users user)
        {
            Users userObj = _vegeBusinessAccess.AuthenticateUser(user);

            string role = this.getRoleType((int)userObj.Role);
            if (ModelState.IsValid && userObj.UserId != 0)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role,role),
                    new Claim(ClaimTypes.Sid, userObj.UserId.ToString()),

                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity)
                    , new AuthenticationProperties
                    {
                        IsPersistent = true
                    });


                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "User Not Found";
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }


    }
}
