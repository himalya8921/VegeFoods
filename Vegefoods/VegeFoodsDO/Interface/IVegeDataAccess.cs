using System;
using System.Collections.Generic;
using System.Text;
using VegeFoodsEntities.CustomEntities;
using VegeFoodsEntities.Entities;

namespace VegeFoodsDO.Interface
{
    public interface IVegeDataAccess
    {
        public List<Products> GetProducts();

        public Products GetProductById(long productId);

        public int AddToWishlist(UserWishlist userWishlist);

        public List<UserWishlistModel> GetUserWishlist(long userId);

        public int AddToCart(UserCart userCart);

        public int DeleteFromWishlist(long productId, int userId);

        public int DeleteFromCart(long productId, int userId);

        public List<UserCartModel> GetUserCart(long userId);

        public long GetUserTotal(long userId);

        public long AuthenticateUser(Users user);

        public void UpdateProductQuantity(long productId, long quantity);

        public List<UserCart> GetUserProducts(int userId);

        public List<Products> Pagination(int PageNumber, int PageSize, List<Products> products);
        public long GetFirstProduct();

        public int SaveBillingDetails(UserBilling userBill);
    }
}
