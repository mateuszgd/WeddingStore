using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WeddingStore.Domain.Models;

namespace WeddingStore.DI_Container.Connector
{
    public class CartConnectorModel : IModelBinder
    {
        private const string sessions = "CartFunctions";
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            CartFunctions cartFunctions = null;
            if (controllerContext.HttpContext.Session != null)
            {
                cartFunctions = (CartFunctions)controllerContext.HttpContext.Session[sessions];
            }

            if (cartFunctions == null)
            {
                cartFunctions = new CartFunctions();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessions] = cartFunctions;
                }
            }
            return cartFunctions;
        }
    }
}