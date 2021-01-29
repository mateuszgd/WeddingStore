using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeddingStore.Domain.Logic;
using WeddingStore.Domain.Models;

namespace WeddingStore.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProduct dbProduct;

        public AdminController(IProduct dbProductParam)
        {
            dbProduct = dbProductParam;
        }

        public ViewResult AdminConsole()
        {
            return View(dbProduct.Products);
        }

        public ViewResult Edit(int productId)
        {
            Product product = dbProduct.Products.FirstOrDefault(m => m.ProductId == productId);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase img = null)
        {
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    product.TypeImage = img.ContentType;
                    product.DataImage = new byte[img.ContentLength];
                    img.InputStream.Read(product.DataImage, 0, img.ContentLength);
                }
                dbProduct.Save(product);
                TempData["msg"] = string.Format("Zmiany dla {0} zostały zapisane.", product.Name);
                return RedirectToAction("AdminConsole");
            }
            else
            {
                return View(product);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Product());
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product productDeleted = dbProduct.Delete(productId);
            
            if (productDeleted != null)
            {
                TempData["msg"] = string.Format("Usunięto pomyślnie produkt {0}.", productDeleted.Name);
            }
            return RedirectToAction("AdminConsole");
        }
    }
}