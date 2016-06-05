using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStoreWCF.Web.Models;
using MusicStoreWCF.Web.ProductService;
using MusicStoreWCF.Web.Wrappers;

namespace MusicStoreWCF.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var productWrapper = new ProductWrapper();
            var getAllProducts = productWrapper.GetAllProducts();

            return View(getAllProducts);
        }


        [ChildActionOnly]
        public ActionResult CategoryMenu()
        {
            var productWrapper = new ProductWrapper();
            var getAllCategories = productWrapper.GetAllCategories();

            return PartialView("_CategoryMenu", getAllCategories);
        }

        public ActionResult CategoryProduct(int categoryId)
        {
            var productWrapper = new ProductWrapper();
            var getAllCategories = productWrapper.GetAllCategories();

            var productCategoryList = getAllCategories.Single(x => x.CategoryId == categoryId);
            var productList = productCategoryList.Products.ToList();

            return View("Index", productList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}