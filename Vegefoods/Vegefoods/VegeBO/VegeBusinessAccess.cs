using System;
using System.Collections.Generic;
using VegeFoodsBO.Interface;
using VegeFoodsDO.Interface;
using VegeFoodsEntities.CustomEntities;
using VegeFoodsEntities.Entities;

namespace VegeFoodsBO
{
    public class VegeBusinessAccess : IVegeBusinessAccess
    {

        public readonly IVegeDataAccess _vegeDataAccess;

        public VegeBusinessAccess(IVegeDataAccess vegeDataAccess)
        {
            _vegeDataAccess = vegeDataAccess;
        }

        public List<Products> GetProducts()
        {
            return _vegeDataAccess.GetProducts();
        }


        public Products GetProductById(long productId)
        {
            return _vegeDataAccess.GetProductById(productId);
        }


        public int AddToWishlist(UserWishlist userWishlist)
        {
           return  _vegeDataAccess.AddToWishlist(userWishlist);
        }

        public List<UserWishlistModel> GetUserWishlist(long userId)
        {
            return _vegeDataAccess.GetUserWishlist(userId);
        }

        public List<UserCartModel> GetUserCart(long userId)
        {
            return _vegeDataAccess.GetUserCart(userId);
        }

        public int AddToCart(UserCart userCart)
        {
            return _vegeDataAccess.AddToCart(userCart);
        }

        public int DeleteFromWishlist(long productId, long userId)
        {
            return _vegeDataAccess.DeleteFromWishlist(productId, userId);
        }

        public int DeleteFromCart(long productId, long userId)
        {
            return _vegeDataAccess.DeleteFromCart(productId, userId);
        }

        public long GetUserTotal(long userId)
        {
            return _vegeDataAccess.GetUserTotal( userId);
        }
        public Users AuthenticateUser(Users user)
        {
            return _vegeDataAccess.AuthenticateUser(user);
        }

        public void UpdateProductQuantity(long productId, long quantity)
        {
             _vegeDataAccess.UpdateProductQuantity(productId, quantity);
        }

        public List<UserCart> GetUserProducts(long userId)
        {
           return _vegeDataAccess.GetUserProducts(userId);
        }

        public int SaveBillingDetails(UserBilling userBill)
        {
            return _vegeDataAccess.SaveBillingDetails(userBill);
        }
        public List<Products> Pagination(int PageNumber, int PageSize, List<Products> products)
        {
            return _vegeDataAccess.Pagination(PageNumber, PageSize, products);
        }

        public long GetFirstProduct()
        {
            return _vegeDataAccess.GetFirstProduct();
        }
    }
}
