using System;
using System.Collections.Generic;
using System.Text;
using VegeFoodsEntities.CustomEntities;
using VegeFoodsEntities.Entities;

namespace VegeFoodsBO.Interface
{
   public interface IVegeBusinessAccess
    {
        public List<Products> GetProducts();
        public Products GetProductById(long productId);

        public int AddToWishlist(UserWishlist userWishlist);

        public List<UserWishlistModel> GetUserWishlist(long userId);

        public List<UserCartModel> GetUserCart(long userId);

        public int AddToCart(UserCart userCart);

        public int DeleteFromWishlist(long productId, long userId);

        public int DeleteFromCart(long productId, long userId);

        public long GetUserTotal(long userId);

        public Users AuthenticateUser(Users user);

        public void UpdateProductQuantity(long productId, long quantity);

        public List<UserCart> GetUserProducts(long userId);

        public List<Products> Pagination(int PageNumber, int PageSize, List<Products> products);

        public long GetFirstProduct();

        public int SaveBillingDetails(UserBilling userBill);
    }
}
