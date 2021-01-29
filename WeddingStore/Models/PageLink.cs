using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeddingStore.Models
{
    public class PageLink
    {
        public int SelectedPage { get; set; }
        public int AllProducts { get; set; }
        public int ProductsOnPage { get; set; }

        public int NumberPages
        {
            get { return (int)Math.Ceiling((decimal)AllProducts / ProductsOnPage); }
        }
    }
}