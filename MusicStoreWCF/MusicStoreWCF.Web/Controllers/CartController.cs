using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStoreWCF.Web.Infrastructure;
using MusicStoreWCF.Web.Infrastructure.Interface;
using MusicStoreWCF.Web.Models;

namespace MusicStoreWCF.Web.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private ISessionManager sessionManager { get; set; }
        private readonly ShoppingCartManager _shoppingCartManager;

        public CartController()
        {
            this.sessionManager = new SessionManager();
            this._shoppingCartManager = new ShoppingCartManager(this.sessionManager);
        }

        public ActionResult Index()
        {
            var cartItems = _shoppingCartManager.GetCart();
            var cartTotalPrice = _shoppingCartManager.GetCartTotalPrice();

            CartViewModel cartVM = new CartViewModel() { CartItems = cartItems, TotalPrice = cartTotalPrice };

            return View(cartVM);
        }

        public ActionResult AddToCart(int id)
        {
            _shoppingCartManager.AddToCard(id);
            return RedirectToAction("Index");
        }

        public int GetCartItemsCount()
        {
            return _shoppingCartManager.GetCartItemsCount();
        }

        public ActionResult RemoveFromCart(int id)
        {
            int itemCount = _shoppingCartManager.RemoveFromCart(id);
            //int cartItemsCount = _shoppingCartManager.GetCartItemsCount();
            //decimal cartTotal = _shoppingCartManager.GetCartTotalPrice();

            return RedirectToAction("Index");
        }
    }
}