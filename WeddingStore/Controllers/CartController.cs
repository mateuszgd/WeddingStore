using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WeddingStore.Domain.Logic;
using WeddingStore.Domain.Models;
using WeddingStore.Models;

namespace WeddingStore.Controllers
{
    public class CartController : Controller
    {
        private IProduct db;
        private IProcessOrder processOrder;

        public CartController(IProduct productParam, IProcessOrder processOrderParam)
        {
            db = productParam;
            processOrder = processOrderParam;
        }

        public RedirectToRouteResult AddItemToCart(CartFunctions cartFunctions, int productId, string url)
        {
            Product product = db.Products.FirstOrDefault(m => m.ProductId == productId);

            if (product != null)
            {
                cartFunctions.AddItem(product, 1);
            }
            return RedirectToAction("CartSummary", new { url });
        }

        public RedirectToRouteResult RemoveItemCart(CartFunctions cartFunctions, int productId, string url)
        {
            Product product = db.Products.FirstOrDefault(k => k.ProductId == productId);

            if (product != null)
            {
                cartFunctions.RemoveItem(product);
            }
            return RedirectToAction("CartSummary", new { url });
        }

        public ViewResult CartSummary(CartFunctions cartFunctions, string url)
        {
            return View(new CartContents { Url = url, cartFunctions = cartFunctions, });
        }

        public PartialViewResult CartNavbar(CartFunctions cartFunctions)
        {
            return PartialView(cartFunctions);
        }

        public PartialViewResult OrderValue(CartFunctions cartFunctions)
        {
            return PartialView(cartFunctions);
        }

        public ViewResult SubmitOrder()
        {
            return View(new Order());
        }

        [HttpPost]
        public ViewResult SubmitOrder(CartFunctions cartFunctions, Order order)
        {
            if (ModelState.IsValid)
            {
                processOrder.OrderProcess(cartFunctions, order);
                cartFunctions.Clear();
                return View("End");
            }
            else
            {
                return View(order);
            }
        }
    }
}