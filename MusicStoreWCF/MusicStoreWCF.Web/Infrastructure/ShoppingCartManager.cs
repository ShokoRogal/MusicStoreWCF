using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Ajax.Utilities;
using MusicStoreWCF.Web.Infrastructure.Interface;
using MusicStoreWCF.Web.Models;
using MusicStoreWCF.Web.ProductService;
using MusicStoreWCF.Web.Wrappers;

namespace MusicStoreWCF.Web.Infrastructure
{
    public class ShoppingCartManager
    {
        private readonly ISessionManager _session;
        public string CartSessionKey = HttpContext.Current.User.Identity.Name;
        private ProductWrapper _productWrapper = new ProductWrapper();

        public ShoppingCartManager(ISessionManager session)
        {
            this._session = session;
        }

        public void AddToCard(int productid)
        {
            var allProducts = _productWrapper.GetAllProducts();

            var cart = this.GetCart();
            var cartItem = cart.Find(c => c.Product.ProductId == productid);

            if (cartItem != null)
                cartItem.Quantity++;
            else
            {
                var productToAdd = allProducts.Single(x => x.ProductId == productid);
                if (productToAdd != null)
                {
                    var newCartItem = new CartItem()
                    {
                        Product = productToAdd,
                        Quantity = 1,
                        TotalPrice = productToAdd.Price
                    };

                    cart.Add(newCartItem);
                }
            }

            _session.Set(CartSessionKey, cart);
        }

        public int RemoveFromCart(int productid)
        {
            var cart = this.GetCart();

            var cartItem = cart.Find(c => c.Product.ProductId == productid);

            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                    return cartItem.Quantity;
                }
                else
                    cart.Remove(cartItem);
            }

            return 0;
        }

        public List<CartItem> GetCart()
        {
            List<CartItem> cart;

            if (_session.Get<List<CartItem>>(CartSessionKey) == null)
            {
                cart = new List<CartItem>();
            }
            else
            {
                cart = _session.Get<List<CartItem>>(CartSessionKey) as List<CartItem>;
            }

            return cart;
        }

        public decimal GetCartTotalPrice()
        {
            var cart = this.GetCart();
            return cart.Sum(c => (c.Quantity * c.Product.Price));
        }

        public int GetCartItemsCount()
        {
            var cart = this.GetCart();
            int count = cart.Sum(c => c.Quantity);

            return count;
        }

        

        /*public void EmptyCart()
        {
            _session.Set<List<CartItem>>(CartSessionKey, null);
        }*/
    }
}
