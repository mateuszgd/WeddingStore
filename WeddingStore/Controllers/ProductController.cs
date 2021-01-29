using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using WeddingStore.Domain.Logic;
using WeddingStore.Domain.Models;
using WeddingStore.Models;

namespace WeddingStore.Controllers
{
    public class ProductController : Controller
    {
        private IProduct db;
        public int NumberProducts = 6;

        public ProductController(IProduct productParam)
        {
            db = productParam;
        }

        public ViewResult Shop(string category, int subpage = 1)
        {
            AllDataToView allData = new AllDataToView
            {
                Products = db.Products.Where(m => category == null || m.Category.ToLowerInvariant().Replace(' ', '-') == category)
                .OrderBy(m => m.ProductId)
                .Skip((subpage - 1) * NumberProducts).Take(NumberProducts),
                PageLink = new PageLink
                {
                    SelectedPage = subpage,
                    AllProducts = category == null ? db.Products.Count() : db.Products.Where(k => k.Category.ToLowerInvariant().Replace(' ', '-') == category).Count(),
                    ProductsOnPage = NumberProducts
                },
                SelectedCategory = category
            };
            return View(allData);
        }

        public PartialViewResult Categories()
        {
            IEnumerable<string> list = db.Products.Select(p => p.Category).Distinct().OrderBy(p => p);
            return PartialView(list);
        }

        public ActionResult Index()
        {
            return View();
        }

        public FileContentResult Image(int productId)
        {
            Product product = db.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                return File(product.DataImage, product.TypeImage);
            }
            else
            {
                return null;
            }
        }
    }
}