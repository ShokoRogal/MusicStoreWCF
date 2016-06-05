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
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly ProductServiceClient prdClient = new ProductServiceClient();
        public ActionResult Index()
        {
            var productWrapper = new ProductWrapper();
            var getAllProducts = productWrapper.GetAllProducts();
            //var getAllCategories = productWrapper.GetAllCategories();
            List<Product>listProducts = new List<Product>();
            listProducts = getAllProducts;

            //ProductViewModel productVM = new ProductViewModel() { ProductList = getAllProducts, ProductCategory = getAllCategories };
            return View(listProducts);
        }

        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!this.ModelState.IsValid)
            {
                return View(product);
            }
            prdClient.AddProduct(product.Name, product.Description, product.Price, product.CategoryId);
            return RedirectToAction("Index");
        }

        public ViewResult Edit(int id)
        {
            var productWrapper = new ProductWrapper();
            var getAllProducts = productWrapper.GetAllProducts();
            Product product = getAllProducts.Single(x => x.ProductId == id);

            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (!this.ModelState.IsValid)
            {
                return View(product);
            }
            prdClient.EditProduct(product.ProductId ,product.Name, product.Description, product.Price, product.CategoryId);
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            var productWrapper = new ProductWrapper();
            var getAllProducts = productWrapper.GetAllProducts();
            Product product = getAllProducts.Single(x => x.ProductId == id);

            return View(product);
        }

        [HttpPost]
        public ActionResult Remove(Product product)
        {
            prdClient.RemoveProduct(product.ProductId);

            return RedirectToAction("Index");
        }
    }
}