using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VegeFoodsDO.Interface;
using VegeFoodsEntities.CustomEntities;
using VegeFoodsEntities.Entities;

namespace VegeFoodsDO
{
    public class VegeDataAccess : IVegeDataAccess
    {
        private readonly VegeDbContext _vegeDbContext;

        public VegeDataAccess(VegeDbContext vegeDbContext)
        {
            _vegeDbContext = vegeDbContext;
        }



        //Pagination using Stored Procedure
        public List<Products> Pagination(int PageNumber, int PageSize, List<Products> products)
        {
            try
            {
                products = _vegeDbContext.Products.FromSqlRaw("exec [dbo].[spPagination] " + PageNumber + ",12").ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return products;
        }
        public long GetFirstProduct()
        {
            var productObj = _vegeDbContext.Products.FirstOrDefault();
            if(productObj != null)
            {
                return productObj.ProductId;
            }
            return -1;
        }

        public List<Products> GetProducts()
        {
            return _vegeDbContext.Products.Where(x => x.AvailableQuantity > 0).ToList();
        }

        public void UpdateProductQuantity(long productId,long quantity)
        {
            try
            {
                _vegeDbContext.Database.ExecuteSqlRaw("[dbo].[spUpdateProductQty] @ProductId,@Quantity", new SqlParameter("@ProductId", productId), new SqlParameter("@Quantity", quantity));
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public Users AuthenticateUser(Users user)
        {
            Users userObj = (Users)_vegeDbContext.Users.FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password);
            if(userObj != null)
            {
                return userObj;
            }
            return null;
        }
        public Products GetProductById(long productId)
        {
            return (Products)_vegeDbContext.Products.FirstOrDefault(x => x.ProductId == productId);
        }

        public int AddToWishlist(UserWishlist userWishlist)
        {
           UserWishlist objPresent = (UserWishlist)_vegeDbContext.UserWishlist.FirstOrDefault(x => x.UserId == userWishlist.UserId && x.ProductId == userWishlist.ProductId);
            if (objPresent == null)
            {
                try
                {
                    _vegeDbContext.UserWishlist.Add(userWishlist);
                    return _vegeDbContext.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return -1;
        }

        public int SaveBillingDetails(UserBilling userBill)
        {
            _vegeDbContext.UserBilling.Add(userBill);
            return _vegeDbContext.SaveChanges();
        }

        public int AddToCart(UserCart userCart)
        {
            UserCart objPresent = (UserCart)_vegeDbContext.UserCart.FirstOrDefault(x => x.UserId == userCart.UserId && x.ProductId == userCart.ProductId);

            if(objPresent == null)
            {
                _vegeDbContext.UserCart.Add(userCart);
              
            }
            else
            {
                var eachPrice = objPresent.Price / objPresent.Quantity;
                var product = userCart.Quantity * eachPrice;
                objPresent.Quantity = objPresent.Quantity + userCart.Quantity;
                objPresent.Price = objPresent.Price + (eachPrice* userCart.Quantity);
                _vegeDbContext.UserCart.Update(objPresent);
               
            }
            return _vegeDbContext.SaveChanges();

        }

        
        public List<UserWishlistModel> GetUserWishlist(long userId)
        {
            var temp = _vegeDbContext.UserWishlistModel.FromSqlRaw("[dbo].[spGetUserWishlist] @userId", new SqlParameter("@userId", userId)).ToList();
            return temp;
         
        }


        public List<UserCartModel> GetUserCart(long userId)
        {
            var totalIncome = _vegeDbContext.UserCart.Where(x => x.UserId == 1).Sum(x => x.Price);
            var temp = _vegeDbContext.UserCartModel.FromSqlRaw("[dbo].[spGetUserCart] @userId", new SqlParameter("@userId", userId)).ToList();
            return temp;
        }

        public long GetUserTotal(long userId)
        {
            return _vegeDbContext.UserCart.Where(x => x.UserId == userId).Sum(x => x.Price);
        }


        public int DeleteFromWishlist(long productId, long userId)
        {
            var Obj = _vegeDbContext.UserWishlist.FirstOrDefault(x => x.ProductId == productId
            && x.UserId == userId);

            _vegeDbContext.UserWishlist.Remove(Obj);

            return _vegeDbContext.SaveChanges();
        }

        public int DeleteFromCart(long productId, long userId)
        {
            var Obj = _vegeDbContext.UserCart.FirstOrDefault(x => x.ProductId == productId
            && x.UserId == userId);

            _vegeDbContext.UserCart.Remove(Obj);

            return _vegeDbContext.SaveChanges();
        }

        public List<UserCart> GetUserProducts(long userId)
        {
            List<UserCart> Obj = _vegeDbContext.UserCart.Where(x => x.UserId == userId).ToList();

            return Obj;
        }


    }
}
