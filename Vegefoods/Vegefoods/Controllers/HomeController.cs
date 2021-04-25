using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Vegefoods.Models;
using VegeFoodsBO.Interface;
using VegeFoodsEntities.CustomEntities;
using VegeFoodsEntities.Entities;

namespace Vegefoods.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IVegeBusinessAccess _vegeBusinessAccess;

        public HomeController(IVegeBusinessAccess vegeBusinessAccess)
        {
            _vegeBusinessAccess = vegeBusinessAccess;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

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

        public async Task<IActionResult> Login(Users user)
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


                return View("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "User Not Found";
            }
            return View();
        }

        public IActionResult ProductSingle(long productId)
        {
            if (productId == 0)
                productId = _vegeBusinessAccess.GetFirstProduct();

            Products productObj = _vegeBusinessAccess.GetProductById(productId);
            return View(productObj);
        }


        [HttpPost]
        public IActionResult ProductSingle(int id, int quantity)
        {
            UserCart obj = new UserCart();
            Products product = _vegeBusinessAccess.GetProductById(id);

            var user = HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme).Result;
            var userId = user.Principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;

            obj.UserId = Convert.ToInt64(userId);
            obj.ProductId = id;
            obj.Quantity = quantity;
            obj.Price = quantity * product.ProductPrice;

            _vegeBusinessAccess.AddToCart(obj);
            return View("Index");
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult BlogSingle()
        {
            return View();
        }


        public IActionResult Cart()
        {
            var user = HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme).Result;
            var userId = user.Principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;
            List<UserCartModel> userList = _vegeBusinessAccess.GetUserCart(Convert.ToInt64(userId));

            var sum = 0;
            foreach (var item in userList)
            {
                sum = (int)(sum + item.Price);
            }

            ViewBag.sum = sum;
            return View(userList);
        }

        public IActionResult Checkout()
        {
            var user = HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme).Result;
            var userId = user.Principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;
            ViewBag.total = _vegeBusinessAccess.GetUserTotal(Convert.ToInt64(userId));
            return View();
        }

        [HttpPost]
        public IActionResult SaveBillingDetails(UserBilling userBill)
        {
            var user = HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme).Result;
            var userId = user.Principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;
            userBill.TotalBill = _vegeBusinessAccess.GetUserTotal(Convert.ToInt64(userId));
            _vegeBusinessAccess.SaveBillingDetails(userBill);

            List<UserCart> userCartList = _vegeBusinessAccess.GetUserProducts(Convert.ToInt64(userId));

            foreach (var item in userCartList)
            {
                _vegeBusinessAccess.UpdateProductQuantity(item.ProductId, item.Quantity);
            }

            return View("OrderSuccess");
        }

        public IActionResult SaveBillingDetails()
        {
            var user = HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme).Result;
            var userId = user.Principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;

            List<UserCart> userCartList = _vegeBusinessAccess.GetUserProducts(Convert.ToInt64(userId));

            foreach (var item in userCartList)
            {
                _vegeBusinessAccess.UpdateProductQuantity(item.ProductId, item.Quantity);
            }

            ViewBag.total = _vegeBusinessAccess.GetUserTotal(1);
            return View();
        }

        [Authorize]
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult OrcerSuccess()
        {
            return View();
        }

        public IActionResult About()
        {
            _vegeBusinessAccess.GetProducts();
            return View();
        }



        public IActionResult Shop(int PageNumber = 1)
        {
            List<Products> productList = _vegeBusinessAccess.GetProducts();
            ViewBag.TotalPages = Math.Ceiling(productList.Count() / 12.0);
            ViewBag.PageNumber = PageNumber;

            productList = _vegeBusinessAccess.Pagination(PageNumber, 12, productList);

            return View(productList);
        }

        public IActionResult AddToWishlist(long id)
        {

            var user = HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme).Result;
            var userId = user.Principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;
            var productId = id;
            UserWishlist userWishObj = new UserWishlist();
            userWishObj.UserId = Convert.ToInt64(userId);
            userWishObj.ProductId = id;

            if (productId != 0)
            {
                _vegeBusinessAccess.AddToWishlist(userWishObj);
            }

            return RedirectToAction("Shop");
        }


        public IActionResult RemoveFromWishlist(int productId)
        {
            var user = HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme).Result;
            var userId = user.Principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;
            _vegeBusinessAccess.DeleteFromWishlist(productId, Convert.ToInt64(userId));
            return RedirectToAction("Wishlist");
        }

        public IActionResult RemoveFromCart(int productId)
        {
            var user = HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme).Result;
            var userId = user.Principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;
            _vegeBusinessAccess.DeleteFromCart(productId, Convert.ToInt64(userId));
            return RedirectToAction("Cart");
        }

        public IActionResult Wishlist()
        {
            var user = HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme).Result;
            var userId = user.Principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;
            List<UserWishlistModel> userList = _vegeBusinessAccess.GetUserWishlist(Convert.ToInt64(userId));

            return View(userList);
        }


        public IActionResult AddToCart(int productId, int quantity, int price)
        {

            var user = HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme).Result;
            var userId = user.Principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;
            UserCart userObj = new UserCart();
            userObj.UserId = Convert.ToInt64(userId);
            userObj.ProductId = productId;
            userObj.Quantity = quantity;
            userObj.Price = price;

            _vegeBusinessAccess.AddToCart(userObj);

            return RedirectToAction("Shop");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
