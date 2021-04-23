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
    public class HomeController : Controller
    {
 
        private readonly IVegeBusinessAccess _vegeBusinessAccess;

        public HomeController(IVegeBusinessAccess vegeBusinessAccess)
        {
            _vegeBusinessAccess = vegeBusinessAccess;
        }

        public async Task<IActionResult> Index()
        {
            return View("Login");
        }

        public  IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Login(Users user)
        {
            var userId = _vegeBusinessAccess.AuthenticateUser(user);
            if (ModelState.IsValid)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role , "Admin"),
                    new Claim("UserId", userId.ToString()),

                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity)
                    , new AuthenticationProperties
                    {
                        IsPersistent = true
                    });


                return View("Index");
            }
            return View();
        }

        public IActionResult ProductSingle(long productId)
        {
            if (productId == 0)
                productId =  _vegeBusinessAccess.GetFirstProduct();

            Products productObj = _vegeBusinessAccess.GetProductById(productId);
            return View(productObj);
         }


        [HttpPost]
        public IActionResult ProductSingle(int id, int quantity)
        {
            UserCart obj = new UserCart();
            Products product = _vegeBusinessAccess.GetProductById(id);

            obj.UserId = 1;
            obj.ProductId = id;
            obj.Quantity = quantity;
            obj.Price = quantity * product.ProductPrice;

            _vegeBusinessAccess.AddToCart(obj);
            return View("Index");
        }
    


        public IActionResult catchh(Products product, int quantity)
        {
            ViewBag.Quantity = quantity;
            var temp = Convert.ToInt64(TempData["Quantity"]);
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
            List<UserCartModel> userList = _vegeBusinessAccess.GetUserCart(1);

            var sum = 0;
            foreach(var item in userList)
            {
                sum = (int)(sum + item.Price);
            }

            ViewBag.sum = sum;
            return View(userList);
        }

        public IActionResult Checkout()
        {
            ViewBag.total = _vegeBusinessAccess.GetUserTotal(1);
            return View();
        }

        [HttpPost]
        public IActionResult SaveBillingDetails(UserBilling userBill)
        {
            userBill.TotalBill = _vegeBusinessAccess.GetUserTotal(1);
            _vegeBusinessAccess.SaveBillingDetails(userBill);

            List<UserCart> userCartList = _vegeBusinessAccess.GetUserProducts(1);

            foreach (var item in userCartList)
            {
                _vegeBusinessAccess.UpdateProductQuantity(item.ProductId, item.Quantity);
            }

            return View("OrderSuccess");
        }

        public IActionResult SaveBillingDetails()
        {

           List<UserCart> userCartList = _vegeBusinessAccess.GetUserProducts(1);

            foreach(var item in userCartList)
            {
                _vegeBusinessAccess.UpdateProductQuantity(item.ProductId, item.Quantity);
            }

            ViewBag.total = _vegeBusinessAccess.GetUserTotal(1);
            return View();
        }

        [Authorize]
        public IActionResult Contact()
        {
            var user = HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme).Result;
            var temp1 = user.Principal.Claims.FirstOrDefault(x=>x.Type =="Id");
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

             productList =  _vegeBusinessAccess.Pagination(PageNumber,12, productList);
        
            return View(productList);
        }

        public IActionResult AddToWishlist(long id)
        {
            var productId = id;
            UserWishlist userWishObj = new UserWishlist();
            userWishObj.UserId = 1;
            userWishObj.ProductId = id;

            if (productId != 0)
            {
                _vegeBusinessAccess.AddToWishlist(userWishObj);
            }
            //get the data from the database
            return RedirectToAction("Shop");
        }


        public IActionResult RemoveFromWishlist(int productId)
        {
            _vegeBusinessAccess.DeleteFromWishlist(productId, 1);
            return RedirectToAction("Wishlist");
        }

        public IActionResult RemoveFromCart(int productId)
        {
           _vegeBusinessAccess.DeleteFromCart(productId,1);
            return RedirectToAction("Cart");
        }

        public IActionResult Wishlist()
        {
            List<UserWishlistModel> userList = _vegeBusinessAccess.GetUserWishlist(1);

             //get the data from the database
            return View(userList);
        }


            public IActionResult AddToCart(int productId,int quantity,int price)
        {
                //get id from cookie
                //id,userid,prodId,Quantity,price

                UserCart userObj = new UserCart();
                userObj.UserId = 1;
                userObj.ProductId = productId;
                userObj.Quantity = quantity;
                userObj.Price = price;

            //Add or update object
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
